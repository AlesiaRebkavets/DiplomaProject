using Diploma.Common.Drivers;
using Diploma.PageObjects;
using Diploma.PageObjects.Pim;
using Diploma.Popups;
using NUnit.Framework;
namespace Diploma.Tests;

public class BaseTest
{
    protected readonly DeletePopup DeletePopup = new DeletePopup();
    protected readonly LoginPage LoginPage = new LoginPage();
    protected readonly UserManagementPage UserManagementPage = new UserManagementPage();
    protected readonly AddUserPage AddUserPage = new AddUserPage();
    protected readonly BuzzPage BuzzPage = new BuzzPage();
    protected readonly EditPostPopup EditPostPopup = new EditPostPopup();
    protected readonly EmployeeListPage EmployeeListPage = new EmployeeListPage();
    protected readonly PersonalDetailsPage PersonalDetailsPage = new PersonalDetailsPage();
    protected readonly AddEmployeePage AddEmployeePage = new AddEmployeePage();

    // contains all the necessary methods to call them once before all tests in descendant classes
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        // maximizing browser window
        WebDriverFactory.Driver.Manage().Window.Maximize();
    }

    // contains all necessary methods to call them once after all tests in descendant classes  
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        WebDriverFactory.QuitDriver();
    }
}