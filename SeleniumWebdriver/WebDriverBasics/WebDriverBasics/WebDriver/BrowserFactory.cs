﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace WebDriverBasics
{
    class BrowserFactory
    {
        public enum BrowserType
        {
            Chrome,
            Firefox,
            IEedge,
            phantomJs,
            remoteFirefox,
            remoteChrome
        }

        public static IWebDriver GetDriver(BrowserType type, int timeOutSec)
        {
            IWebDriver driver = null;

            switch (type)
            {
                case BrowserType.Chrome:
                    {
                        //new DriverManager().SetUpDriver(new ChromeConfig());
                        var service = ChromeDriverService.CreateDefaultService();
                        var option = new ChromeOptions();
                        option.AddArgument("disable-infobars");
                        driver = new ChromeDriver(service, option, TimeSpan.FromSeconds(timeOutSec));
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                        break;
                    }
                case BrowserType.Firefox:
                    {
                        //new DriverManager().SetUpDriver(new FirefoxConfig());
                        var service = FirefoxDriverService.CreateDefaultService();
                        var options = new FirefoxOptions();
                        driver = new FirefoxDriver(service, options, TimeSpan.FromSeconds(timeOutSec));
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                        break;
                    }
                case BrowserType.remoteFirefox:
                    {
                        var cability = new DesiredCapabilities();
                        cability.SetCapability(CapabilityType.BrowserName, "firefox");
                        cability.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Any));
                        driver = new RemoteWebDriver(new Uri("http://localhost:5566/wd/hub"), cability);
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                        break;
                    }
                case BrowserType.remoteChrome:
                    {
                        var option = new ChromeOptions();
                        option.AddArgument("disable-infobars");
                        option.AddArgument("--no-sandbox");
                        driver = new RemoteWebDriver(new Uri("http://localhost:5566/wd/hub"), option.ToCapabilities());
                        break;
                    }
            }
            return driver;
        }
    }
}
