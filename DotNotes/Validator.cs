using System;
using System.Linq;
using System.Windows.Forms;

namespace DotNotes
{
    public static class Validator
    {
        private static string usernameNotExistedError = "The username is not found.";
        private static string usernameMissingError = "Please fill in the username";
        private static string passwordMissingError = "Please fill in the password";
        private static string reEnterpasswordMissingError = "Please re-enter your password";
        private static string firstNameMissingError = "Please fill your first name";
        private static string lastNameMissingError = "Please fill your last name";
        private static string dateOfBirthMissingError = "Please fill in your date of birth";
        public static string wrongPasswordError = "The password is wrong. Please try again.";

        public static Boolean RequiredAll(string username, string password1, string password2, string firstName, string lastName, string dataOfBirth)
        {
            if(!RequireUsername(username))
                return false;
            if (password1 == "")
            {
                MessageBox.Show(passwordMissingError);
                return false;
            }
            if (password2 == "")
            {
                MessageBox.Show(reEnterpasswordMissingError);
                return false;
            }
            if (firstName == "")
            {
                MessageBox.Show(firstNameMissingError);
                return false;
            }
            if (lastName == "")
            {
                MessageBox.Show(lastNameMissingError);
                return false;
            }
            if (dataOfBirth == "")
            {
                MessageBox.Show(dateOfBirthMissingError);
                return false;
            }
            return true;
        }

        public static Boolean RequireUsername(string username)
        {
            if (username == "")
            {
                MessageBox.Show(usernameMissingError);
                return false;
            }
            return true;
        }

        public static Boolean RequirePassword(string password)
        {
            if (password == "")
            {
                MessageBox.Show(passwordMissingError);
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

        public static Boolean PasswordLengthLimit(string password, int min, int max)
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

        public static Boolean UsernameDuplicate(string username, string[] usernames)
        {
            if (usernames.Contains(username))
            {
                MessageBox.Show("The username is already existed");
                return false;
            }
            return true;
        }

        public static Boolean UsernameExisted(string username, string[] usernames)
        {
            if (!usernames.Contains(username))
            {
                MessageBox.Show(usernameNotExistedError);
                return false;
            }
            return true;
        }
    }
}
