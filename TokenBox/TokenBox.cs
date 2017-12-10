using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using System.Windows.Forms.Design;

namespace TokenProject
{
    
    class TokenBoxDesigner : ControlDesigner 
    {
        public override void Initialize(IComponent comp)
        {
            base.Initialize(comp);

        }
    }

    [Designer(typeof(TokenBoxDesigner))]   // Note: custom designer
    public partial class TokenBox : FlowLayoutPanel
    {
        
        AutoCompleteTextBox tb = new AutoCompleteTextBox();        
        bool showAutoComplete = true;
        //Dictionary<String, String> dicContactosRecordados = new Dictionary<string, string>();
        private List<String> autoCompleteList = new List<string>();
        private bool canAddTokenByText = true;
        private bool canDeleteTokensWithBackspace = true;
        private bool canWriteInTokenBox = true;
        private bool showFileIconInTokens = false;
        private bool showDeleteCross = true;
        
        private Color defaultTokenBorderColor = Color.DarkGray;
        private Color defaultTokenBorderColorHovered = Color.DarkGray;
        private Color defaultTokenTextColor = Color.Black;
        private Color defaultTokenForeColorHovered = Color.Blue;
        private Color defaultTokenBackgroundColor = Color.LightGray;
        private Color defaultTokenBackgroundColorHovered = Color.GhostWhite;
        
        private Font defaultTokenFont = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular);
        private Font defaultTokenFontHovered = new Font("Microsoft Sans Serif", 8F, FontStyle.Underline);
        
        public event EventHandler TokenClicked;

        #region Properties

        /// <summary>
        /// If set to true, user can write in TokenBox and Tab or Enter to add a new Token.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool CanAddTokenByText
        {            
            set
            {
                tb.ReadOnly = !value;
                tb.Text = String.Empty;
                canAddTokenByText = value;
            }
            get
            {
                return canAddTokenByText;
            }
        }

        /// <summary>
        /// Returns True if there are Tokens added in the TokenBox.
        /// </summary>
        public bool HasTokens
        {
            get
            {
                return this.Controls.ContainsKey("Token");
            }
        }

        /// <summary>
        /// Returns a copy of the collection of Tokens in the TokenBox.
        /// </summary>
        public List<Token> Tokens
        {
            get
            {
                ControlCollection todosControles = this.Controls;
                todosControles.RemoveAt(todosControles.Count - 1);
                return new List<Token>(todosControles.Cast<Token>());
            }

        }

        /// <summary>
        /// If set to True, a list of suggested texts will be shown to the user when writing the name of a new TokenBox. Needs to have CanAddTokenByText property set to True.
        /// </summary>
        public bool ShowAutoComplete
        {
            get
            {
                return showAutoComplete;
            }

            set
            {
                showAutoComplete = value;
                if (tb.ShowAutoComplete != value)
                {
                    tb.ShowAutoComplete = value;
                }
            }
        }

        /// <summary>
        /// List of the suggested values to be shown if ShowAutoComplete is set to True.
        /// </summary>
        public List<string> AutoCompleteList
        {
            get
            {
                return autoCompleteList;
            }

            set
            {
                autoCompleteList = value;
            }
        }


        public bool CanWriteInTokenBox 
        {
            get
            {
                return canWriteInTokenBox;
                
            }

            set
            {
                canWriteInTokenBox = value;
                if (value)
                {
                    if (!this.Controls.Contains(tb))
                    { this.Controls.Add(tb); }
                }
                else
                {
                    if (this.Controls.Contains(tb))
                    { this.Controls.Remove(tb); }
                }
            }
        }

        /// <summary>
        /// If set to False, the user will not be able to delete Tokens using Backspace when cursor is in TokenBox. Needs CanAddTokenByText set to True.
        /// </summary>
        public bool CanDeleteTokensWithBackspace
        {
            get
            {
                return canDeleteTokensWithBackspace;
            }

            set
            {
                canDeleteTokensWithBackspace = value;
            }
        }

        /// <summary>
        /// If set to True, a red cross will be shown in the rightmost part of the Token. Clicking on this cross will delete Token.
        /// </summary>
        public bool ShowDeleteCross
        {
            get
            {
                return showDeleteCross;
            }

            set
            {
                showDeleteCross = value;
            }
        }

        public bool ShowFileIconInTokens
        {
            get
            {
                return showFileIconInTokens;
            }

            set
            {
                showFileIconInTokens = value;
            }
        }

        public Color DefaultTokenBackgroundColor
        {
            get
            {
                return defaultTokenBackgroundColor;
            }

            set
            {
                defaultTokenBackgroundColor = value;
            }
        }


        public Color DefaultTokenBorderColor
        {
            get
            {
                return defaultTokenBorderColor;
            }

            set
            {
                defaultTokenBorderColor = value;
            }
        }

        public Font DefaultTokenFont
        {
            get
            {
                return defaultTokenFont;
            }

            set
            {
                defaultTokenFont = value;
            }
        }

        public Color DefaultTokenForeColor
        {
            get
            {
                return defaultTokenTextColor;
            }

            set
            {
                defaultTokenTextColor = value;
            }
        }

        public Color DefaultTokenBackgroundColorHovered
        {
            get
            {
                return defaultTokenBackgroundColorHovered;
            }

            set
            {
                defaultTokenBackgroundColorHovered = value;
            }
        }

        
        public Color DefaultTokenBorderColorHovered
        {
            get
            {
                return defaultTokenBorderColorHovered;
            }

            set
            {
                defaultTokenBorderColorHovered = value;
            }
        }

        public Font DefaultTokenFontHovered
        {
            get
            {
                return defaultTokenFontHovered;
            }

            set
            {
                defaultTokenFontHovered = value;
            }
        }

        public Color DefaultTokenForeColorHovered
        {
            get
            {
                return defaultTokenForeColorHovered;
            }

            set
            {
                defaultTokenForeColorHovered = value;
            }
        }


        #endregion

        #region Constructors
        public TokenBox()
        {
            
            InitializeComponent();
            this.tb.Margin = new Padding(4,7,2,4);
            this.Controls.Add(tb);            
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mouseClick);
            this.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.controlAdded);
            this.BackColor = Color.FromKnownColor(KnownColor.Window);
            this.Cursor = Cursors.IBeam;            
            this.AutoScroll = true;            
            this.AutoSize = false;
            this.Padding = new Padding(0, 0, 10, 0);            
            this.WrapContents = true;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.tb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_KeyDown);
            this.tb.TextChanged += new EventHandler(this.tb_TextChanged);
            //Estilos del TextBox:
            this.tb.BackColor = this.BackColor;
            this.tb.Width = 15;
            this.tb.MinimumSize = this.tb.Size;
            this.tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.tb.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.tb.BorderStyle = BorderStyle.None;
            this.tb.Values = AutoCompleteList.ToArray();
            this.MouseEnter += new EventHandler(this.OnMouseEnter);
            this.BackColorChanged += new System.EventHandler(this.tb.tokenBox_BackColorChanged);
        }

        #endregion Constructors

        #region Methods
        /// <summary>
        /// Adds a Token to the TokenBox.
        /// </summary>
        /// <param name="Text">Text that will be shown in the Token.</param>
        /// <param name="Item">Object with information associated with this Token. It can be a filename, a SMTP address, a Contact object,...</param>
        public void AddToken(String Text, Object Item = null)
        {
            Token newToken = new Token(Text,ShowDeleteCross, ShowFileIconInTokens, Item);
            newToken.TokenColor = DefaultTokenBackgroundColor;
            newToken.TokenColorHovered = DefaultTokenBackgroundColorHovered;            
            newToken.ForeColor = DefaultTokenForeColor;
            newToken.ForeColorHovered = DefaultTokenForeColorHovered;
            newToken.Font = DefaultTokenFont;
            newToken.FontHovered = DefaultTokenFontHovered;
            newToken.BorderColor = DefaultTokenBorderColor;
            newToken.BorderColorHovered = defaultTokenBorderColorHovered;
            newToken.NotifyParentEvent += new NotifyParentDelegate(OnTokenClicked);
            this.Controls.Add(newToken);
            if (this.Controls.Contains(tb))
            { this.Controls.SetChildIndex(tb, this.Controls.Count - 1); }

            
        }

        public void RemoveToken(int Position)
        {
            if(Position>0 && Position < this.Controls.Count - 1)
            {
                this.Controls.RemoveAt(Position);
            }
        }
        
        public void RemoveAllTokens()
        {
            for(int i = Controls.Count-1; i>=0 ;i--)
            {
                if(Controls[i] != tb) { Controls.RemoveAt(i); }
            }
        }

        public void ShowSuggestionList(SuggestionItem[] ListSuggestions)
        {
          
            this.tb.ShowExternalSuggestionList(ListSuggestions);
        }
        #endregion Methods

        #region Events
        public void OnMouseEnter(object sender, EventArgs e)
        {
            if (CanWriteInTokenBox) this.Cursor = Cursors.IBeam;
            else this.Cursor = Cursors.Default;
        }

        public void OnTokenClicked(TokenEventArgs customEventArgs)
        {
            TokenClicked?.Invoke(null, customEventArgs);
        }

        private void mouseClick(object sender, MouseEventArgs e)
        {
            this.tb.Focus();
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back &&
                tb.SelectionStart == 0 &&
                tb.SelectionLength == 0 &&
                this.CanDeleteTokensWithBackspace &&
                this.Controls.Count - 1 > 0)
            {               
                this.Controls.RemoveAt(this.Controls.Count - 2);                
            }

        }

        private void tb_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(this.tb.Text, this.tb.Font);
            
            this.tb.Width = size.Width+16;
            
        }

        private void controlAdded(object sender, ControlEventArgs e)
        {
            int alturaNecesaria = this.Controls.OfType<Control>().Max(x => x.Location.Y + x.Height) + 9;
            if (this.Height < alturaNecesaria)
            {
                if (this.MaximumSize.Height !=0 && this.MaximumSize.Height < alturaNecesaria)
                {
                    this.Height = this.MaximumSize.Height;
                }
                else
                {
                    this.Height = alturaNecesaria;
                }
            }
        }
        #endregion Events

    }

   
    
}
