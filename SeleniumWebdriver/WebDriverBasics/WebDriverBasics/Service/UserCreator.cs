using System.Configuration;

namespace WebDriverBasics
{
    class UserCreator
    {
        public static string username = ConfigurationSettings.AppSettings["Username"];
        public static string password = ConfigurationSettings.AppSettings["Password"];

        public static User WithCredentialFromProperty()
        {
            return new User(username, password);
        }

        public static User WithEmptyUsername()
        {
            return new User(username: string.Empty, password);
        }
        public static User WithEmptyPassword()
        {
            return new User(username, password: string.Empty);
        }
    }
}
