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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.CenterToScreen();

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(usernameTextBox.Text);
            Console.WriteLine(passwordTextBox.Text);
            // transion to Editor
            // UserType type 
            var te = new TextEditor(UserType.Edit);

            this.Hide();
            
            te.Show();
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
