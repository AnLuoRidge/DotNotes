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
    public partial class SignUpForm : Form
    {
        private string[] _usernames;
        public SignUpForm(string[] usernames)
        {
            InitializeComponent();
            this.CenterToScreen();
            _usernames = usernames;
            userTypecomboBox.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {

        }

        private void submitButton_Click(object sender, EventArgs e)
        {

            if (Validator())
            {
                var username = usernameTextBox.Text;
                var password = passwordTextBox.Text;
                var dateOfBirth = dateOfBirthPicker.Value.ToString(@"dd-MM-yyyy");
                var firstName = firstNameTextBox.Text;
                var lastName = lastNameTextBox.Text;
                var userType = (string)userTypecomboBox.SelectedItem == "Edit" ? UserType.Edit : UserType.View;

                var user = new User(username, password, firstName, lastName, dateOfBirth, userType);

                // save to file
                string dir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                var sw = new StreamWriter(dir + @"\login.txt", append: true);
                sw.WriteLine(user.Print());
                sw.Close();
                // transion to Login
                var lf = new LoginForm();

                Hide();

                lf.Show();
            }
        }

        private bool Validator()
        {
            // check all filled
            // check length
            // error hint
            // check password match
            var username = usernameTextBox.Text;
            var password1 = passwordTextBox.Text;
            var password2 = passwordTextBox2.Text;
            var firstName = firstNameTextBox.Text;
            var lastName = lastNameTextBox.Text;
            var dob = dateOfBirthPicker.Value.ToString();
            var type = userTypecomboBox.SelectedItem;

            // Check all the fields are filled.
            if (username == "" ||
                password1 == "" ||
                password2 == "" ||
                firstName == "" ||
                lastName == "" ||
                dob == ""
                )
            {
                MessageBox.Show("All the fields are required!");
                return false;
            }
            if (password1 != passwordTextBox2.Text)
            {
                MessageBox.Show("Two passwords don't match!");
                return false;
            }
            if (_usernames.Contains(username))
            {
                MessageBox.Show("The username is already existed");
                return false;
            }
            if (username.Contains(" "))
            {
                MessageBox.Show("Space is not allowed in username");
                return false;
            }

            return true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // transion to Login
            var lf = new LoginForm
            {
                Location = this.Location
            };

            Hide();

            lf.Show();
        }
    }
}
