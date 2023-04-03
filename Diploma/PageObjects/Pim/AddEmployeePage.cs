using Diploma.Common.WebElements;
using OpenQA.Selenium;

namespace Diploma.PageObjects.Pim;

public class AddEmployeePage : EmployeeListPage
{
    //saving locators of AddEmployeePage
    private MyWebElement _firstNameInputField = new MyWebElement(By.Name("firstName"));
    private MyWebElement _middleNameInputField = new MyWebElement(By.Name("middleName"));
    private MyWebElement _lastNameInputField = new MyWebElement(By.Name("lastName"));

    private MyWebElement _employeeIdInputField = new MyWebElement(By.XPath("//*[contains(@class, 'oxd-input-group')][.//text()='Employee Id']//*[@class='oxd-input oxd-input--active']"));

    private MyWebElement _saveButton = new MyWebElement(By.XPath("//*[text()=' Save ']"));

    // general method to locate error messages with a similar XPath
    private MyWebElement RequiredErrorMessage(string fieldText) => new MyWebElement(By.XPath($"//*[@class='oxd-grid-item oxd-grid-item--gutters'][.//@name='{fieldText}']//*[text()='Required']"));

    // the error messages
    private MyWebElement RequiredErrorMessageOfFirstNameInputField => RequiredErrorMessage("firstName");
    private MyWebElement RequiredErrorMessageOfLastNameInputField => RequiredErrorMessage("lastName");

    // enters value to First Name field
    public void EnterFirstName(string firstName) => _firstNameInputField.SendKeys(firstName);

    // enters value to Middle Name field
    public void EnterMiddleName(string middleName) => _middleNameInputField.SendKeys(middleName);

    // enters value to Last Name field
    public void EnterLastName(string lastName) => _lastNameInputField.SendKeys(lastName);

    // enters value to Employee Id field
    public void EnterEmployeeId(string employeeId) => _employeeIdInputField.SendKeys(employeeId);

    // clicks Save button
    public void ClickSaveButton() => _saveButton.Click();

    // returns "true" if "Required" error message of First Name input field is displayed in the table
    public bool IsRequiredErrorMessageOfFirstNameInputFieldDisplayed => RequiredErrorMessageOfFirstNameInputField.IsDisplayed();

    // returns "true" if "Required" error message of Last Name input field is displayed in the table
    public bool IsRequiredErrorMessageOfLastNameInputFieldDisplayed => RequiredErrorMessageOfLastNameInputField.IsDisplayed();
}