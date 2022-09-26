using OnlinerAutotests.Pages;
using OpenQA.Selenium;

namespace OnlinerAutotests.Popups;

public class LoginPopup : BasePopup
{
    private By EmailFieldLocator => By.XPath($"{FormContainer}//*[@class='auth-form__field']//input[@type='text']");
    private By PasswordInputFieldLocator => By.XPath($"{FormContainer}//*[@class='auth-form__field']//input[@type='password']");
    private By SubmitButtonLocator => By.XPath($"{FormContainer}//*[@type='submit']");

    private IWebElement EmailInputField => Driver.FindElement(EmailFieldLocator);
    private IWebElement PasswordInputField => Driver.FindElement(PasswordInputFieldLocator);
    private IWebElement SubmitButton => Driver.FindElement(SubmitButtonLocator);
    
    public LoginPopup(IWebDriver driver ,string containerXpath) : base(driver,containerXpath)
    {
    }

    public void EnterEmail(string email) => EmailInputField.SendKeys(email);
    public void EnterPassword(string password) => PasswordInputField.SendKeys(password);
    public void Login() => SubmitButton.Click();
}