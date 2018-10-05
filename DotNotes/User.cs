using System;

namespace DotNotes
{
    public enum UserType
    {
        View,
        Edit
    }
    
    public class User
    {

        private string _username;
//        private string hashedPassword;
        private string _password;
        private string _firstName;
        private string _lastName;

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        private UserType type;

        public string Username { get => _username; set => _username = value; }
//        public string HashedPassword { get => hashedPassword; set => hashedPassword = value; }
        public string Password { get => _password; set => _password = value; }
        public string DateOfBirth { get; set; }

        internal UserType Type { get => type; set => type = value; }

        public User(string username, string password, string firstName, string lastName, string dob, UserType type)
        {
            this._username = username ?? throw new ArgumentNullException(nameof(username));
            //            this.hashedPassword = hashedPassword ?? throw new ArgumentNullException(nameof(hashedPassword));
            _password = password ?? throw new ArgumentNullException(nameof(password));
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dob;
            this.type = type;
        }

        public string Print()
        {
            string userType = type == UserType.Edit ? "Edit" : "View";
            return $"{_username},{_password},{userType},{_firstName},{_lastName},{DateOfBirth}";
        }
        
    }
}