using OnlinerAutotests.Pages;

namespace OnlinerAutotests.Tests;

public class OfferTest : BaseTest
{
    [Test]
    public void OfferPlayStation()
    {
        MainPage mainPage = new MainPage(Driver, true);
        mainPage.ClickOnCatalogLink();
        
        CatalogPage catalogPage = new CatalogPage(Driver, false);
        catalogPage.ClickOnElectronicsCategory();
        catalogPage.HoverOnSubCategory(catalogPage.VideoGamesSubCategory);
        catalogPage.ClickOnCatalogLink(catalogPage.ConsolesCatalogLink);

        CategoryCatalogPage categoryCatalogPage = new CategoryCatalogPage(Driver, false);
        string productTitle = categoryCatalogPage.FirstProduct.Text;
        categoryCatalogPage.ClickOnProductTitle(categoryCatalogPage.FirstProduct);

        ProductPage productPage = new ProductPage(Driver, false);
        productPage.CitySubmitButton.Click();
        productPage.ClickOnSellersOffersButton();

        ProductSellersPage productSellersPage = new ProductSellersPage(Driver, false);
        string firstSellerPrice = productSellersPage.FirstSellerPrice.Text;
        productSellersPage.AddToCartProductFromFirstSeller();
        productSellersPage.NavigateToCart();

        CartPage cartPage = new CartPage(Driver, false);
        Assert.IsTrue(cartPage.IsProductTitleEqual(productTitle));
        Assert.IsTrue(cartPage.IsProductPriceEqual(firstSellerPrice));
        Assert.IsTrue(cartPage.IsProductsCountEqual("1"));
        
        var orderPage = cartPage.NavigateToOrderPage();
        Assert.IsTrue(orderPage.IsOrderProductTitleContains(productTitle));
        Assert.IsTrue(orderPage.IsOrderProductPriceEqual(firstSellerPrice));
    }
}