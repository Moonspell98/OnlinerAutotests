using OnlinerAutotests.Services;
using OpenQA.Selenium;

namespace OnlinerAutotests.Pages;

public class TvCatalogPage : BasePage
{
    private const string EndPoint = "/tv";
    
    private readonly By FirstProductMainTitleLocator =
        By.XPath("((//*[@class='schema-product__group'])[1]//*[@class='schema-product__title'])[1]");
    private readonly By SecondProductMainTitleLocator =
        By.XPath("((//*[@class='schema-product__group'])[2]//*[@class='schema-product__title'])[1]");
    
    public TvCatalogPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl("catalog." + ConfiguratorService.BaseUrl + EndPoint);
    }

    public void ClickOnProductTitle(IWebElement productTitle) => productTitle.Click();
    
    public IWebElement FirstProduct => WaitService.WaitElementIsVisible(FirstProductMainTitleLocator);
    public IWebElement SecondProduct => WaitService.WaitElementIsVisible(SecondProductMainTitleLocator);
}