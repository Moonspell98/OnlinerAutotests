using OnlinerAutotests.Pages;
using OnlinerAutotests.Popups;

namespace OnlinerAutotests.Tests;

public class SearchTest : BaseTest
{
    [Test]
    public void SuccessSearchTest()
    {
        MainPage mainPage = new MainPage(Driver, true, true);
        mainPage.FillIntoSearchField("ThinkPad T14");
        Thread.Sleep(TimeSpan.FromSeconds(5));
        SearchPopup searchPopup = new SearchPopup(Driver, "//*[@id='fast-search-modal']");
        searchPopup.SwitchOnSearchFrame();
        foreach (var searchResult in searchPopup.SearchResults)
        {
            Console.WriteLine(searchResult.Text);
            Assert.IsTrue(searchResult.Text.ToLower().Contains("thinkpad t14"));
        }
    }
}