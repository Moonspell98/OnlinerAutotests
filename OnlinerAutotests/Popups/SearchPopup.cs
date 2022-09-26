using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace OnlinerAutotests.Popups;

public class SearchPopup : BasePopup
{
    private By SearchIframeLocator => By.XPath($"{FormContainer}//*[@class='modal-iframe']");
    private By SearchResultsLocator => By.XPath("//*[@class='product__title-link']");

    public IWebElement SearchIframe => WaitService.WaitElementIsVisible(SearchIframeLocator);
    public ReadOnlyCollection<IWebElement> SearchResults => WaitService.WaitElementsAreVisible(SearchResultsLocator);
    
    public SearchPopup(IWebDriver driver, string containerXpath) : base(driver, containerXpath)
    {
    }

    public void SwitchOnSearchFrame() => Driver.SwitchTo().Frame(SearchIframe);

}