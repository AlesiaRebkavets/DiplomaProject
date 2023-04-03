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
    // used to go to URL to make sure that each test from the class will start from initial state
    // provides log in before each test execution 
    [SetUp]
    public void BuzzTestSetUp()
    {
        WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.LoginPageUrl);
        LoginPage.EnterUsername(TestSettings.UserName);
        LoginPage.EnterPassword(TestSettings.LoginPagePassword);
        LoginPage.ClickLoginButton();
        BasePage.ClickBuzzMenuButton();
    }

    // Adding new post, verifying that its context is displayed on the page
    [Test]
    [AllureSeverity((SeverityLevel.normal))]
    [AllureSuite("Buzz functionality")]
    [AllureDescription("Adding new post, verifying that its context is displayed on the page")]
    public void AddNewPost()
    {
        BuzzPage.EnterPostText(TestSettings.BuzzPagePostText);
        BuzzPage.ClickPostButton();
        Assert.That(BuzzPage.IsPostContextDisplayed(TestSettings.BuzzPagePostText));
    }

    // Editing the post added in the first test, verifying that edited data successfully saved
    [Test]
    [AllureSeverity((SeverityLevel.normal))]
    [AllureSuite("Buzz functionality")]
    [AllureDescription("Editing the post added in the first test, verifying that edited data successfully saved")]
    public void EditPost()
    {
        BuzzPage.ClickEditPostButton(TestSettings.BuzzPagePostText);
        EditPostPopup.EnterEditedText(TestSettings.BuzzPageEditedPostText);
        EditPostPopup.ClickSaveEditedPostButton();
        Assert.That(BuzzPage.IsEditedPostContextDisplayed(TestSettings.BuzzPageEditedPostText));
    }

    // Delete post added in the first test
    [Test]
    [AllureSeverity((SeverityLevel.normal))]
    [AllureSuite("Buzz functionality")]
    [AllureDescription("Delete post added in the first test")]
    public void PostDeletion()
    {
        BuzzPage.ClickDeletePostButton(TestSettings.BuzzPageEditedPostText);
        DeletePopup.ClickYesDeleteButton();
        Assert.True(!BuzzPage.IsEditedPostContextDisplayed(TestSettings.BuzzPageEditedPostText));
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