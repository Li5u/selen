using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;

namespace WebDriverBasics
{
    class TestListener
    {
        protected IWebDriver Driver;

        protected void UITest(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                var failTime = DateTime.Now.ToString(@"MM-dd-yyyy HH-mm-ss");
                var screenshot = Browser.GetDriver().TakeScreenshot();
                screenshot.SaveAsFile($@"{AppDomain.CurrentDomain.BaseDirectory}\..\..\Screenshots\{failTime}.jpg", ScreenshotImageFormat.Jpeg);

                throw ex;
            }
        }
    }
}
