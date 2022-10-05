using OnlinerAutotests.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace OnlinerAutotests.Pages;

public abstract class BasePage
{
    private const int WaitForPageLoadingTime = 10;
    [ThreadStatic] private static IWebDriver? _driver;
    private static WaitService _waitService;
    
    private readonly By CartButtonLocator = By.XPath("//*[@class='auth-bar__item auth-bar__item--cart']");

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

    public IWebElement CartButton => WaitService.WaitElementIsVisible(CartButtonLocator);

    public void ClickOnCartButton() => CartButton.Click();
}