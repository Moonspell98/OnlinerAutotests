using OpenQA.Selenium;
using PageObject.Services;

namespace OnlinerAutotests.Tests;

public class BaseTest
{
    protected static IWebDriver Driver = DriverFactory.Driver;


    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }
}