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
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
            // userTypecomboBox.Items.Add("View");
            // userTypecomboBox.Items.Add("Edit");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {

        }

        private void submitButton_Click(object sender, EventArgs e)
        {

            var username = usernameTextBox.Text;
            if (Validator())
            {
                // var user = new User();

                // transion to Login
                var lf = new LoginForm
                {
                    Location = this.Location
                };

                this.Hide();

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
            var dob = dateOfBirthPicker.Value;
            var type = userTypecomboBox.SelectedItem;
            
            
            Console.Write("afafdafdfaf");
            if (password1 != passwordTextBox2.Text)
            {
                MessageBox.Show("Two passwords don't match!");
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

            this.Hide();

            lf.Show();
        }
    }
}
