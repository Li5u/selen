namespace WebDriverBasics
{
    class User
    {
        private string _username;
        private string _password;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public override string ToString()
        {
            return "User{" +
                "username='" + Username + '\'' +
                ", password='" + Password + '\'' +
                '}';
        }
    }
}
