using OnlinerAutotests.Pages;

namespace OnlinerAutotests.Tests;

public class OfferTest : BaseTest
{
    [Test]
    public void OfferPlayStation()
    {
        MainPage mainPage = new MainPage(Driver, true);
        mainPage.ClickOnCatalogLink();

        CatalogPage catalogPage = mainPage.NavigateOnCatalogPage();
        catalogPage.ClickOnElectronicsCategory();
        catalogPage.HoverOnSubCategory(catalogPage.VideoGamesSubCategory);
        
        CategoryCatalogPage categoryCatalogPage = catalogPage.NavigateOnCategoryCatalogPage(catalogPage.ConsolesCatalogLink);
        string productTitle = categoryCatalogPage.FirstProduct.Text;

        ProductPage productPage = categoryCatalogPage.NavigateOnProductPage(categoryCatalogPage.FirstProduct);
        productPage.SubmitCity();

        ProductSellersPage productSellersPage = productPage.NavigateOnProductSellersPage();
        string firstSellerPrice = productSellersPage.GetFirstSellerPrice();
        productSellersPage.AddToCartProductFromFirstSeller();

        CartPage cartPage = productSellersPage.NavigateToCart();
        Assert.IsTrue(cartPage.IsProductTitleEqual(productTitle));
        Assert.IsTrue(cartPage.IsProductPriceEqual(firstSellerPrice));
        Assert.IsTrue(cartPage.IsProductsCountEqual("1"));
        
        var orderPage = cartPage.NavigateToOrderPage();
        Assert.IsTrue(orderPage.IsOrderProductTitleContains(productTitle));
        Assert.IsTrue(orderPage.IsOrderProductPriceEqual(firstSellerPrice));
    }
}