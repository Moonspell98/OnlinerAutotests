using OnlinerAutotests.Services;
using OpenQA.Selenium;

namespace OnlinerAutotests.Pages;

public abstract class BasePage
{
    private const int WaitForPageLoadingTime = 10;
    [ThreadStatic] private static IWebDriver? _driver;
    private static WaitService _waitService;

    protected abstract void OpenPage();

    protected BasePage(IWebDriver driver, bool openPageByUrl)
    {
        Driver = driver;
        _waitService = new WaitService(Driver);
        if (openPageByUrl)
        {
            OpenPage();
        }
    }

    public static IWebDriver Driver
    {
        get => _driver;
        set => _driver = value ?? throw new ArgumentNullException(nameof(value));
    }

    public static WaitService WaitService
    {
        get => _waitService;
    }
}