using System.Net;
using OnlinerAutotests.Services;
using OpenQA.Selenium;

namespace OnlinerAutotests.Pages;

public class CartPage : BasePage
{
    private readonly By ProductTitleLocator = By.XPath("//*[@class='cart-form__offers-part cart-form__offers-part_data']//a");
    private readonly By ProductPriceLocator = By.XPath("//*[contains(@class, 'cart-form__offers-part_price_specific')]//*[contains(@class, 'cart-form__description_primary')]");
    private readonly By ProductsCountLocator = By.XPath("//*[contains(@class, 'cart-form__offers-part_count')]//input");
    private readonly By NavigateToOrderPageButtonLocator = By.XPath("//*[contains(@class, 'cart-form__button button-style_primary')]");

    public CartPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl("catalog." + ConfiguratorService.BaseUrl);
    }

    public IWebElement ProductTitle => WaitService.WaitElementIsVisible(ProductTitleLocator);
    public IWebElement ProductPrice => WaitService.WaitElementIsVisible(ProductPriceLocator);
    public IWebElement ProductsCount => WaitService.WaitElementIsVisible(ProductsCountLocator);
    public IWebElement NavigateToOrderPageButton => WaitService.WaitElementIsVisible(NavigateToOrderPageButtonLocator);

    public string GetProductsCount() => ProductsCount.GetDomProperty("_value");
    
    public bool IsProductTitleEqual(string addedProductTitle)
    {
        return ProductTitle.Text == addedProductTitle;
    }
    
    public bool IsProductPriceEqual(string addedProductPrice)
    {
        return ProductPrice.Text.Equals(addedProductPrice);
    }
    
    public bool IsProductsCountEqual(string addedProductsCount)
    {
        return ProductsCount.GetDomProperty("_value") == addedProductsCount;
    }
    
    public OrderPage NavigateToOrderPage()
    {
        NavigateToOrderPageButton.Click();
        return new OrderPage(Driver, false);
    }
}