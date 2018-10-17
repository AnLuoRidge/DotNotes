using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DotNotes
{
    public static class Validator
    {
        public static Boolean Required(string username, string password1, string password2, string firstName, string lastName, string dataOfBirth)
        {
            if (username == "")
            {
                MessageBox.Show("Please fill in the username");
                return false;
            }
            if (password1 == "")
            {
                MessageBox.Show("Please fill in the password");
                return false;
            }
            if (password2 == "")
            {
                MessageBox.Show("Please re-enter your password");
                return false;
            }
            if (firstName == "")
            {
                MessageBox.Show("Please fill your first name");
                return false;
            }
            if (lastName == "")
            {
                MessageBox.Show("Please fill your last name");
                return false;
            }
            if (dataOfBirth == "")
            {
                MessageBox.Show("Please fill in your date of birth");
                return false;
            }
            return true;
        }

        public static Boolean PasswordMatch(string password1, string password2)
        {
            if (password1 != password2)
            {
                MessageBox.Show("Two passwords don't match!");
                return false;
            }
            return true;
        }
        public static Boolean PasswordLength(string password, int min, int max)
        {
            if (password.Length < min)
            {
                MessageBox.Show($"Passwords must be at least {min} characters in length.");
                return false;
            }
            if (password.Length > max)
            {
                MessageBox.Show($"Passwords must less than {max} characters in length.");
                return false;
            }
            return true;
        }
        public static Boolean UsernameExisted(string username, string[] usernames)
        {
            if (usernames.Contains(username))
            {
                MessageBox.Show("The username is already existed");
                return false;
            }
            return true;
        }
    }
}
