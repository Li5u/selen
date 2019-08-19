using System;
using OpenQA.Selenium;

namespace WebDriverBasics
{
    class YandexSendLetterPage : BasePage
    {
        public IWebElement AddressField => Driver.FindElement(By.XPath("//div[@name = 'to']"));
        public IWebElement SubjectField => Driver.FindElement(By.XPath("//input[contains(@class, 'mail-Compose-Field-Input-Controller')]"));
        public IWebElement TextField => Driver.FindElement(By.XPath("//div[contains(@class, 'cke_enable_context_menu')]"));
        public IWebElement SendLetterButton => Driver.FindElement(By.XPath("//button[contains(@class, 'js-send-button')]"));
        public IWebElement CloseButton => Driver.FindElement(By.XPath("//div[contains(@class, 'ns-view-compose-cancel-button')]"));
        public IWebElement SaveDraftButton => Driver.FindElement(By.XPath("//button[@data-action = 'save']"));

        public YandexSendLetterPage(IWebDriver driver) : base(driver) { }

        public YandexSendLetterPage TypeAddress(String address)
        {
            AddressField.SendKeys(address);

            return this;
        }

        public YandexSendLetterPage TypeSubject(String subject)
        {
            SubjectField.SendKeys(subject);

            return this;
        }

        public YandexSendLetterPage TypeTextMessage(String text)
        {
            TextField.SendKeys(text);

            return this;
        }

        public YandexMainPage ClickSendLetterButton()
        {
            SendLetterButton.Click();

            return new YandexMainPage(Driver);
        }


        public YandexMainPage SaveAsDraft(Mail mail)
        {
            TypeAddress(mail.Address);
            TypeSubject(mail.Subject);
            TypeTextMessage(mail.Text);
            CloseButton.Click();
            SaveDraftButton.Click();

            return new YandexMainPage(Driver);
        }
    }
}
