using System;
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

                editorRichTextBox.SelectionFont = new Font(Font, newFontStyle);
            }
        }

        private void italicToolStripButton_Click(object sender, EventArgs e)
        {
            if (editorRichTextBox.SelectionFont != null)
            {
                System.Drawing.Font currentFont = editorRichTextBox.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (editorRichTextBox.SelectionFont.Italic == true)
                {
                    newFontStyle = (~FontStyle.Italic) & editorRichTextBox.SelectionFont.Style;
                }
                else
                {
                    newFontStyle = editorRichTextBox.SelectionFont.Style | FontStyle.Italic;
                }

                editorRichTextBox.SelectionFont = new Font(Font, newFontStyle);
            }
        }

        private void underlineToolStripButton_Click(object sender, EventArgs e)
        {
            if (editorRichTextBox.SelectionFont != null)
            {
                System.Drawing.Font currentFont = editorRichTextBox.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (editorRichTextBox.SelectionFont.Underline == true)
                {
                    newFontStyle = (~FontStyle.Underline) & editorRichTextBox.SelectionFont.Style;
                }
                else
                {
                    newFontStyle = editorRichTextBox.SelectionFont.Style | FontStyle.Underline;
                }

                editorRichTextBox.SelectionFont = new Font(Font, newFontStyle);
            }
        }

        // this should be selectedItem changed NOT comboBox clicked
        private void fontSizeToolStripComboBox_Click(object sender, EventArgs e)
        {
            string fontName = editorRichTextBox.SelectionFont.Name;

            switch (fontSizeToolStripComboBox.SelectedItem)
            {
                case "8":
                    editorRichTextBox.SelectionFont = new Font(fontName, 20);
                    break;
                default:
                    break;
            }
        }
    }
}
