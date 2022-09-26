using OnlinerAutotests.Pages;
using OnlinerAutotests.Popups;
using OnlinerAutotests.Services;

namespace OnlinerAutotests.Tests;

public class LoginTest : BaseTest
{
    [Test]
    public void SuccessLoginTest()
    {
        MainPage mainPage = new MainPage(Driver, true);
        mainPage.ClickOnLoginButton();
        LoginPopup loginPopup = new LoginPopup(Driver,"//*[@id='auth-container']");
        loginPopup.EnterEmail(ConfiguratorService.Email);
        loginPopup.EnterPassword(ConfiguratorService.Password);
        loginPopup.Login();
        LoginCaptchaPopup loginCaptchaPopup = new LoginCaptchaPopup(Driver, "//*[@id='rc-anchor-container']");
        loginCaptchaPopup.SwitchOnCaptchaFrame();
        loginCaptchaPopup.PressOnCaptchaCheckBox();
        Assert.IsTrue(mainPage.UserIcon.Displayed);
        mainPage.ClickOnProfileArrow();
        Assert.That(mainPage.UserName.Text, Is.EqualTo(ConfiguratorService.UserName));
    }
}