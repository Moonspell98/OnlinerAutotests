using OnlinerAutotests.Services;
using OpenQA.Selenium;

namespace OnlinerAutotests.Pages;

public class MainPage : BasePage
{
    private const string EndPoint = "";

    private static readonly By LoginButtonLocator = By.XPath("//*[@class = 'auth-bar__item auth-bar__item--text']");
    private static readonly By UserIconLocator = By.XPath("//*[@class = 'b-top-profile__image js-header-user-avatar']");
    private static readonly By UserNameLocator = By.XPath("//*[@class = 'b-top-profile__name']/a");
    private static readonly By ProfileArrowLocator = By.XPath("//*[@class = 'b-top-profile__item b-top-profile__item_arrow']");
    
    public MainPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(ConfiguratorService.BaseUrl);
    }
    
    public void ClickOnLoginButton() => LoginButton.Click();
    public void ClickOnProfileArrow() => ProfileArrow.Click();

    public IWebElement LoginButton => WaitService.WaitElementIsVisible(LoginButtonLocator);
    public IWebElement UserIcon => WaitService.WaitElementIsVisible(UserIconLocator);
    public IWebElement ProfileArrow => WaitService.WaitElementIsVisible(ProfileArrowLocator); 
    public IWebElement UserName => WaitService.WaitElementIsVisible(UserNameLocator);
}