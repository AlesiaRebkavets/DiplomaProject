using System.Threading;
using Diploma.Common.Drivers;
using Diploma.Data;
using Diploma.Data.Constants;
using Diploma.PageObjects;
using NUnit.Framework;

namespace Diploma.Tests;

public class PimTest: BaseTest
{
    private readonly LoginPage _loginPage = new LoginPage();
    private readonly PimPage _pimPage = new PimPage();
    
    // used to go to URL to make sure that each test from the class will start from initial state
    // provides log in before each test execution 
    [SetUp]
    public void PimTestSetUp()
    {
        WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.AdminPageUrl);
        _loginPage.EnterUsername(TestSettings.UserName);
        _loginPage.EnterPassword(TestSettings.LoginPagePassword);
        _loginPage.ClickLoginButton();
        BasePage.ClickPimMenuButton();
    }

    // Adding new employee, verifying that last name of the employee is displayed in the table
    [Test]
    public void AddNewEmployee()
    {
        _pimPage.ClickAddButton();
        _pimPage.EnterFirstName(TestSettings.PimPageFirstName);
        _pimPage.EnterMiddleName(TestSettings.PimPageMiddleName);
        _pimPage.EnterLastName(TestSettings.PimPageLastName);
        _pimPage.EnterEmployeeId(TestSettings.PimPageEmployeeId);
        _pimPage.ClickSaveButton();
        Assert.That(_pimPage.IsPersonalDetailsPageDisplayed);
    }

    // Negative test: trying to add employee without data entered
    [Test]
    public void NegativeAddEmployeeWithoutDataEntered()
    {
        _pimPage.ClickAddButton();
        _pimPage.ClickSaveButton();
        Assert.That(_pimPage.IsRequiredErrorMessageOfFirstNameInputFieldDisplayed);
        Assert.That(_pimPage.IsRequiredErrorMessageOfLastNameInputFieldDisplayed);
    }

    // Deleting employee added in the first test
    // ТЕСТ ФЕЙЛИТСЯ
    [Test]
    public void DeleteEmployee()
    {
        _pimPage.ClickDeleteButton();
        _pimPage.ClickYesDeleteButton();
        Assert.That(!_pimPage.IsEmployeeDataDisplayed);
    }
    
    // clears cookies after execution of each test from the class
    [TearDown]
    public void PimTestTearDown()
    {
        WebDriverFactory.Driver.Manage().Cookies.DeleteAllCookies();
    }
}