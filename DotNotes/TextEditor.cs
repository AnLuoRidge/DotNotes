using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DotNotes
{
    public partial class TextEditor : Form
    {
        private UserType _userType;
        private string _username;
        private string _pathName = "";

        public TextEditor(string username, UserType type)
        {
            InitializeComponent();
            this.CenterToScreen();
            _userType = type;
            editorRichTextBox.ReadOnly = _userType != UserType.Edit;

#if DEBUG
            editorRichTextBox.Text = "These text is only showed in DEBUG mode for testing.";
#endif
            // set the default font size
            editorRichTextBox.Font = new Font(editorRichTextBox.SelectionFont.FontFamily, 14);
            _username = username;
            usernameToolStripLabel.Text = "User: " + _username;
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
            var about = new AboutBox
            {
                Location = this.Location
            };

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
            var te = new TextEditor(_username, _userType)
            {
                Left = Left + 10,
                Top = Top + 10
            };
            te.Show();
        }

        private void openFileStripButton_Click(object sender, EventArgs e)
        {
            string ext = Path.GetExtension(openFileDialog.FileName);
            if
(openFileDialog.ShowDialog() ==
DialogResult.OK &&
      openFileDialog.FileName.Length > 0)
            {
//                if (ext == "txt")
//                {
//                    editorRichTextBox.LoadFile(_pathName,
//RichTextBoxStreamType
//.PlainText);
//                }
//                else
if (ext == "rtf")
                {
                    editorRichTextBox.LoadFile(_pathName,
RichTextBoxStreamType
.RichText);
                }
            }
            _pathName = openFileDialog.FileName;
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (_pathName != "")
            {
                editorRichTextBox.SaveFile(_pathName,
RichTextBoxStreamType
.RichText);
            } else
            {
                saveAsToolStripButton_Click(sender, e);
            }
        }

        private void saveAsToolStripButton_Click(object sender, EventArgs e)
        {
            if
(saveFileDialog.ShowDialog() ==
DialogResult.OK &&
saveFileDialog.FileName.Length > 0)
            {
                editorRichTextBox.SaveFile(saveFileDialog.FileName,
                RichTextBoxStreamType
                .RichText);
            }
        }

        private void aboutToolStripButton_Click(object sender, EventArgs e)
        {
            aboutToolStripMenuItem_Click(sender, e);
        }
    }
}
