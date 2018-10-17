using System;
using System.IO;
using System.Linq;
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
            // get all the usernames for duplicate checking
            _usernames = usernames;
            // set View as default user type
            userTypecomboBox.SelectedIndex = 0;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (formDataValid())
            {
                var username = usernameTextBox.Text;
                var password = passwordTextBox.Text;
                var dateOfBirth = dateOfBirthPicker.Value.ToString(@"dd-MM-yyyy");
                var firstName = firstNameTextBox.Text;
                var lastName = lastNameTextBox.Text;
                var userType = (string)userTypecomboBox.SelectedItem == "Edit" ? UserType.Edit : UserType.View;

                var user = new User(username, password, firstName, lastName, dateOfBirth, userType);

                // save to the account file
                string dir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                var sw = new StreamWriter(dir + @"\login.txt", append: true);
                sw.WriteLine(user.Print());
                sw.Close();

                transitionToLogin();
            }
        }

        private bool formDataValid()
        {
            var username = usernameTextBox.Text;
            var password1 = passwordTextBox.Text;
            var password2 = passwordTextBox2.Text;
            var firstName = firstNameTextBox.Text;
            var lastName = lastNameTextBox.Text;
            var dob = dateOfBirthPicker.Value.ToString();

            if (!Validator.RequiredAll(username, password1, password2, firstName, lastName, dob))
                return false;
            if (!Validator.UsernameDuplicate(username, _usernames))
                return false;
            if (!Validator.PasswordMatch(password1, password2))
                return false;
            if (!Validator.PasswordLengthLimit(password1, 6, 20))
                return false;
            return true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            transitionToLogin();
        }

        private void SignUpForm_Closed(object sender, EventArgs e)
        {
            transitionToLogin();
        }
        private void transitionToLogin()
        {
            var loginForm = new LoginForm
            {
                Location = this.Location
            };
            Hide();
            loginForm.Show();
        }
    }
}
