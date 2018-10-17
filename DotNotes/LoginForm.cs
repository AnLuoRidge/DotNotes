using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DotNotes
{
    public partial class LoginForm : Form
    {
        private List<User> _users;
        private static List<string> _usernames = new List<string>();

        public LoginForm()
        {
            InitializeComponent();
            CenterToScreen();
            _users = LoadUsers();
            // Enable Enter key to login
            KeyPreview = true;
            KeyDown += new KeyEventHandler(Enter_Push);
        }

        static List<User> LoadUsers()
        {
            var users = new List<User>();
            try
            {
                string line;
                string dir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                StreamReader sr = new StreamReader(dir + @"\login.txt");

                // Read the first line of text
                line = sr.ReadLine();
                // Continue to read until reach end of file
                while (line != null)
                {
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
                    // record all the usernames
                    _usernames.Add(user.Username);
                    // Read the next line
                    line = sr.ReadLine();
                }

                sr.Close();
                return users;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return users;
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // try transiting to Editor
            var username = usernameTextBox.Text;
            var password = passwordTextBox.Text;
            User authorisedUser;

            if (!Validator.RequireUsername(username))
                return;
            if (!Validator.RequirePassword(password))
                return;
            if (!Validator.UsernameExisted(username, _usernames.ToArray()))
                return;

            try
            {
                authorisedUser = _users.Single(s => s.Username == username && s.Password == password);

                var te = new TextEditor(authorisedUser.Username, authorisedUser.Type);

                Hide();

                te.Show();
            }
            catch (Exception)
            {
                MessageBox.Show(Validator.wrongPasswordError);
            }

        }

        private void Enter_Push(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void newUserButton_Click(object sender, EventArgs e)
        {
            // transion to Sign up
            var signUpForm = new SignUpForm(_usernames.ToArray());
            Hide();
            signUpForm.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
