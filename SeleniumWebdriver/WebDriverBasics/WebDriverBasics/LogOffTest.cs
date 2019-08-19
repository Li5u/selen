using NUnit.Framework;
using TechTalk.SpecFlow;

namespace WebDriverBasics
{
    [Binding]
    class LogOffSteps : BaseTest
    {
        YandexMainPage yandexMainPage;

        private readonly string _loginPageUrl = "https://yandex.by/";

        [Given(@"I login with valid (.*) and (.*)")]
        public void Login(string username, string password)
        {
            yandexMainPage = LoginPage.LoginAs(testUser);
        }

        [When(@"I press log off button")]
        public void LogOff()
        {
            LoginPage = yandexMainPage.LogOff();
        }

        [Then(@"I on yandex login page")]
        public void VerifItIsLoginPage()
        {
            Assert.AreEqual(_loginPageUrl, LoginPage.GetPageURL());
        }
    }
}
