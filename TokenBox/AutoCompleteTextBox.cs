using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace TokenProject
{
    /// <summary>
    /// This TokenProject borrows code from:
    /// http://autocompletetexboxcs.codeplex.com/
    /// Thank you to Peter Holpar for sharing his work.
    /// Under MS-Public License (below)
    /// </summary>
    public class AutoCompleteTextBox : TextBox
    {
        private ListBox _listBox;
        private bool _isAdded;
        private String[] _values;
        private String _formerValue = String.Empty;
        private int _MouseIndex = -1;
        private bool _showAutoComplete;

        #region Properties

        public bool ShowAutoComplete
        {
            get
            {
                return _showAutoComplete;
            }

            set
            {
                _showAutoComplete = value;
            }
        }

        public String[] Values
        {
            get
            {
                return _values;
            }
            set
            {
                _values = value;
            }
        }

        public List<String> SelectedValues
        {
            get
            {
                String[] result = Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                return new List<String>(result);
            }
        }
        #endregion //Properties

        #region Constructors
        private void InitializeComponent()
        {
            _listBox = new ListBox();
            //Events
            _listBox.MouseClick += _listBox_MouseClick;
            _listBox.MouseMove += _listBox_MouseMove;
            KeyDown += this_KeyDown;
            KeyUp += this_KeyUp;

        }


        public AutoCompleteTextBox() : this(true)
        {
            
        }

        public AutoCompleteTextBox(bool showAutoComplete)
        {
            ShowAutoComplete = showAutoComplete;
            InitializeComponent();
            ResetListBox();
            
        }

        #endregion Constructors

        #region Events

        private void _listBox_MouseMove(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            int index = _listBox.IndexFromPoint(e.Location);

            if (index != -1 && index != _MouseIndex)
            {
                if (_MouseIndex != -1)
                {
                    _listBox.SetSelected(_MouseIndex, false);
                }
                _MouseIndex = index;
                _listBox.SetSelected(_MouseIndex, true);
                _listBox.Invalidate();
                
            }
        }

        private void _listBox_MouseClick(object sender, MouseEventArgs e)
        {
            String seleccionado = ((ListBox)sender).SelectedItem.ToString();
            //MessageBox.Show(((ListBox)sender).SelectedItem.ToString());
            introduceToken(seleccionado, true);
            this.Focus();
        }

        public void tokenBox_BackColorChanged(object sender, EventArgs e)
        {//The textbox needs to have the same background color as the parent so it is 
          //not noticed.
            this.BackColor = ((TokenBox)sender).BackColor;
        }

        private void this_KeyUp(object sender, KeyEventArgs e)//todo: y esto??
        {
            if (ShowAutoComplete)
            {
                UpdateListBoxWithLocalMatches();
            }
        }

        private void this_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Tab:
                    {
                        AcceptInput();
                        break;
                    }
                case Keys.Down:
                    {
                        if ((_listBox.Visible) && (_listBox.SelectedIndex < _listBox.Items.Count - 1))
                            _listBox.SelectedIndex++;
                        break;
                    }
                case Keys.Up:
                    {
                        if ((_listBox.Visible) && (_listBox.SelectedIndex > 0))
                            _listBox.SelectedIndex--;
                        break;
                    }
            }
        }


        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            AcceptInput();
        }
        private void introduceToken(String textToken,bool hasX)
        {
            ((TokenBox)Parent).AddToken(textToken);
            this.Text = String.Empty;
            ResetListBox();
        }
        #endregion Events

        #region Methods
        public void ShowExternalSuggestionList(SuggestionItem[] sil)
        {
            SizeF sizeText;
            int widthListBox = _listBox.Width;            
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {                
                foreach (SuggestionItem si in sil)
                {
                    sizeText = g.MeasureString(si.Text, this._listBox.Font);
                    if (sizeText.Width > widthListBox) widthListBox = (int)sizeText.Width;
                    //I might as well just add it here...
                    _listBox.Items.Add(si.Text);
                }
            }
            _listBox.Width = widthListBox;
            _listBox.ItemHeight = 15;
            //_listBox.Items.AddRange(ListSuggestions.Select(x => x).ToArray());
            if (!_isAdded) //TODO: NO ENTIENDO PORQUE TIENE QUE AÑADIR ESTO
            {
                Parent.Parent.Controls.Add(_listBox); //CLARO, SE TIENE QUE IR A LA VENTANA PARA QUE EL DESPLEGABLE ESTÉ POR ENCIMA DE TODO.

                _isAdded = true;
            }//esto de arriba?

            _listBox.Top = this.Bottom + Parent.Top;
            _listBox.Left = this.Left + Parent.Left;
            if (_listBox.Right + Parent.Left > Parent.Parent.Width)
            {
                _listBox.Left -= _listBox.Right - Parent.Parent.Width;
            }
            _listBox.Visible = true;
            _listBox.BringToFront();

        }

        private void ShowListBox()
        {
            if (ShowAutoComplete)
            {
                if (!_isAdded) //TODO: NO ENTIENDO PORQUE TIENE QUE AÑADIR ESTO
                {
                    Parent.Parent.Controls.Add(_listBox); //CLARO, SE TIENE QUE IR A LA VENTANA PARA QUE EL DESPLEGABLE ESTÉ POR ENCIMA DE TODO.

                    _isAdded = true;
                }//esto de arriba?

                _listBox.Top = this.Bottom + Parent.Top;
                _listBox.Left = this.Left + Parent.Left;
                _listBox.Visible = true;
                _listBox.BringToFront();
            }
        }

        private void ResetListBox()
        {
            _listBox.Visible = false;
            _MouseIndex = -1;
        }
        


        private void AcceptInput()
        {
            if (_listBox.Visible)
            {
                String seleccionado = (String)_listBox.SelectedItem;
                introduceToken(seleccionado, true);
                _formerValue = Text;
                this.Focus();
            }
            else
            {
                string entrada = this.Text;
                entrada = entrada.Trim();
                if (entrada.Length > 0)
                {                  
                    ((TokenBox)Parent).AddToken(entrada);
                    this.Clear();
                    this.Focus();
                }
            }            
        }

        private void UpdateListBoxWithLocalMatches()
        {
            if (Text == _formerValue) return;
            _formerValue = Text;
            String word = GetWord();

            if (_values != null && word.Length > 0)
            {
                String[] matches = Array.FindAll(_values,
                 x => (x.StartsWith(word, StringComparison.OrdinalIgnoreCase) && !SelectedValues.Contains(x)));
                if (matches.Length > 0)
                {
                    ShowListBox();
                    _listBox.Items.Clear();
                    Array.ForEach(matches, x => _listBox.Items.Add(x));
                    //_listBox.SelectedIndex = 0;
                    _listBox.Height = 0;
                    _listBox.Width = 0;
                    Focus();
                    using (Graphics graphics = _listBox.CreateGraphics())
                    {
                        for (int i = 0; i < _listBox.Items.Count; i++)
                        {
                            _listBox.Height += _listBox.GetItemHeight(i);
                            // it item width is larger than the current one
                            // set it to the new max item width
                            // GetItemRectangle does not work for me
                            // we add a little extra space by using '_'
                            int itemWidth = (int)graphics.MeasureString(((String)_listBox.Items[i]) + "_", _listBox.Font).Width;
                            _listBox.Width = (_listBox.Width < itemWidth) ? itemWidth : _listBox.Width;
                        }
                    }
                }
                else
                {
                    ResetListBox();
                }
            }
            else
            {
                ResetListBox();
            }
        }

        private String GetWord()
        {
            String text = Text;
            int pos = SelectionStart;

            int posStart = text.LastIndexOf(' ', (pos < 1) ? 0 : pos - 1);
            posStart = (posStart == -1) ? 0 : posStart + 1;
            int posEnd = text.IndexOf(' ', pos);
            posEnd = (posEnd == -1) ? text.Length : posEnd;

            int length = ((posEnd - posStart) < 0) ? 0 : posEnd - posStart;

            return text.Substring(posStart, length);
        }

        private void InsertWord(String newTag)
        {
            String text = Text;
            int pos = SelectionStart;

            int posStart = text.LastIndexOf(' ', (pos < 1) ? 0 : pos - 1);
            posStart = (posStart == -1) ? 0 : posStart + 1;
            int posEnd = text.IndexOf(' ', pos);

            String firstPart = text.Substring(0, posStart) + newTag;
            String updatedText = firstPart + ((posEnd == -1) ? "" : text.Substring(posEnd, text.Length - posEnd));


            Text = updatedText;
            SelectionStart = firstPart.Length;
        }

        #endregion Methods
    }
    //MS-Public License
    /*
     * Microsoft Public License (Ms-PL)

This license governs use of the accompanying software. If you use the software, you accept this license. If you do not accept the license, do not use the software.

1. Definitions

The terms "reproduce," "reproduction," "derivative works," and "distribution" have the same meaning here as under U.S. copyright law.

A "contribution" is the original software, or any additions or changes to the software.

A "contributor" is any person that distributes its contribution under this license.

"Licensed patents" are a contributor's patent claims that read directly on its contribution.

2. Grant of Rights

(A) Copyright Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free copyright license to reproduce its contribution, prepare derivative works of its contribution, and distribute its contribution or any derivative works that you create.

(B) Patent Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free license under its licensed patents to make, have made, use, sell, offer for sale, import, and/or otherwise dispose of its contribution in the software or derivative works of the contribution in the software.

3. Conditions and Limitations

(A) No Trademark License- This license does not grant you rights to use any contributors' name, logo, or trademarks.

(B) If you bring a patent claim against any contributor over patents that you claim are infringed by the software, your patent license from such contributor to the software ends automatically.

(C) If you distribute any portion of the software, you must retain all copyright, patent, trademark, and attribution notices that are present in the software.

(D) If you distribute any portion of the software in source code form, you may do so only under this license by including a complete copy of this license with your distribution. If you distribute any portion of the software in compiled or object code form, you may only do so under a license that complies with this license.

(E) The software is licensed "as-is." You bear the risk of using it. The contributors give no express warranties, guarantees or conditions. You may have additional consumer rights under your local laws which this license cannot change. To the extent permitted under your local laws, the contributors exclude the implied warranties of merchantability, fitness for a particular purpose and non-infringement.
     * */
}
