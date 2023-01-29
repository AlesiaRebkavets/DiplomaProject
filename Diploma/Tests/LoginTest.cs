using Diploma.Common.Drivers;
using Diploma.Data;
using Diploma.PageObjects;
using NUnit.Framework;

namespace Diploma.Tests;

public class LoginTest: BaseTest
{
    private readonly LoginPage _loginPage = new LoginPage();
    
    // used to go to URL to make sure that each test from the class will start from initial state
    [SetUp]
    public void LoginTestSetUp()
    {
        WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.LoginPageUrl);
    }
    
    // performing successful site login
    [Test]
    public void LoginToTheSite()
    {
        _loginPage.EnterUsername(TestSettings.UserName);
        _loginPage.EnterPassword(TestSettings.LoginPagePassword);
        _loginPage.ClickLoginButton();
        Assert.That(BasePage.IsOrangeImageDisplayed);
    }
    
    // Empty string to 'Username' and 'Password' fields was entered
    [Test]
    public void NegativeUsernameAndPasswordFieldsAreEmpty()
    {
        _loginPage.EnterUsername("");
        _loginPage.EnterPassword("");
        _loginPage.ClickLoginButton();
        Assert.That(_loginPage.IsRequiredErrorForUsernameTextBoxDisplayed);
        Assert.That(_loginPage.IsRequiredErrorForPasswordTextBoxDisplayed);
    }

    // Invalid value to 'Username' field was entered
    [Test]
    public void NegativeInvalidUsernameIsEntered()
    {
        _loginPage.EnterUsername(TestSettings.InvalidUserName);
        _loginPage.EnterPassword(TestSettings.LoginPagePassword);
        _loginPage.ClickLoginButton();
        Assert.That(_loginPage.IsInvalidCredentialsErrorMessageDisplayed);
    }
    
    // Invalid value to 'Password' field was entered
    [Test]
    public void NegativeInvalidPasswordIsEntered()
    {
        _loginPage.EnterUsername(TestSettings.UserName);
        _loginPage.EnterPassword(TestSettings.InvalidPassword);
        _loginPage.ClickLoginButton();
        Assert.That(_loginPage.IsInvalidCredentialsErrorMessageDisplayed);
    }
    
    // clears cookies after execution of each test from the class
    [TearDown]
    public void LoginTestTearDown()
    {
        WebDriverFactory.Driver.Manage().Cookies.DeleteAllCookies();
    }
}