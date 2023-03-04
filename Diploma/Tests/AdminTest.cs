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
public class AdminTest : BaseTest
{
    private readonly LoginPage _loginPage = new LoginPage();
    private readonly AdminPage _adminPage = new AdminPage();

    // used to go to URL to make sure that each test from the class will start from initial state
    // provides log in before each test execution 
    [SetUp]
    public void AdminTestSetUp()
    {
        WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.AdminPageUrl);
        _loginPage.EnterUsername(TestSettings.UserName);
        _loginPage.EnterPassword(TestSettings.LoginPagePassword);
        _loginPage.ClickLoginButton();
        BasePage.ClickAdminMenuButton();
    }

    // Adding new admin user, verifying that new username is displayed in the table
    [Test]
    [AllureSeverity((SeverityLevel.normal))]
    [AllureSuite("Admin functionality")]
    [AllureDescription("Adding new admin user, verifying that new username is displayed in the table")]
    public void AddAdminUser()
    {
        _adminPage.ClickAddButton();
        _adminPage.ClickUserRoleDropdown();
        _adminPage.SelectEssUserRoleDropdownOption();
        _adminPage.ClickStatusDropdown();
        _adminPage.SelectEnabledStatusDropdownOption();
        _adminPage.EnterEmployeeName(TestSettings.AdminPageEmployeeName);
        _adminPage.EnterUsername(TestSettings.AdminPageUsername);
        _adminPage.EnterPassword(TestSettings.AdminPagePassword);
        _adminPage.ConfirmPassword(TestSettings.AdminPagePassword);
        _adminPage.ClickSaveButton();
        Assert.AreEqual(TestSettings.AdminPageUsername, _adminPage.GetUsernameColumnTableValue());
    }

    // Negative test: trying to add user without data entered
    [Test]
    [AllureSeverity((SeverityLevel.normal))]
    [AllureSuite("Admin functionality")]
    [AllureDescription("Negative test: trying to add user without data entered")]
    public void NegativeAddUserWithoutDataEntered()
    {
        _adminPage.ClickAddButton();
        _adminPage.ClickSaveButton();
        Assert.IsTrue(_adminPage.IsRequiredErrorMessageOfUserRoleInputFieldDisplayed);
        Assert.IsTrue(_adminPage.IsRequiredErrorMessageOfStatusInputFieldDisplayed);
        Assert.IsTrue(_adminPage.IsRequiredErrorMessageOfPasswordInputFieldDisplayed);
        Assert.IsTrue(_adminPage.IsRequiredErrorMessageOfEmployeeNameInputFieldDisplayed);
        Assert.IsTrue(_adminPage.IsRequiredErrorMessageOfUserNameInputFieldDisplayed);
        Assert.IsTrue(_adminPage.IsRequiredErrorMessageOfConfirmPasswordInputFieldDisplayed);
        Assert.IsTrue(_adminPage.IsSaveButtonDisplayed);
    }

    // Delete user added in the first test
    // ЗАФЕЙЛЕННЫЙ ТЕСТ СОГЛАСНО ДЗ ЛЕК.15 
    [Test]
    [AllureSeverity((SeverityLevel.normal))]
    [AllureSuite("Admin functionality")]
    [AllureDescription("Delete user added in the first test")]
    public void DeleteAdminUser()
    {
        _adminPage.ClickDeleteTableButton();
        _adminPage.ClickYesDeleteButton();
        Assert.That(!_adminPage.IsUsernameDisplayedInTheTable);
    }

    // adds screenshot if test is failed and clears cookies after execution of each test from the class
    [TearDown]
    public void AdminTestTearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        {
            var screenShot = ((ITakesScreenshot)WebDriverFactory.Driver).GetScreenshot().AsByteArray;
            AllureLifecycle.Instance.AddAttachment(TestContext.CurrentContext.Test.Name, "image/png", screenShot);
        }

        WebDriverFactory.Driver.Manage().Cookies.DeleteAllCookies();
    }
}