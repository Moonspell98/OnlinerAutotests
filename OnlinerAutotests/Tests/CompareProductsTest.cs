using OnlinerAutotests.Pages;

namespace OnlinerAutotests.Tests;

public class CompareProductsTest : BaseTest
{
    [Test]
    public void CompareProducts()
    {
        MainPage mainPage = new MainPage(Driver, true);
        mainPage.ClickOnCatalogLink();
        CatalogPage catalogPage = new CatalogPage(Driver, false);
        catalogPage.ClickOnElectronicsCategory();
        catalogPage.HoverOnTvAndVideoSubCategory();
        catalogPage.ClickOnTvCatalogLink();
        Thread.Sleep(TimeSpan.FromSeconds(3));
    }
    
}