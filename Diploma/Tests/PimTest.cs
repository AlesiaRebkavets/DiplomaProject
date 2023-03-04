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
public class PimTest : BaseTest
{
    private readonly LoginPage _loginPage = new LoginPage();
    private readonly PimPage _pimPage = new PimPage();

    // used to go to URL to make sure that each test from the class will start from initial state
    // provides log in before each test execution 
    [AllureStep("The first step")]
    [SetUp]
    public void PimTestSetUp()
    {
        WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.LoginPageUrl);
        _loginPage.EnterUsername(TestSettings.UserName);
        _loginPage.EnterPassword(TestSettings.LoginPagePassword);
        _loginPage.ClickLoginButton();
        BasePage.ClickPimMenuButton();
    }

    // Adding new employee, verifying that last name of the employee is displayed in the table
    [Test]
    [AllureSeverity((SeverityLevel.normal))]
    [AllureSuite("Pim functionality")]
    [AllureDescription("Adding new employee, verifying that last name of the employee is displayed in the table")]
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
    [AllureSeverity((SeverityLevel.normal))]
    [AllureSuite("Pim functionality")]
    [AllureDescription("Negative test: trying to add employee without data entered")]
    public void NegativeAddEmployeeWithoutDataEntered()
    {
        _pimPage.ClickAddButton();
        _pimPage.ClickSaveButton();
        Assert.That(_pimPage.IsRequiredErrorMessageOfFirstNameInputFieldDisplayed);
        Assert.That(_pimPage.IsRequiredErrorMessageOfLastNameInputFieldDisplayed);
    }

    // Delete employee added in the first test
    // ЗАФЕЙЛЕННЫЙ ТЕСТ СОГЛАСНО ДЗ ЛЕК.15
    [AllureSeverity((SeverityLevel.normal))]
    [AllureSuite("Pim functionality")]
    [AllureDescription("Delete employee added in the first test")]
    [Test]
    public void DeleteEmployee()
    {
        _pimPage.ClickDeleteButton();
        _pimPage.ClickYesDeleteButton();
        Assert.That(!_pimPage.IsEmployeeDataDisplayed);
    }

    // adds screenshot if test is failed and clears cookies after execution of each test from the class
    [TearDown]
    public void PimTestTearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        {
            var screenShot = ((ITakesScreenshot)WebDriverFactory.Driver).GetScreenshot().AsByteArray;
            AllureLifecycle.Instance.AddAttachment(TestContext.CurrentContext.Test.Name, "image/png", screenShot);
        }

        WebDriverFactory.Driver.Manage().Cookies.DeleteAllCookies();
    }
}