using OnlinerAutotests.Pages;

namespace OnlinerAutotests.Tests;

public class CategoriesPageTest : BaseTest
{
    [Test]
    public void OpenCategoriesPage()
    {
        MainPage mainPage = new MainPage(Driver, true);
        mainPage.ClickOnCatalogLink();
        CatalogPage catalogPage = new CatalogPage(Driver, false);
        Assert.IsTrue(catalogPage.PageTitle.Displayed);
        foreach (var category in catalogPage.Categories)
        {
            Assert.IsTrue(category.Displayed);
        }
        
    }
}