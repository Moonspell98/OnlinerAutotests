using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using PageObject.Services;

namespace OnlinerAutotests.Popups;

public class LoginCaptchaPopup : BasePopup
{

    private By CaptchaCheckboxLocator => By.XPath($"//*[@class='recaptcha-checkbox-border']");
    private By HoveredCaptchaCheckboxLocator =>
        By.XPath(
            $"{FormContainer}//*[@class='recaptcha-checkbox goog-inline-block recaptcha-checkbox-unchecked rc-anchor-checkbox recaptcha-checkbox-hover']");

    private By CaptchaFrameLocator => By.XPath("//*[@title='reCAPTCHA']");

    public IWebElement CaptchaCheckbox => WaitService.WaitElementExists(CaptchaCheckboxLocator);
    public IWebElement HoveredCaptchaCheckbox => WaitService.WaitElementExists(HoveredCaptchaCheckboxLocator);
    public IWebElement CaptchaFrame => WaitService.WaitElementExists(CaptchaFrameLocator);
    

    public LoginCaptchaPopup(string containerXpath) : base(containerXpath)
    {
        Console.WriteLine(Driver.GetHashCode());
    }

    private Actions Actions = new Actions(Driver);

    public void SwitchOnCaptchaFrame() => Driver.SwitchTo().Frame(CaptchaFrame);
    public void HoverCaptchaCheckBox() => Actions.MoveByOffset(DriverFactory.Driver.Manage().Window.Size.Width / 2,
        DriverFactory.Driver.Manage().Window.Size.Height / 2).Build().Perform();
    public void PressOnCaptchaCheckBox() => CaptchaCheckbox.Click();
    

}