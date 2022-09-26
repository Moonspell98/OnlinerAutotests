using OnlinerAutotests.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using PageObject.Services;

namespace OnlinerAutotests.Popups;

public abstract class BasePopup
{
       protected string FormContainer { get; set; }
       private const int WaitForPageLoadingTime = 10;
       public static IWebDriver Driver;
       private static WaitService _waitService;
       private static Actions _actions;

       public BasePopup(IWebDriver driver ,string containerXpath)
       {
              Driver = driver;
              Console.WriteLine(Driver.GetHashCode());
              FormContainer = containerXpath;
              _waitService = new WaitService(Driver);
       }
       
       public static WaitService WaitService
       {
              get => _waitService;
       }

       public static Actions Actions
       {
              get => _actions;
       }
       
}