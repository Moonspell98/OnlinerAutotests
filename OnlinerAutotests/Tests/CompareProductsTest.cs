using OnlinerAutotests.Pages;
using OpenQA.Selenium;

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
        catalogPage.HoverOnSubCategory(catalogPage.TvAndVideoSubCategory);
        catalogPage.ClickOnCatalogLink(catalogPage.TvCatalogLink);
        
        CategoryCatalogPage categoryCatalogPage = new CategoryCatalogPage(Driver, false);
        string firstProductTitle = categoryCatalogPage.FirstProduct.Text;
        categoryCatalogPage.ClickOnProductTitle(categoryCatalogPage.FirstProduct);

        ProductPage productPage = new ProductPage(Driver, false);
        productPage.ClickOnCompareCheckBox();
        productPage.NavigateOnPreviousPage();
        string secondProductTitle = categoryCatalogPage.SecondProduct.Text;
        categoryCatalogPage.ClickOnProductTitle(categoryCatalogPage.SecondProduct);
        productPage.ClickOnCompareCheckBox();
        productPage.ClickOnCompareButton();
        
        ComparePage comparePage = new ComparePage(Driver, false);
        Assert.That(comparePage.ProductsCellsTitles.Count, Is.EqualTo(2));
        Assert.That(comparePage.FirstProductCellTitle.Text, Is.EqualTo(firstProductTitle));
        Assert.That(comparePage.SecondProductCellTitle.Text, Is.EqualTo(secondProductTitle));
        foreach (var cell in comparePage.DifferentCellsWithAccent)
        {
            Assert.IsTrue(cell.GetCssValue("background-color") == "rgba(255, 236, 196, 1)");
        }
        // Following assertion finds all different cells in grid and checks if one of values is marked with yellow (rgba(255, 236, 196, 1)) color.
        // It's not works because there is many cells with different values that shouldn't be marked with yellow color (e.g. Description).
        /*foreach (var row in comparePage.CompareRows)
        { 
            IWebElement firstColumn = row.FindElement(By.XPath("./td[3]"));
            IWebElement secondColumn = row.FindElement(By.XPath("./td[4]"));
            if (firstColumn.Text != secondColumn.Text)
            {
                Console.WriteLine(firstColumn.Text + " " + secondColumn.Text);
                Console.WriteLine(firstColumn.GetCssValue("background-color") + " " + secondColumn.GetCssValue("background-color"));
                Assert.IsTrue(firstColumn.GetCssValue("background-color") == "rgba(255, 236, 196, 1)" || secondColumn.GetCssValue("background-color") == "rgba(255, 236, 196, 1)");
            }
        }*/
        
    }
    
}