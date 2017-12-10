using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TokenProject;
namespace TokenBoxExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            String[] data = { "Jorge Martínez Corbalán", "Juan Carlos Bocos Rodríguez", "Juan Carlos Bretón Rodríguez", "Juan Carlos Coralksdjflkasjdfdsa" };

           

            //tokenb.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tokenBox1.AddToken(textBox1.Text);
        }

        private void tokenBox1_TokenClicked(object sender, EventArgs e)
        {
            MessageBox.Show(((TokenEventArgs)e).Text);
        }

        private void chboxShowIcon_CheckedChanged(object sender, EventArgs e)
        {
            tokenBox1.ShowFileIconInTokens = chboxShowIcon.Checked;
        }

        private void chboxShowX_CheckedChanged(object sender, EventArgs e)
        {          
            tokenBox1.ShowDeleteCross = chboxShowX.Checked;
        }

        private void chboxCanDelBacksp_CheckedChanged(object sender, EventArgs e)
        {
            tokenBox1.CanDeleteTokensWithBackspace = chboxCanDelBacksp.Checked;
        }

        private void chboxTextCursor_CheckedChanged(object sender, EventArgs e)
        {
            tokenBox1.CanWriteInTokenBox = chboxTextCursor.Checked;
        }

        private void btnChangeTBbackgroundColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                tokenBox1.BackColor = colorDialog1.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //List<SuggestionItem> a = new List<SuggestionItem>();
            //a.Add( new SuggestionItem("Jorge Martinez Corbalán"));
            //a.Add(new SuggestionItem("Jorge Martinez Corbalán ALAN ASDFLfsalkdjflñkasjdfksd"));
            //tokenBox1.ShowSuggestionList(a.ToArray());
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                tokenBox1.DefaultTokenBackgroundColor = colorDialog1.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                tokenBox1.DefaultTokenForeColor = colorDialog1.Color;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                tokenBox1.DefaultTokenBackgroundColorHovered = colorDialog1.Color;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                tokenBox1.DefaultTokenForeColorHovered = colorDialog1.Color;
        }
    }
}
