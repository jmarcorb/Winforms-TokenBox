using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using TokenProject.Properties;

namespace TokenProject
{
    

    public partial class Token : Control
    {
        public event NotifyParentDelegate NotifyParentEvent;
        private int m_Radius = 4;
        private int m_BorderWidth = 0;
        //private Color foreColorNormal;// = Color.Black; //color del texto
        private Color foreColorHovered;// = Color.Blue;
        //private Color tokenColorNormal;// = Color.LightGray;
        private Color tokenColorHovered;// = Color.DarkGray;
        private Color tokenColor;// = Color.LightGray;
        //private Font fontNormal;// = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular);
        private Font fontHovered;// = new Font("Microsoft Sans Serif", 8F, FontStyle.Underline);
        private bool showsX = true;
        private Size sizeDisplayedText = new Size();
        private Size sizeDisplayedX = new Size();
        private bool showFileIcon = true;
        private Rectangle rIcon = new Rectangle(0, 0, 0, 0);
        private Rectangle rCloseX = new Rectangle(0, 0, 0, 0);
        private Rectangle rText = new Rectangle(0, 0, 0, 0);
        private string fileExtensionToShow = null;
        private Point inicioRectangulos = new Point(3, 3);
        private Size sizeIcon = new Size(16, 16);
        private object additionalInfo = null;
        private bool isBeingHovered = false;
        #region Properties

        /// <summary>
        /// How rounded token corners will be.
        /// 0 --> Square corners, 10 --> Very round. Default 4.
        /// </summary>
        public int Radius
        {
            get
            {
                return m_Radius;
            }

            set
            {
                m_Radius = value;
            }
        }

        public int BorderWidth
        {
            get
            {
                return m_BorderWidth;
            }

            set
            {
                m_BorderWidth = value;
            }
        }

        //public Color ForeColorNormal
        //{
        //    get
        //    {
        //        return foreColorNormal;
        //    }

        //    set
        //    {
        //        foreColorNormal = value;
        //    }
        //}

        public bool ShowsX
        {
            get
            {
                return showsX;
            }

            set
            {
                showsX = value;
                if(showsX)
                {
                    sizeDisplayedX = Resources.StatusOffline_glyphRedNoHalo_16x.Size;// TextRenderer.MeasureText("x", fontX, new Size(1, 1), TextFormatFlags.SingleLine);
                }
                else
                {
                    sizeDisplayedX = new Size(0, 0);
                }
            }
        }

        public bool ShowFileIcon
        {
            get { return showFileIcon; }
            set { showFileIcon = value; }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                base.Text = value;
                SizeF sizeText;
                using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
                {
                    sizeText = g.MeasureString(base.Text, this.Font);
                }
                FileExtensionToShow = Path.GetExtension(value);
                rIcon.Location = inicioRectangulos;
                if (this.ShowFileIcon)
                {                    
                    rIcon.Size = sizeIcon;
                }
                
                sizeDisplayedText = new Size((int)sizeText.Width + 1, (int)sizeText.Height + 1);
                int offsetCentradoVerticalTexto = (sizeIcon.Height - sizeDisplayedText.Height) / 2;
                rText = new Rectangle(new Point(rIcon.Right + 1, inicioRectangulos.Y+ offsetCentradoVerticalTexto), sizeDisplayedText);
                
                rCloseX.Location = new Point(rText.Right + 1, inicioRectangulos.Y);
                if (this.ShowsX)
                {
                    rCloseX.Size = sizeIcon;
                }
                
                this.Size = new Size(rCloseX.Right+1,sizeIcon.Height+6);
             }
        }

        public string FileExtensionToShow
        {
            get
            {
                return fileExtensionToShow;
            }

            set
            {
                fileExtensionToShow = value;
            }
        }

        public object TokenItem
        {
            get
            {
                return additionalInfo;
            }

            set
            {
                additionalInfo = value;
            }
        }

        //public Font FontNormal
        //{
        //    get
        //    {
        //        return fontNormal;
        //    }

        //    set
        //    {
        //        fontNormal = value;
        //    }
        //}

        public Font FontHovered
        {
            get
            {
                return fontHovered;
            }

            set
            {
                fontHovered = value;
            }
        }

        public Color ForeColorHovered
        {
            get
            {
                return foreColorHovered;
            }

            set
            {
                foreColorHovered = value;
            }
        }

        //public Color TokenColorNormal
        //{
        //    get
        //    {
        //        return tokenColorNormal;
        //    }

        //    set
        //    {
        //        tokenColorNormal = value;
        //    }
        //}

        public Color TokenColorHovered
        {
            get
            {
                return tokenColorHovered;
            }

            set
            {
                tokenColorHovered = value;
            }
        }

        public Color TokenColor
        {
            get
            {
                return tokenColor;
            }

            set
            {
                tokenColor = value;
            }
        }

        #endregion Properties

        #region Constructors

        public Token() : this(null,true,false,null)
        {      
        }

   
        public Token(String TextToDisplay, bool ShowX=true, bool ShowIcon=false, Object Item = null)
        {
            InitializeComponent();
            //Set default property values for the button during start up
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            //SetTokenNormal();
            //this.fontX =  this.Font;//TODO: cambiar x en texto por líneas (y círculo rojo al mousehover)
            this.ShowsX = ShowX;
            this.ShowFileIcon = ShowIcon;
            this.Text = TextToDisplay;
            this.TokenItem = Item;
            
        }

        #endregion Constructors

        /// <summary>
        /// To Set button properties when not active.i.e when button not in focus.
        /// </summary>
        //private void SetTokenNormal()
        //{
        //    this.isBeingHovered = false;
        //    this.Font = FontNormal;           
        //    this.MinimumSize = sizeDisplayedText;
        //    this.ForeColor = this.ForeColorNormal;
        //    this.TokenColor = this.TokenColorNormal;
        //}
        
        /// <summary>
        /// Set attributes to highlight button when it is under focus/active.
        /// Change the cursor also as Hand type
        /// </summary>
        //private void SetTokenHovered()
        //{
        //    this.isBeingHovered = true;
        //    this.Font = this.FontHovered;
        //    this.ForeColor = this.ForeColorHovered;
        //    this.TokenColor = this.TokenColorHovered;
        //}


        #region Events
        /// <summary>
        /// Default handler.Nothing to do here since we don't need to repaint the button.
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);            
            Rectangle rFondo = this.DisplayRectangle; //ESTE ES TODO EL ÁREA DEL CONTROL
            //rect = this.ClientRectangle; //ESTE ES LA PARTE VISIBLE SOLO (UN PANEL CON SCROLL BARS SOLO MUESTRA CLIENTRECTANGLE)
            rFondo.X += 1;
            rFondo.Y += 1;
            rFondo.Width -= 2;
            rFondo.Height -= 2;

            using (GraphicsPath bb = GetPathRoundCorners(rFondo, Radius))
            {
                Color c;
                if (this.isBeingHovered) c = TokenColorHovered;
                else c = TokenColor;
                using (Brush br = new SolidBrush(c))
                {
                    pe.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                    pe.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    pe.Graphics.FillPath(br, bb);
                }

                using (Brush br = new SolidBrush(TokenColorHovered))
                {
                    rFondo.Inflate(-1, -1);
                    pe.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                    pe.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    pe.Graphics.DrawPath(new Pen(br, BorderWidth), bb);
                }
            }
            
            pe.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            if(this.ShowFileIcon)
            {
                try
                {
                    if (FileExtensionToShow == string.Empty)
                    {
                        pe.Graphics.DrawIcon(Resources.unknownFile, rIcon);
                    }
                    else
                    {
                        Icon ic = ShellIcon.GetSmallIconFromExtension(FileExtensionToShow);
                        pe.Graphics.DrawIcon(ic, rIcon);
                    }
                }
                catch
                {
                    pe.Graphics.DrawIcon(Resources.unknownFile, rIcon);
                }
                
            }

            Color ct;
            if (this.isBeingHovered) ct = ForeColorHovered;
            else ct = ForeColor;
            Font ft;
            if (this.isBeingHovered) ft = FontHovered;
            else ft = Font;
            pe.Graphics.DrawString(this.Text, this.Font, new SolidBrush(ct),rText);

            if (this.ShowsX)
            {
                if(isBeingHovered) pe.Graphics.DrawImage(Resources.StatusOffline_glyphRedNoHalo_16x, rCloseX);
                else pe.Graphics.DrawImage(Resources.StatusOffline_glyphBlackNoHalo_16x, rCloseX);
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.Cursor = Cursors.Hand;
            this.isBeingHovered = true;
            this.Refresh();
            //SetTokenHovered();
        }

        /// <summary>
        /// Event handler which call SetValuesOnFocus() method to give apecial
        /// effect to button while active
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);            
            //SetTokenHovered();
        }

        /// <summary>
        /// Event handler which call SetNormalValues() method to set back the button
        /// to normal state
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.Cursor = Cursors.Default;
            this.isBeingHovered = false;
            this.Refresh();
            //SetTokenNormal();
        }

        #endregion Events


        private GraphicsPath GetPathRoundCorners(Rectangle rc, int r)
        {
            int x = rc.X;
            int y = rc.Y;
            int w = rc.Width;
            int h = rc.Height;
            r = r << 1;
            GraphicsPath path = new GraphicsPath();
            if (r > 0)
            {
                if (r > h) r = h;
                if (r > w) r = w;
                path.AddArc(x, y, r, r, 180, 90);
                path.AddArc(x + w - r, y, r, r, 270, 90);
                path.AddArc(x + w - r, y + h - r, r, r, 0, 90);
                path.AddArc(x, y + h - r, r, r, 90, 90);
                path.CloseFigure();
            }
            else
            {
                path.AddRectangle(rc);
            }
            return path;
        }
        
        public event EventHandler TokenBodyClicked;
        protected void OnTokenBodyClicked(Object sender,MouseEventArgs e)
        {
            TokenBodyClicked?.Invoke(sender, e);
        }

        //action for when mouse click on close button
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (rCloseX.Contains(e.Location))
            {
                Parent.Controls.RemoveAt(Parent.Controls.IndexOf(this));
            }else
            {
                if (NotifyParentEvent != null)
                {
                    TokenEventArgs customEventArgs = new TokenEventArgs(this.Text,this.TokenItem,e.Button);
                    NotifyParentEvent(customEventArgs);
                }
            }
        }
        
      
        private PointF CenterTextHorizontallyInRectangle(Rectangle Container, Size sizeOfText, AlignmentInRecgangle air)
        {
            float x = 0;
            float y = 0;
            if(Container.Contains(new Rectangle(new Point(0,0),sizeOfText)))
            {
                y = (Container.Height - sizeOfText.Height) / 2f;
                switch (air)
                {
                    case AlignmentInRecgangle.Right:
                        x = Container.Width - sizeOfText.Width;
                        break;
                    case AlignmentInRecgangle.Center:
                        x = (Container.Width - sizeOfText.Width) / 2f;
                        break;
                    case AlignmentInRecgangle.Left:
                        x = 0;
                        break;
                }
            }
            else
            {
                //throw new ArgumentOutOfRangeException("sizeOfText", "Text out of bounds of container Rectangle.");
               
            }
            return new PointF(x,y);
        }
    }

}
