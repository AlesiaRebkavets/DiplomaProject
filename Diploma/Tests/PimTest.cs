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
    // used to go to URL to make sure that each test from the class will start from initial state
    // provides log in before each test execution 
    [AllureStep("The first step")]
    [SetUp]
    public void PimTestSetUp()
    {
        WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.LoginPageUrl);
        LoginPage.EnterUsername(TestSettings.UserName);
        LoginPage.EnterPassword(TestSettings.LoginPagePassword);
        LoginPage.ClickLoginButton();
        BasePage.ClickPimMenuButton();
    }

    // Adding new employee, verifying that last name of the employee is displayed in the table
    [Test]
    [AllureSeverity((SeverityLevel.normal))]
    [AllureSuite("Pim functionality")]
    [AllureDescription("Adding new employee, verifying that last name of the employee is displayed in the table")]
    public void AddNewEmployee()
    {
        EmployeeListPage.ClickAddButton();
        AddEmployeePage.EnterFirstName(TestSettings.PimPageFirstName);
        AddEmployeePage.EnterMiddleName(TestSettings.PimPageMiddleName);
        AddEmployeePage.EnterLastName(TestSettings.PimPageLastName);
        AddEmployeePage.EnterEmployeeId(TestSettings.PimPageEmployeeId);
        AddEmployeePage.ClickSaveButton();
        Assert.That(PersonalDetailsPage.IsPersonalDetailsPageDisplayed);
    }

    // Negative test: trying to add employee without data entered
    [Test]
    [AllureSeverity((SeverityLevel.normal))]
    [AllureSuite("Pim functionality")]
    [AllureDescription("Negative test: trying to add employee without data entered")]
    public void NegativeAddEmployeeWithoutDataEntered()
    {
        EmployeeListPage.ClickAddButton();
        AddEmployeePage.ClickSaveButton();
        Assert.That(AddEmployeePage.IsRequiredErrorMessageOfFirstNameInputFieldDisplayed);
        Assert.That(AddEmployeePage.IsRequiredErrorMessageOfLastNameInputFieldDisplayed);
    }

    // Delete employee added in the first test
    [AllureSeverity((SeverityLevel.normal))]
    [AllureSuite("Pim functionality")]
    [AllureDescription("Delete employee added in the first test")]
    [Test]
    public void DeleteEmployee()
    {
        EmployeeListPage.ClickDeleteButton(TestSettings.PimPageLastName);
        DeletePopup.ClickYesDeleteButton();
        Assert.That(!EmployeeListPage.IsEmployeeDataDisplayed(TestSettings.PimPageLastName));
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