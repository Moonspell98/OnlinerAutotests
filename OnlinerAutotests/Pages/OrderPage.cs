using OnlinerAutotests.Services;
using OpenQA.Selenium;

namespace OnlinerAutotests.Pages;

public class OrderPage : BasePage
{
    private readonly By OrderProductTitleLocator = By.XPath("//*[@class='cart-form__total-body']/div[1]/div[2]//*[contains(@class, 'part_1')]");

    private readonly By OrderProductPriceLocator = By.XPath("//*[@class='cart-form__total-body']/div[1]/div[2]//*[contains(@class, 'part_2')]/div");

    private readonly By OrderCityFieldLocator = By.XPath("//*[contains(@class, 'auth-form__row auth-form__row_condensed-alter')]//*[@placeholder='Укажите населенный пункт']");

    public OrderPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl("catalog." + ConfiguratorService.BaseUrl);
    }

    public IWebElement OrderProductTitle => WaitService.WaitElementIsVisible(OrderProductTitleLocator);
    public IWebElement OrderProductPrice => WaitService.WaitElementIsVisible(OrderProductPriceLocator);
    public IWebElement OrderCityField => WaitService.WaitElementIsVisible(OrderCityFieldLocator);

    public bool IsOrderProductTitleContains(string addedProductTitle)
    {
        return addedProductTitle.Contains(OrderProductTitle.Text);
    }
    
    public bool IsOrderProductPriceEqual(string addedProductPrice)
    {
        return addedProductPrice.Contains(OrderProductPrice.Text);
    }

    public bool IsAutofilledCityEqual(string addedProductTitle)
    {
        return OrderCityField.Text == addedProductTitle;
    }
}