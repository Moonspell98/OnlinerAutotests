using OnlinerAutotests.Pages;
using OpenQA.Selenium;

namespace OnlinerAutotests.Popups;

public class LoginPopup : BasePopup
{

    private By NickInputFieldLocator => By.XPath($"{FormContainer}//*[@class='auth-form__field']//input[@type='text']");
    private By PasswordInputFieldLocator => By.XPath($"{FormContainer}//*[@class='auth-form__field']//input[@type='password']");
    private By SubmitButtonLocator => By.XPath($"{FormContainer}//*[@type='submit']");

    private IWebElement NickInputField => Driver.FindElement(NickInputFieldLocator);
    private IWebElement PasswordInputField => Driver.FindElement(PasswordInputFieldLocator);
    private IWebElement SubmitButton => Driver.FindElement(SubmitButtonLocator);
    
    public LoginPopup(string containerXpath) : base(containerXpath)
    {
    }

    public void EnterNick(string nickName) => NickInputField.SendKeys(nickName);
    public void EnterPassword(string password) => PasswordInputField.SendKeys(password);
    public void Login() => SubmitButton.Click();

}