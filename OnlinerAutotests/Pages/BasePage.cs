using OpenQA.Selenium;

namespace OnlinerAutotests.Pages;

public abstract class BasePage
{
    private const int WaitForPageLoadingTime = 10;
    [ThreadStatic] private static IWebDriver _driver;

    protected abstract void OpenPage();

    protected abstract bool IsPageOpened();

    protected BasePage(IWebDriver driver, bool openPageByUrl)
    {
        Driver = driver;
        if (openPageByUrl)
        {
            OpenPage();
        }
    }

    private void WaitForOpen()
    {
        var secondsCount = 0;
        var isPageOpenedIndicator = IsPageOpened();

        while (!isPageOpenedIndicator && secondsCount < (WaitForPageLoadingTime))
        {
            secondsCount++;
            isPageOpenedIndicator = IsPageOpened();
        }

        if (!isPageOpenedIndicator)
        {
            throw new AssertionException("Page was not opened");
        }
    }

    public static IWebDriver Driver
    {
        get => _driver;
        set => _driver = value ?? throw new ArgumentNullException(nameof(value));
    }
}