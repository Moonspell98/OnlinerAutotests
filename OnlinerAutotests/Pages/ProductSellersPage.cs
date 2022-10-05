using System.Net;
using OnlinerAutotests.Services;
using OpenQA.Selenium;

namespace OnlinerAutotests.Pages;

public class ProductSellersPage : BasePage
{
    private readonly By AddToCartFirstSellerButtonLocator = By.XPath("((//*[@class='offers-list__item'])[1]//*[normalize-space()='В корзину'])[2]");
    private readonly By NavigateToCartButtonLocator = By.XPath("//*[normalize-space(@class)='button-style button-style_another button-style_base-alter product-recommended__button']");
    private readonly By FirstSellerPriceLocator = By.XPath("(//*[@class='offers-list__part offers-list__part_price'])[1]/div[1]/div");
    
    public ProductSellersPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl("catalog." + ConfiguratorService.BaseUrl);
    }
    
    public IWebElement AddToCartFirstSellerButton => WaitService.WaitElementIsVisible(AddToCartFirstSellerButtonLocator);
    public IWebElement NavigateToCartButton => WaitService.WaitElementIsVisible(NavigateToCartButtonLocator);
    public IWebElement FirstSellerPrice => WaitService.WaitElementIsVisible(FirstSellerPriceLocator);
    
    public void AddToCartProductFromFirstSeller() => AddToCartFirstSellerButton.Click();
    public void NavigateToCart() => NavigateToCartButton.Click();
}