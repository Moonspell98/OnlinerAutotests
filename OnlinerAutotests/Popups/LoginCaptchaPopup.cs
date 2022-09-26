using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using PageObject.Services;

namespace OnlinerAutotests.Popups;

public class LoginCaptchaPopup : BasePopup
{
    private By CaptchaCheckboxLocator => By.XPath($"{FormContainer}//*[@class='recaptcha-checkbox-border']");
    private By CaptchaFrameLocator => By.XPath("//*[@title='reCAPTCHA']");

    public IWebElement CaptchaCheckbox => WaitService.WaitElementExists(CaptchaCheckboxLocator);
    public IWebElement CaptchaFrame => WaitService.WaitElementExists(CaptchaFrameLocator);
    
    public LoginCaptchaPopup(string containerXpath) : base(containerXpath)
    {
        Console.WriteLine(Driver.GetHashCode());
    }

    public void SwitchOnCaptchaFrame() => Driver.SwitchTo().Frame(CaptchaFrame);
    public void PressOnCaptchaCheckBox() => CaptchaCheckbox.Click();
    

}