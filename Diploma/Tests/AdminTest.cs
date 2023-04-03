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
    // used to go to URL to make sure that each test from the class will start from initial state
    // provides log in before each test execution 
    [SetUp]
    public void AdminTestSetUp()
    {
        WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.AdminPageUrl);
        LoginPage.EnterUsername(TestSettings.UserName);
        LoginPage.EnterPassword(TestSettings.LoginPagePassword);
        LoginPage.ClickLoginButton();
        BasePage.ClickAdminMenuButton();
    }

    // Adding new admin user, verifying that new username is displayed in the table
    [Test]
    [AllureSeverity((SeverityLevel.normal))]
    [AllureSuite("Admin functionality")]
    [AllureDescription("Adding new admin user, verifying that new username is displayed in the table")]
    public void AddAdminUser()
    {
        UserManagementPage.ClickAddButton();
        AddUserPage.SelectUserRoleDropDownValue(TestSettings.AdminPageUserRoleDropDownValue);
        AddUserPage.SelectStatusDropDownValue(TestSettings.AdminPageStatusDropDownValue);
        AddUserPage.SelectEmployeeNameDropDownValue(TestSettings.AdminPageEmployeeName);
        AddUserPage.EnterUsername(TestSettings.AdminPageUsername);
        AddUserPage.EnterPassword(TestSettings.AdminPagePassword);
        AddUserPage.ConfirmPassword(TestSettings.AdminPagePassword);
        AddUserPage.ClickSaveButton();
        Assert.AreEqual(TestSettings.AdminPageUsername, UserManagementPage.GetUsernameColumnTableValue(TestSettings.AdminPageUsername));
    }

    // Negative test: trying to add user without data entered
    [Test]
    [AllureSeverity((SeverityLevel.normal))]
    [AllureSuite("Admin functionality")]
    [AllureDescription("Negative test: trying to add user without data entered")]
    public void NegativeAddUserWithoutDataEntered()
    {
        UserManagementPage.ClickAddButton();
        AddUserPage.ClickSaveButton();
        Assert.IsTrue(AddUserPage.IsRequiredErrorMessageOfUserRoleInputFieldDisplayed);
        Assert.IsTrue(AddUserPage.IsRequiredErrorMessageOfStatusInputFieldDisplayed);
        Assert.IsTrue(AddUserPage.IsRequiredErrorMessageOfPasswordInputFieldDisplayed);
        Assert.IsTrue(AddUserPage.IsRequiredErrorMessageOfEmployeeNameInputFieldDisplayed);
        Assert.IsTrue(AddUserPage.IsRequiredErrorMessageOfUserNameInputFieldDisplayed);
        Assert.IsTrue(AddUserPage.IsRequiredErrorMessageOfConfirmPasswordInputFieldDisplayed);
        Assert.IsTrue(AddUserPage.IsSaveButtonDisplayed);
    }

    // Delete user added in the first test
    [Test]
    [AllureSeverity((SeverityLevel.normal))]
    [AllureSuite("Admin functionality")]
    [AllureDescription("Delete user added in the first test")]
    public void DeleteAdminUser()
    {
        UserManagementPage.ClickDeleteTableButton(TestSettings.AdminPageUsername);
        DeletePopup.ClickYesDeleteButton();
        Assert.IsTrue(!UserManagementPage.IsUsernameDisplayedInTheTable(TestSettings.AdminPageUsername));
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