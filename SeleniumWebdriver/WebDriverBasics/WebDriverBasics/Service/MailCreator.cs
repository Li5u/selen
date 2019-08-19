using System.Configuration;

namespace WebDriverBasics
{
    class MailCreator
    {
        public static string address = ConfigurationSettings.AppSettings["Address"];
        public static string subject = ConfigurationSettings.AppSettings["Subject"];
        public static string text = ConfigurationSettings.AppSettings["Text"];

        public static Mail WithFieldsFromProperty()
        {
            return new Mail(address, subject, text);
        }
    }
}
