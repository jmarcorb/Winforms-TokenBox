namespace TokenBoxExample
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chboxShowIcon = new System.Windows.Forms.CheckBox();
            this.chboxShowX = new System.Windows.Forms.CheckBox();
            this.chboxCanDelBacksp = new System.Windows.Forms.CheckBox();
            this.chboxTextCursor = new System.Windows.Forms.CheckBox();
            this.chboxShowAutocomplete = new System.Windows.Forms.CheckBox();
            this.btnChangeTBbackgroundColor = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.tokenBox1 = new TokenProject.TokenBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menu1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(138, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "AddToken";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 20);
            this.textBox1.TabIndex = 3;
            // 
            // chboxShowIcon
            // 
            this.chboxShowIcon.AutoSize = true;
            this.chboxShowIcon.Location = new System.Drawing.Point(12, 58);
            this.chboxShowIcon.Name = "chboxShowIcon";
            this.chboxShowIcon.Size = new System.Drawing.Size(76, 17);
            this.chboxShowIcon.TabIndex = 5;
            this.chboxShowIcon.Text = "Show icon";
            this.chboxShowIcon.UseVisualStyleBackColor = true;
            this.chboxShowIcon.CheckedChanged += new System.EventHandler(this.chboxShowIcon_CheckedChanged);
            // 
            // chboxShowX
            // 
            this.chboxShowX.AutoSize = true;
            this.chboxShowX.Location = new System.Drawing.Point(12, 82);
            this.chboxShowX.Name = "chboxShowX";
            this.chboxShowX.Size = new System.Drawing.Size(63, 17);
            this.chboxShowX.TabIndex = 6;
            this.chboxShowX.Text = "Show X";
            this.chboxShowX.UseVisualStyleBackColor = true;
            this.chboxShowX.CheckedChanged += new System.EventHandler(this.chboxShowX_CheckedChanged);
            // 
            // chboxCanDelBacksp
            // 
            this.chboxCanDelBacksp.AutoSize = true;
            this.chboxCanDelBacksp.Location = new System.Drawing.Point(12, 105);
            this.chboxCanDelBacksp.Name = "chboxCanDelBacksp";
            this.chboxCanDelBacksp.Size = new System.Drawing.Size(155, 17);
            this.chboxCanDelBacksp.TabIndex = 7;
            this.chboxCanDelBacksp.Text = "Can delete with backspace";
            this.chboxCanDelBacksp.UseVisualStyleBackColor = true;
            this.chboxCanDelBacksp.CheckedChanged += new System.EventHandler(this.chboxCanDelBacksp_CheckedChanged);
            // 
            // chboxTextCursor
            // 
            this.chboxTextCursor.AutoSize = true;
            this.chboxTextCursor.Location = new System.Drawing.Point(12, 129);
            this.chboxTextCursor.Name = "chboxTextCursor";
            this.chboxTextCursor.Size = new System.Drawing.Size(105, 17);
            this.chboxTextCursor.TabIndex = 8;
            this.chboxTextCursor.Text = "Show text cursor";
            this.chboxTextCursor.UseVisualStyleBackColor = true;
            this.chboxTextCursor.CheckedChanged += new System.EventHandler(this.chboxTextCursor_CheckedChanged);
            // 
            // chboxShowAutocomplete
            // 
            this.chboxShowAutocomplete.AutoSize = true;
            this.chboxShowAutocomplete.Location = new System.Drawing.Point(12, 153);
            this.chboxShowAutocomplete.Name = "chboxShowAutocomplete";
            this.chboxShowAutocomplete.Size = new System.Drawing.Size(120, 17);
            this.chboxShowAutocomplete.TabIndex = 9;
            this.chboxShowAutocomplete.Text = "Show autocomplete";
            this.chboxShowAutocomplete.UseVisualStyleBackColor = true;
            // 
            // btnChangeTBbackgroundColor
            // 
            this.btnChangeTBbackgroundColor.Location = new System.Drawing.Point(6, 19);
            this.btnChangeTBbackgroundColor.Name = "btnChangeTBbackgroundColor";
            this.btnChangeTBbackgroundColor.Size = new System.Drawing.Size(85, 39);
            this.btnChangeTBbackgroundColor.TabIndex = 10;
            this.btnChangeTBbackgroundColor.Text = "tokenBox1 Background";
            this.btnChangeTBbackgroundColor.UseVisualStyleBackColor = true;
            this.btnChangeTBbackgroundColor.Click += new System.EventHandler(this.btnChangeTBbackgroundColor_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 39);
            this.button2.TabIndex = 11;
            this.button2.Text = "Tokens background";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tokenBox1
            // 
            this.tokenBox1.AutoCompleteList = ((System.Collections.Generic.List<string>)(resources.GetObject("tokenBox1.AutoCompleteList")));
            this.tokenBox1.AutoScroll = true;
            this.tokenBox1.BackColor = System.Drawing.SystemColors.Window;
            this.tokenBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tokenBox1.CanAddTokenByText = true;
            this.tokenBox1.CanDeleteTokensWithBackspace = true;
            this.tokenBox1.CanWriteInTokenBox = true;
            this.tokenBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tokenBox1.DefaultTokenBackgroundColor = System.Drawing.Color.LightGray;
            this.tokenBox1.DefaultTokenBackgroundColorHovered = System.Drawing.Color.GhostWhite;
            this.tokenBox1.DefaultTokenBorderColor = System.Drawing.Color.DarkGray;
            this.tokenBox1.DefaultTokenBorderColorHovered = System.Drawing.Color.DarkGray;
            this.tokenBox1.DefaultTokenFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.tokenBox1.DefaultTokenFontHovered = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline);
            this.tokenBox1.DefaultTokenForeColor = System.Drawing.Color.Black;
            this.tokenBox1.DefaultTokenForeColorHovered = System.Drawing.Color.Blue;
            this.tokenBox1.Location = new System.Drawing.Point(229, 90);
            this.tokenBox1.Name = "tokenBox1";
            this.tokenBox1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.tokenBox1.ShowAutoComplete = true;
            this.tokenBox1.ShowDeleteCross = true;
            this.tokenBox1.ShowFileIconInTokens = false;
            this.tokenBox1.Size = new System.Drawing.Size(478, 32);
            this.tokenBox1.TabIndex = 12;
            this.tokenBox1.TokenClicked += new System.EventHandler<TokenProject.TokenEventArgs>(this.tokenBox1_TokenClicked);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 106);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 39);
            this.button3.TabIndex = 13;
            this.button3.Text = "Tokens text";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(97, 61);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 39);
            this.button4.TabIndex = 14;
            this.button4.Text = "Token background OnMouseOver";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(97, 106);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(112, 39);
            this.button5.TabIndex = 15;
            this.button5.Text = "Tokens text OnMouseOver";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnChangeTBbackgroundColor);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Location = new System.Drawing.Point(12, 177);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 153);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Colors";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(349, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "Winforms TokenBox";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu1ToolStripMenuItem,
            this.menu2ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(282, 48);
            // 
            // menu1ToolStripMenuItem
            // 
            this.menu1ToolStripMenuItem.Name = "menu1ToolStripMenuItem";
            this.menu1ToolStripMenuItem.Size = new System.Drawing.Size(281, 22);
            this.menu1ToolStripMenuItem.Text = "do something with token #{0} \"{1}\"";
            // 
            // menu2ToolStripMenuItem
            // 
            this.menu2ToolStripMenuItem.Name = "menu2ToolStripMenuItem";
            this.menu2ToolStripMenuItem.Size = new System.Drawing.Size(281, 22);
            this.menu2ToolStripMenuItem.Text = "do something else with token #{0} \"{1}\"";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 361);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tokenBox1);
            this.Controls.Add(this.chboxShowAutocomplete);
            this.Controls.Add(this.chboxTextCursor);
            this.Controls.Add(this.chboxCanDelBacksp);
            this.Controls.Add(this.chboxShowX);
            this.Controls.Add(this.chboxShowIcon);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox chboxShowIcon;
        private System.Windows.Forms.CheckBox chboxShowX;
        private System.Windows.Forms.CheckBox chboxCanDelBacksp;
        private System.Windows.Forms.CheckBox chboxTextCursor;
        private System.Windows.Forms.CheckBox chboxShowAutocomplete;
        private System.Windows.Forms.Button btnChangeTBbackgroundColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button2;
        private TokenProject.TokenBox tokenBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu2ToolStripMenuItem;
    }
}

