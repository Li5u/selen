using System.Linq;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace WebDriverBasics
{
    class YandexMainPage : BasePage
    {
        public IWebElement UserMenuButton => Driver.FindElement(By.XPath("//div[contains(@class, 'ns-view-head-user')]"));
        public IWebElement LogOffButton => Driver.FindElement(By.XPath("//a[(@data-metric = 'Sign out of Yandex services')]"));
        public IWebElement SendLetterButton => Driver.FindElement(By.XPath("//span[@class = 'mail-ComposeButton-Text']"));
        public IWebElement ShowDraftsButton => Driver.FindElement(By.XPath("//a[@href = '#draft']"));
        public IWebElement ShowSendedLettersButton => Driver.FindElement(By.XPath("//a[@href = '#sent']"));

        public string lettersLocator = "//div[contains(@class, 'ns-view-messages-item-box')]";

        public YandexMainPage(IWebDriver driver) : base(driver) { }

        public YandexSendLetterPage ClickSendMessageButton ()
        {
            js.ExecuteScript("arguments[0].style.backgroundColor = '" + "yellow" + "'", SendLetterButton);
            SendLetterButton.Click();

            return new YandexSendLetterPage(Driver);
        }

        public YandexMainPage ShowDrafts()
        {
            ShowDraftsButton.Click();
            Driver.Navigate().Refresh();

            return this;
        }

        public YandexMainPage ShowSendedLetters()
        {
            ShowSendedLettersButton.Click();
            Driver.Navigate().Refresh();

            return this;
        }

        public YandexSendLetterPage OpenLatestLetter()
        {
            var lettersInFolder = GetLettersFromFolder();
            lettersInFolder[0].Click();

            return new YandexSendLetterPage(Driver);
        }

        public List<IWebElement> GetLettersFromFolder()
        {
            return Driver.FindElements(By.XPath(lettersLocator)).ToList();
        }

        public YandexLoginPage LogOff()
        {
            UserMenuButton.Click();
            LogOffButton.Click();

            return new YandexLoginPage(Driver);
        }
    }
}
