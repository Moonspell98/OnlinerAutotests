using System.Collections.ObjectModel;
using System.Net;
using OnlinerAutotests.Services;
using OpenQA.Selenium;

namespace OnlinerAutotests.Pages;

public class ComparePage : BasePage
{
    private string EndPoint = "/compare/";

    private readonly By FirstProductCellTitleLocator = By.XPath("(//*[@class='product-table__row product-table__row_header product-table__row_top']//*[@class='product-table__cell'])[1]//*[@class='product-summary__caption']");
    private readonly By SecondProductCellTitleLocator = By.XPath("(//*[@class='product-table__row product-table__row_header product-table__row_top']//*[@class='product-table__cell'])[2]//*[@class='product-summary__caption']");
    private readonly By ProductsCellsTitlesLocator =
        By.XPath(
            "//*[@class='product-table__row product-table__row_header product-table__row_top']//*[@class='product-table__cell']//*[@class='product-summary__caption']");
    private readonly By CompareRowsLocator = By.XPath("//*[@class='product-table__row product-table__row_parameter ']"); 
    
    public ComparePage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl("catalog." + ConfiguratorService.BaseUrl + EndPoint);
    }

    public IWebElement FirstProductCellTitle => WaitService.WaitElementIsVisible(FirstProductCellTitleLocator);
    public IWebElement SecondProductCellTitle => WaitService.WaitElementIsVisible(SecondProductCellTitleLocator);
    public ReadOnlyCollection<IWebElement> ProductsCellsTitles => WaitService.WaitElementsAreVisible(ProductsCellsTitlesLocator);
    public ReadOnlyCollection<IWebElement> CompareRows => WaitService.WaitElementsAreVisible(CompareRowsLocator);
}