using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace WebDriverBasics
{
    [Binding]
    class BaseTest : TestListener
    {
        [SetUp]
        [BeforeTestRun]
        public static void StartBrowser()
        {
            Browser = Browser.Instance;
            Browser.WindowMaximise();
            Browser.NavigateTo(Configuration.StartUrl);
            LoginPage = new YandexLoginPage(Browser.GetDriver());
            testUser = UserCreator.WithCredentialFromProperty();
            testMail = MailCreator.WithFieldsFromProperty();
        }

        [TearDown]
        [AfterTestRun]
        public static void CloseBrowser()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var testName = TestContext.CurrentContext.Test.Name;
                var failTime = DateTime.Now.ToString(@"MM-dd-yyyy HH-mm-ss");
                var screenshot = Browser.GetDriver().TakeScreenshot();
                screenshot.SaveAsFile($@"{AppDomain.CurrentDomain.BaseDirectory}\..\..\Screenshots\{testName} {failTime}.jpg",
                    ScreenshotImageFormat.Jpeg);
            }
            Browser.Quit();
        }

        protected static Browser Browser = Browser.Instance;
        protected static YandexLoginPage LoginPage { get; set; }
        protected static User testUser;
        protected static Mail testMail;

    }
}
