using OnlinerAutotests.Popups;
using OnlinerAutotests.Services;
using OpenQA.Selenium;

namespace OnlinerAutotests.Pages;

public class MainPage : BasePage
{
    private const string EndPoint = "";

    private static readonly By LoginButtonLocator = By.XPath("//*[@class = 'auth-bar__item auth-bar__item--text']");
    private static readonly By UserIconLocator = By.XPath("//*[@class = 'b-top-profile__image js-header-user-avatar']");
    private static readonly By UserNameLocator = By.XPath("//*[@class = 'b-top-profile__name']/a");
    private static readonly By CatalogLinkLocator = By.XPath("//*[@class='b-main-navigation']//*[@href='https://catalog.onliner.by']");
    private static readonly By ProfileArrowLocator = By.XPath("//*[@class = 'b-top-profile__item b-top-profile__item_arrow']");
    private static readonly By SearchFieldLocator = By.XPath("//*[@class='fast-search__input']");

    public MainPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    public MainPage(IWebDriver driver, bool openPageByUrl, bool fastLogIn) : base(driver, openPageByUrl)
    {
        if (fastLogIn)
        {
            ClickOnLoginButton();
            LoginPopup loginPopup = new LoginPopup(Driver,"//*[@id='auth-container']");
            loginPopup.EnterEmail("robert.minear365@gmail.com");
            loginPopup.EnterPassword("casm9hir8LOT@klap\"");
            loginPopup.Login();
            LoginCaptchaPopup loginCaptchaPopup = new LoginCaptchaPopup(Driver, "//*[@id='rc-anchor-container']");
            loginCaptchaPopup.SwitchOnCaptchaFrame();
            loginCaptchaPopup.PressOnCaptchaCheckBox();
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }
        else
        {
            OpenPage();
        }
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(ConfiguratorService.BaseUrl);
    }
    
    public void ClickOnLoginButton() => LoginButton.Click();
    public void ClickOnProfileArrow() => ProfileArrow.Click();
    public void FillIntoSearchField(string searchValue) => SearchField.SendKeys(searchValue);
    public void ClickOnCatalogLink() => CatalogLink.Click();

    public IWebElement LoginButton => WaitService.WaitElementIsVisible(LoginButtonLocator);
    public IWebElement UserIcon => WaitService.WaitElementIsVisible(UserIconLocator);
    public IWebElement ProfileArrow => WaitService.WaitElementIsVisible(ProfileArrowLocator); 
    public IWebElement UserName => WaitService.WaitElementIsVisible(UserNameLocator);
    public IWebElement SearchField => WaitService.WaitElementIsVisible(SearchFieldLocator);
    public IWebElement CatalogLink => WaitService.WaitElementIsVisible(CatalogLinkLocator);
}