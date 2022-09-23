using OnlinerAutotests.Services;
using OpenQA.Selenium;

namespace OnlinerAutotests.Pages;

public class MainPage : BasePage
{
    private const string EndPoint = "";

    private static readonly By LoginButtonLocator = By.XPath("//*[@class = 'auth-bar__item auth-bar__item--text']");
    
    public MainPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(ConfiguratorService.BaseUrl);
    }

    protected override bool IsPageOpened()
    {
        try
        {
            return LoginButton.Displayed;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void ClickOnLoginButton() => LoginButton.Click();

    public IWebElement LoginButton => WaitService.WaitElementIsVisible(LoginButtonLocator);

}