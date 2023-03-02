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
public class BuzzTest : BaseTest
{
    private readonly LoginPage _loginPage = new LoginPage();
    private readonly BuzzPage _buzzPage = new BuzzPage();

    // used to go to URL to make sure that each test from the class will start from initial state
    // provides log in before each test execution 
    [SetUp]
    public void BuzzTestSetUp()
    {
        WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.LoginPageUrl);
        _loginPage.EnterUsername(TestSettings.UserName);
        _loginPage.EnterPassword(TestSettings.LoginPagePassword);
        _loginPage.ClickLoginButton();
        BasePage.ClickBuzzMenuButton();
    }

    // Adding new post, verifying that its context is displayed on the page
    [Test]
    [AllureSeverity((SeverityLevel.normal))]
    [AllureSuite("Buzz functionality")]
    [AllureDescription("Adding new post, verifying that its context is displayed on the page")]
    public void AddNewPost()
    {
        _buzzPage.EnterPostText(TestSettings.BuzzPagePostText);
        _buzzPage.ClickPostButton();
        Assert.That(_buzzPage.IsPostContextDisplayed);
    }

    // Editing the post added in the first test, verifying that edited data successfully saved
    [Test]
    [AllureSeverity((SeverityLevel.normal))]
    [AllureSuite("Buzz functionality")]
    [AllureDescription("Editing the post added in the first test, verifying that edited data successfully saved")]
    public void EditPost()
    {
        _buzzPage.ClickEditPostButton();
        _buzzPage.EnterEditedText(TestSettings.BuzzPageEditedPostText);
        _buzzPage.ClickSaveEditedPostButton();
        Assert.That(_buzzPage.IsEditedPostContextDisplayed);
    }

    // Delete post added in the first test
    // ЗАФЕЙЛЕННЫЙ ТЕСТ СОГЛАСНО ДЗ ЛЕК.15
    [Test]
    [AllureSeverity((SeverityLevel.normal))]
    [AllureSuite("Buzz functionality")]
    [AllureDescription("Delete post added in the first test")]
    public void PostDeletion()
    {
        _buzzPage.ClickDeletePostButton();
        _buzzPage.ClickYesDeleteButton();
        Assert.That(!_buzzPage.IsEditedPostContextDisplayed);
    }

    // adds screenshot if test is failed and clears cookies after execution of each test from the class
    [TearDown]
    public void BuzzTestTearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        {
            var screenShot = ((ITakesScreenshot)WebDriverFactory.Driver).GetScreenshot().AsByteArray;
            AllureLifecycle.Instance.AddAttachment(TestContext.CurrentContext.Test.Name, "image/png", screenShot);
        }

        WebDriverFactory.Driver.Manage().Cookies.DeleteAllCookies();
    }
}