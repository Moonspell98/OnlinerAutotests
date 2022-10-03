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
        catalogPage.HoverOnTvAndVideoSubCategory();
        catalogPage.ClickOnTvCatalogLink();
        TvCatalogPage tvCatalogPage = new TvCatalogPage(Driver, false);
        tvCatalogPage.ClickOnProductTitle(tvCatalogPage.FirstProduct);
        ProductPage productPage = new ProductPage(Driver, false);
        productPage.ClickOnCompareCheckBox();
        productPage.NavigateOnPreviousPage();
        tvCatalogPage.ClickOnProductTitle(tvCatalogPage.SecondProduct);
        productPage.ClickOnCompareCheckBox();
        productPage.ClickOnCompareButton();
        ComparePage comparePage = new ComparePage(Driver, false);
        foreach (var row in comparePage.CompareRows)
        {
            Console.WriteLine(row.GetDomProperty("innerHTML"));
            IWebElement firstColumn = row.FindElement(By.XPath("//*td[3]"));
            IWebElement secondColumn = row.FindElement(By.XPath("//*td[4]"));
            Console.WriteLine(firstColumn.Text + " " + secondColumn.Text);
            Console.WriteLine(firstColumn.GetCssValue("background-color") + " " + secondColumn.GetCssValue("background-color"));
            if (firstColumn.Text != secondColumn.Text)
            {
                Assert.IsTrue(firstColumn.GetCssValue("background-color") == "rgba(255, 236, 196, 1)" || secondColumn.GetCssValue("background-color") == "rgba(255, 236, 196, 1)");
            }
        }
    }
    
}