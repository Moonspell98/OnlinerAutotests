using System.Collections.ObjectModel;
using OnlinerAutotests.Services;
using OpenQA.Selenium;

namespace OnlinerAutotests.Pages;

public class CatalogPage : BasePage
{
    private const string EndPoint = "catalog.";

    private readonly By PageTitleLocator = By.XPath("//*[@class='catalog-navigation__title']/self::div[text()='Каталог']");
    private readonly By CategoriesLocator = By.XPath("//*[@class='catalog-navigation-classifier__item ']");
    
    

    public CatalogPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(ConfiguratorService.BaseUrl.Insert(ConfiguratorService.BaseUrl.IndexOf('.'), EndPoint));
    }

    public IWebElement PageTitle => WaitService.WaitElementIsVisible(PageTitleLocator);
    public ReadOnlyCollection<IWebElement> Categories => WaitService.WaitElementsAreVisible(CategoriesLocator);
}