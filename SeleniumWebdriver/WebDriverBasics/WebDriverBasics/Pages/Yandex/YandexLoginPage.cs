using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace WebDriverBasics
{

    class YandexLoginPage : BasePage
    {
        public IWebElement LoginIntoButton => Driver.FindElement(By.XPath("//a[contains(@class,'button desk-notif-card__login-enter-expanded')]"));
        public IWebElement LoginField => Driver.FindElement(By.XPath("//input[@id = 'passp-field-login']"));
        public IWebElement PasswordField => Driver.FindElement(By.XPath("//input[@id = 'passp-field-passwd']"));
        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//button[@type = 'submit']"));
        public string loginPageUrl = "https://yandex.by/";

        public YandexLoginPage(IWebDriver driver) : base(driver) { }

        public void GoToPage()
        {
            Driver.Navigate().GoToUrl(loginPageUrl);
        }

        public YandexLoginPage TypeUsername(String username)
        {
            new Actions(Driver).SendKeys(LoginField, username).Build().Perform();
            //LoginField.SendKeys(username);

            return this;
        }

        public YandexLoginPage TypePassword(String password)
        {
            PasswordField.SendKeys(password);

            return this;
        }

        public YandexMainPage SubmitLogin()
        {
            SubmitButton.Click();

            return new YandexMainPage(Driver);
        }

        public YandexLoginPage StartLogin()
        {
            new Actions(Driver).Click(LoginIntoButton).Build().Perform();
            //LoginIntoButton.Click();

            return this;
        }

        public YandexMainPage LoginAs(User user)
        {
            StartLogin();
            TypeUsername(user.Username);
            SubmitLogin();
            TypePassword(user.Password);

            return SubmitLogin();
        }
    }
}
