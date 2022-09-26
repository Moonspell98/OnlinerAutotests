using OpenQA.Selenium;
using PageObject.Services;

namespace OnlinerAutotests.Tests;

public class BaseTest
{
    protected IWebDriver Driver;
    private DriverFactory DriverFactory = new DriverFactory();
    
    [SetUp]
    public void SetUp()
    {
        Driver = DriverFactory.GetChromeDriver();
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Close();
        Driver.Quit();
    }
}