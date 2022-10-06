using System.Net;
using OnlinerAutotests.Services;
using OpenQA.Selenium;

namespace OnlinerAutotests.Pages;

public class ProductPage : BasePage
{
    private const string EndPoint = "/tv";

    private readonly By AddToCompareCheckBoxLocator = By.XPath("//*[@id='product-compare-control']");
    private readonly By CompareButtonLocator = By.XPath("//*[@class='compare-button compare-button_visible']");
    private readonly By SellersOffersLinkLocator = By.XPath("//*[@class='js-sub-nav-link']//*[text()='Предложения продавцов']");
    private readonly By CitySubmitButtonLocator = By.XPath("//*[normalize-space(text())='Ваш населенный пункт —']/following-sibling::*//*[contains(@class, 'button-style_another')]");
    
    public ProductPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl("catalog." + ConfiguratorService.BaseUrl + EndPoint);
    }

    public void ClickOnCompareCheckBox() => AddToCompareCheckBox.Click();
    public void NavigateOnPreviousPage() => Driver.Navigate().Back();
    public void ClickOnCompareButton() => CompareButton.Click();
    public ProductSellersPage NavigateOnProductSellersPage()
    {
        SellersOffersLink.Click();
        return new ProductSellersPage(Driver, false);
    }
    public void SubmitCity() => CitySubmitButton.Click();
    
    public IWebElement AddToCompareCheckBox => WaitService.WaitElementIsVisible(AddToCompareCheckBoxLocator);
    public IWebElement CompareButton => WaitService.WaitElementIsVisible(CompareButtonLocator);
    public IWebElement SellersOffersLink => WaitService.WaitElementIsVisible(SellersOffersLinkLocator);
    public IWebElement CitySubmitButton => WaitService.WaitElementIsVisible(CitySubmitButtonLocator);
}