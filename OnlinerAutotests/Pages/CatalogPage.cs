using System.Collections.ObjectModel;
using OnlinerAutotests.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace OnlinerAutotests.Pages;

public class CatalogPage : BasePage
{
    public static Actions Actions = new Actions(Driver);
    private const string EndPoint = "catalog.";

    private readonly By PageTitleLocator = By.XPath("//*[@class='catalog-navigation__title']/self::div[text()='Каталог']");
    private readonly By CategoriesLocator = By.XPath("//*[@class='catalog-navigation-classifier__item ']");
    private readonly By ElectronicsCategoryLocator = By.XPath("//*[@class='catalog-navigation-classifier__item-title-wrapper' and text()='Электроника']");
    private readonly By TvAndVideoSubCategoryLocator = By.XPath("//*[@class='catalog-navigation-list__aside-title' and contains(text(), 'Телевидение')]");
    private readonly By TvCatalogLinkLocator = By.XPath("//*[@href='https://catalog.onliner.by/tv']");
    
    public CatalogPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(ConfiguratorService.BaseUrl.Insert(ConfiguratorService.BaseUrl.IndexOf('.'), EndPoint));
    }

    public IWebElement PageTitle => WaitService.WaitElementIsVisible(PageTitleLocator);
    public IWebElement ElectronicsCategory => WaitService.WaitElementIsVisible(ElectronicsCategoryLocator);
    public IWebElement TvAndVideoSubCategory => WaitService.WaitElementIsVisible(TvAndVideoSubCategoryLocator);
    public IWebElement TvCatalogLink => WaitService.WaitElementIsVisible(TvCatalogLinkLocator);
    public ReadOnlyCollection<IWebElement> Categories => WaitService.WaitElementsAreVisible(CategoriesLocator);

    public void ClickOnElectronicsCategory() => ElectronicsCategory.Click();
    public void HoverOnTvAndVideoSubCategory() => Actions.MoveToElement(TvAndVideoSubCategory).Perform();
    public void ClickOnTvCatalogLink() => TvCatalogLink.Click();
}