using System.Net;
using OnlinerAutotests.Services;
using OpenQA.Selenium;

namespace OnlinerAutotests.Pages;

public class ProductSellersPage : BasePage
{
    private readonly By AddToCartFirstSellerButtonLocator = By.XPath("(//*[contains(@class, 'offers-list__item')])[1]//*[contains(@class, 'offers-list__part_action')]//*[contains(@class, 'offers-list__button_cart')]");
    private readonly By NavigateToCartButtonLocator = By.XPath("//*[@class='product-recommended__sidebar-overflow']//*[contains(@class, 'button-style_another')]");
    private readonly By FirstSellerPriceLocator = By.XPath("(//*[contains(@class, 'offers-list__part_price')])[1]//*[contains(@class, 'offers-list__description_nodecor')]");
    
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

    public string GetFirstSellerPrice() => FirstSellerPrice.Text; 
    public void AddToCartProductFromFirstSeller() => AddToCartFirstSellerButton.Click();

    public CartPage NavigateToCart()
    {
        NavigateToCartButton.Click();
        return new CartPage(Driver, false);
    }
}