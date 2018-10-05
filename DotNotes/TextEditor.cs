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
            try 
            {
                string line;
//Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("/Users/anluoridge/Library/Mobile Documents/com~apple~CloudDocs/UTS/dotnet/Assignment2/login.txt");

//Read the first line of text
                line = sr.ReadLine();

//Continue to read until you reach end of file
                while (line != null) 
                {
//write the lie to console window
//                    Console.WriteLine(line);
                    // jimy1,asdasd,View,Jim,MacDonald,14-09-1970
                    var userInfo = line.Split(',');
                    var username = userInfo[0];
                    var pwd = userInfo[1];
                    var type = userInfo[2];
                    var firstName = userInfo[3];
                    var lastName = userInfo[4];
                    var dateStr = userInfo[5];

                    UserType userType = type == "Edit" ? UserType.Edit : UserType.View;

                    var user = new User(username, pwd, firstName, lastName, dateStr, userType);
                    Console.WriteLine(user.Username+user.DateOfBirth+user.Password+user.FirstName);
                    // type enum
                    // date convert
//Read the next line
                    line = sr.ReadLine();
                }

                
//close the file
                sr.Close();
                Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally 
            {
                Console.WriteLine("Executing finally block.");
            }
            
            // add a line to end of file

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

        // https://stackoverflow.com/questions/18966407/enable-copy-cut-past-window-in-a-rich-text-box
    }
}
