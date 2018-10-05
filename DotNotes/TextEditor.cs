using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNotes
{
    public partial class TextEditor : Form
    {
        private UserType userType;

        public TextEditor(UserType type)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.userType = type;
            editorRichTextBox.Text = "test new style";
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // transion to Login
            var lf = new LoginForm
            {
                Location = this.Location
            };

            this.Hide();

            lf.Show();
        }

        private void open()
        {
 
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // transion to About
            var about = new About
            {
                Location = this.Location
            };

            this.Hide();
            // TODO: make it as a modal
            about.Show();
        }

        private void boldToolStripButton_Click(object sender, EventArgs e)
        {
            if (editorRichTextBox.SelectionFont != null)
            {
                System.Drawing.Font currentFont = editorRichTextBox.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (editorRichTextBox.SelectionFont.Bold == true)
                {
                    newFontStyle = (~FontStyle.Bold) & editorRichTextBox.SelectionFont.Style;
                }
                else
                {
                    newFontStyle = editorRichTextBox.SelectionFont.Style | FontStyle.Bold;
                }
                editorRichTextBox.SelectionFont = new Font(currentFont, newFontStyle);
            }
        }

        private void italicToolStripButton_Click(object sender, EventArgs e)
        {
            if (editorRichTextBox.SelectionFont != null)
            {
                System.Drawing.Font currentFont = editorRichTextBox.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                newFontStyle = editorRichTextBox.SelectionFont.Style ^ FontStyle.Italic;
                editorRichTextBox.SelectionFont = new Font(currentFont, newFontStyle);
            }
        }

        private void underlineToolStripButton_Click(object sender, EventArgs e)
        {
            if (editorRichTextBox.SelectionFont != null)
            {
                System.Drawing.Font currentFont = editorRichTextBox.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                newFontStyle = editorRichTextBox.SelectionFont.Style ^ FontStyle.Underline;

                editorRichTextBox.SelectionFont = new Font(currentFont, newFontStyle);
            }
        }

        // this should be selectedItem changed NOT comboBox clicked
        private void fontSizeToolStripComboBox_Click(object sender, EventArgs e)
        {
            var oldFontFamily = editorRichTextBox.SelectionFont.FontFamily;
            var oldFontStyle = editorRichTextBox.SelectionFont.Style;
            var selectedFontSize = (string) fontSizeToolStripComboBox.SelectedItem;

            if (selectedFontSize != "")
            {
                editorRichTextBox.SelectionFont = new Font(oldFontFamily, int.Parse(selectedFontSize), oldFontStyle);
            }
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            editorRichTextBox.Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            editorRichTextBox.Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            editorRichTextBox.Paste();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            var te = new TextEditor(userType)
            {
                Left = Left + 10,
                Top = Top + 10
            };
            te.Show();
        }

    }
}
