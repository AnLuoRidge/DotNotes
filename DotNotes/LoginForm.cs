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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(usernameTextBox.Text);
            Console.WriteLine(passwordTextBox.Text);
            // transion to Editor
            var te = new TextEditor
            {
                Location = this.Location
            };

            this.Hide();

            te.Show();
        }

        private void newUserButton_Click(object sender, EventArgs e)
        {

        }
    }
}
