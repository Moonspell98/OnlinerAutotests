using OnlinerAutotests.Services;
using OpenQA.Selenium;

namespace OnlinerAutotests.Pages;

public class TvCatalogPage : BasePage
{
    public TvCatalogPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(ConfiguratorService.BaseUrl);
    }
}