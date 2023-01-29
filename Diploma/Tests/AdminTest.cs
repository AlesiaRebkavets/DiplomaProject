using System.Threading;
using Diploma.Common.Drivers;
using Diploma.Data;
using Diploma.PageObjects;
using NUnit.Framework;

namespace Diploma.Tests;

public class AdminTest: BaseTest
{
    private readonly LoginPage _loginPage = new LoginPage();
    private readonly AdminPage _adminPage = new AdminPage();
    
    // used to go to URL to make sure that each test from the class will start from initial state
    // provides log in before each test execution 
    [SetUp]
    public void LoginTestSetUp()
    {
        WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.AdminPageUrl);
        _loginPage.EnterUsername(TestSettings.UserName);
        _loginPage.EnterPassword(TestSettings.LoginPagePassword);
        _loginPage.ClickLoginButton();
        BasePage.ClickAdminMenuButton();
    }

    // Adding new admin user, verifying that new username is displayed in the table
    [Test]
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
    
    // Deleting user added in the first test
    // ТЕСТ ФЕЙЛИТСЯ
    [Test]
    public void DeleteAdminUser()
    {
        _adminPage.ClickDeleteTableButton();
        _adminPage.ClickYesDeleteButton();
        Assert.That(!_adminPage.IsUsernameDisplayedInTheTable);   
        // не могу понять почему выдает "No such element exception" вместо "isDisplayed = false"
    }

    // clears cookies after execution of each test from the class
    [TearDown]
    public void LoginTestTearDown()
    {
        WebDriverFactory.Driver.Manage().Cookies.DeleteAllCookies();
    }
}