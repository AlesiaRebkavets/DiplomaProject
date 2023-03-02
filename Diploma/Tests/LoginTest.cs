using Allure.Net.Commons;
using Diploma.Common.Drivers;
using Diploma.Data;
using Diploma.PageObjects;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace Diploma.Tests;

[TestFixture]
[AllureNUnit]
public class LoginTest : BaseTest
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
    [AllureSeverity((SeverityLevel.critical))]
    [AllureSuite("Login functionality")]
    [AllureDescription("Performing successful site login")]
    public void LoginToTheSite()
    {
        _loginPage.EnterUsername(TestSettings.UserName);
        _loginPage.EnterPassword(TestSettings.LoginPagePassword);
        _loginPage.ClickLoginButton();
        Assert.That(BasePage.IsOrangeImageDisplayed);
    }

    // Empty string to 'Username' and 'Password' fields was entered
    [Test]
    [AllureSeverity((SeverityLevel.normal))]
    [AllureSuite("Login functionality")]
    [AllureDescription("Negative test: Empty string to 'Username' and 'Password' fields was entered")]
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
    [AllureSeverity((SeverityLevel.normal))]
    [AllureSuite("Login functionality")]
    [AllureDescription("Negative test: Invalid value to 'Username' field was entered")]
    public void NegativeInvalidUsernameIsEntered()
    {
        _loginPage.EnterUsername(TestSettings.InvalidUserName);
        _loginPage.EnterPassword(TestSettings.LoginPagePassword);
        _loginPage.ClickLoginButton();
        Assert.That(_loginPage.IsInvalidCredentialsErrorMessageDisplayed);
    }

    // Invalid value to 'Password' field was entered
    [Test]
    [AllureSeverity((SeverityLevel.normal))]
    [AllureSuite("Login functionality")]
    [AllureDescription("Negative test: Invalid value to 'Password' field was entered")]
    public void NegativeInvalidPasswordIsEntered()
    {
        _loginPage.EnterUsername(TestSettings.UserName);
        _loginPage.EnterPassword(TestSettings.InvalidPassword);
        _loginPage.ClickLoginButton();
        Assert.That(_loginPage.IsInvalidCredentialsErrorMessageDisplayed);
    }

    // adds screenshot if test is failed and clears cookies after execution of each test from the class
    [TearDown]
    public void LoginTestTearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        {
            var screenShot = ((ITakesScreenshot)WebDriverFactory.Driver).GetScreenshot().AsByteArray;
            AllureLifecycle.Instance.AddAttachment(TestContext.CurrentContext.Test.Name, "image/png", screenShot);
        }

        WebDriverFactory.Driver.Manage().Cookies.DeleteAllCookies();
    }
}