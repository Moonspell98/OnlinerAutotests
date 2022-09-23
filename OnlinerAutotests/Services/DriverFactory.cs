using AngleSharp.Css;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace PageObject.Services
{
    public class DriverFactory
    {
        [ThreadStatic] public static IWebDriver Driver = GetChromeDriver();

        private static IWebDriver GetChromeDriver()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--incognito");
            chromeOptions.AddArguments("--disable-gpu");
            chromeOptions.AddArguments("--disable-extensions");
            //chromeOptions.AddArguments("--headless");
            
            chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
            chromeOptions.SetLoggingPreference(LogType.Driver, LogLevel.All);

            new DriverManager().SetUpDriver(new ChromeConfig());
            ChromeDriver chromeDriver = new ChromeDriver(chromeOptions);
            chromeDriver.Manage().Window.Maximize();
            return chromeDriver;
        }
    }
}