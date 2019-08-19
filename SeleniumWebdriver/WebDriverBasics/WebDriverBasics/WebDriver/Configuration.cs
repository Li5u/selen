using System.Configuration;

namespace WebDriverBasics
{
    public class Configuration
    {
        public static string GetEnviromentVar(string var, string defaultValue)
        {
            return ConfigurationSettings.AppSettings[var] ?? defaultValue;
        }

        public static string ElementTimeout => GetEnviromentVar("ElementTimeout", "30");

        public static string Browser => GetEnviromentVar("Browser", "Chrome");

        public static string StartUrl => GetEnviromentVar("StartUrl", "https://yandex.by/");
    }
}