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
    public partial class LoginForm : Form
    {
        private List<User> _users;
        public LoginForm()
        {
            InitializeComponent();
            this.CenterToScreen();
            _users = LoadUsers();
        }

        static List<User> LoadUsers()
        {
            var users = new List<User>();
            try
            {
                string line;
                //Pass the file path and file name to the StreamReader constructor
                string dir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                StreamReader sr = new StreamReader(dir + @"\login.txt");

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
                    users.Add(user);
                    // type enum
                    // date convert
                    //Read the next line
                    line = sr.ReadLine();
                }


                //close the file
                sr.Close();
                return users;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return users;
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            // add a line to end of file

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // transion to Editor
            // UserType type 
            var username = usernameTextBox.Text;
            var password = passwordTextBox.Text;

            User authorisedUser;
            try
            {
                authorisedUser = _users.Single(s => s.Username == username && s.Password == password);

                var te = new TextEditor(authorisedUser.Type);

                Hide();

                te.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed. Please try again.");
            }

        }

        private void newUserButton_Click(object sender, EventArgs e)
        {
            // transion to Sign up
            var su = new SignUpForm();

            this.Hide();

            su.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
