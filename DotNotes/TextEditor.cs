using System;
using System.IO;
using System.Drawing;
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
            // Prevent focus lost when change the font size
            editorRichTextBox.HideSelection = false;
            editorRichTextBox.ReadOnly = _userType != UserType.Edit;

#if DEBUG
            editorRichTextBox.Text = "This line is only showed in DEBUG mode for testing.";
#endif
            // set the default font size
            editorRichTextBox.Font = new Font(editorRichTextBox.SelectionFont.FontFamily, 14);
            _username = username;
            // set the username shown on the toolbar
            usernameToolStripLabel.Text = "User: " + _username;
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // open Login form
            var lf = new LoginForm
            {
                Location = this.Location
            };
            // close all the opened editors
            lf.Show();
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name != "LoginForm")
                    f.Close();
            }
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
                Font currentFont = editorRichTextBox.SelectionFont;
                FontStyle newFontStyle;

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
                Font currentFont = editorRichTextBox.SelectionFont;
                FontStyle newFontStyle;

                newFontStyle = editorRichTextBox.SelectionFont.Style ^ FontStyle.Italic;
                editorRichTextBox.SelectionFont = new Font(currentFont, newFontStyle);
            }
        }

        private void underlineToolStripButton_Click(object sender, EventArgs e)
        {
            if (editorRichTextBox.SelectionFont != null)
            {
                Font currentFont = editorRichTextBox.SelectionFont;
                FontStyle newFontStyle;

                newFontStyle = editorRichTextBox.SelectionFont.Style ^ FontStyle.Underline;

                editorRichTextBox.SelectionFont = new Font(currentFont, newFontStyle);
            }
        }

        // this should be selectedItem changed NOT comboBox clicked
        private void fontSizeToolStripComboBox_Click(object sender, EventArgs e)
        {
            var oldFontFamily = editorRichTextBox.SelectionFont.FontFamily;
            var oldFontStyle = editorRichTextBox.SelectionFont.Style;
            var selectedFontSize = (string)fontSizeToolStripComboBox.SelectedItem;

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
            var openWithValidFileName = openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.FileName.Length > 0;
            if (openWithValidFileName)
            {
                _pathName = openFileDialog.FileName;
                editorRichTextBox.LoadFile(_pathName, RichTextBoxStreamType.RichText);
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (_pathName != "")
            {
                editorRichTextBox.SaveFile(_pathName, RichTextBoxStreamType.RichText);
            }
            else
            {
                saveAsToolStripButton_Click(sender, e);
            }
        }

        private void saveAsToolStripButton_Click(object sender, EventArgs e)
        {
            var saveWithValidFileName = saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.FileName.Length > 0;
            if (saveWithValidFileName)
            {
                editorRichTextBox.SaveFile(saveFileDialog.FileName,
                RichTextBoxStreamType
                .RichText);
                _pathName = saveFileDialog.FileName;
            }
        }

        private void aboutToolStripButton_Click(object sender, EventArgs e)
        {
            aboutToolStripMenuItem_Click(sender, e);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newToolStripButton_Click(sender, e);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileStripButton_Click(sender, e);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveToolStripButton_Click(sender, e);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAsToolStripButton_Click(sender, e);
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cutToolStripButton_Click(sender, e);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyToolStripButton_Click(sender, e);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pasteToolStripButton_Click(sender, e);
        }
    }
}
