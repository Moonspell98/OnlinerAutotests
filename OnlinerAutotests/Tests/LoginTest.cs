using OnlinerAutotests.Pages;
using OnlinerAutotests.Popups;

namespace OnlinerAutotests.Tests;

public class LoginTest : BaseTest
{
    [Test]
    public void TestSuccessLogin()
    {
        MainPage mainPage = new MainPage(Driver, true);
        mainPage.ClickOnLoginButton();
        LoginPopup loginPopup = new LoginPopup("//*[@id='auth-container']");
        loginPopup.EnterNick("robert.minear365@gmail.com");
        loginPopup.EnterPassword("casm9hir8LOT@klap\"");
        loginPopup.Login();
        LoginCaptchaPopup loginCaptchaPopup = new LoginCaptchaPopup("//*[@id='rc-anchor-container']");
        loginCaptchaPopup.SwitchOnCaptchaFrame();
        loginCaptchaPopup.PressOnCaptchaCheckBox();
        Assert.IsTrue(mainPage.UserIcon.Displayed);
        mainPage.ClickOnProfileArrow();
        Assert.AreEqual("3528681", mainPage.UserName.Text);
    }
}