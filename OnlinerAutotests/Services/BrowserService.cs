using OnlinerAutotests.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace PageObject.Services;

public class BrowserService
{
    private IWebDriver _driver;

    public IWebDriver Driver
    {
        get => _driver;
        set => _driver = value;
    }

    public BrowserService()
    {
        Driver = ConfiguratorService.BrowserType.ToLower() switch
        {
            "chrome" => new ChromeDriver(),
            "firefox" => new FirefoxDriver(),
            _ => Driver
        };
        
        //Driver.Manage().Window.Maximize();
        Driver.Manage().Cookies.DeleteAllCookies();
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
    }
}