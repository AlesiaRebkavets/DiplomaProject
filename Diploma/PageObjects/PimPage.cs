using System.Threading;
using Diploma.Common.WebElements;
using Diploma.Data;
using OpenQA.Selenium;

namespace Diploma.PageObjects;

public class PimPage: BasePage
{
    //saving locators of Pim page
    private MyWebElement _addButton = new MyWebElement(By.XPath("//*[text()=' Add ']"));
    private MyWebElement _firstNameInputField = new MyWebElement(By.Name("firstName"));
    private MyWebElement _middleNameInputField = new MyWebElement(By.Name("middleName"));
    private MyWebElement _lastNameInputField = new MyWebElement(By.Name("lastName"));
    private MyWebElement _employeeIdInputField = new MyWebElement(By.XPath("//*[text()='Employee Id']/../following-sibling::*/*"));
    private MyWebElement _saveButton = new MyWebElement(By.XPath("//*[text()=' Save ']"));
    private MyWebElement _personalDetails = new MyWebElement(By.XPath("//*[@role='tablist']//*[text()='Personal Details']"));
    private MyWebElement _lastNameColumnTableValue = new MyWebElement(By.XPath("//*[text()='"+TestSettings.PimPageLastName+"']"));
    private MyWebElement _deleteTableButton = new MyWebElement(By.XPath($"//*[text()=\"{TestSettings.PimPageLastName}\"]/../following-sibling::*//*[@type='button'][1]"));
    private MyWebElement _yesDeleteButton = new MyWebElement(By.XPath("//*[text()=' Yes, Delete ']"));
    private MyWebElement _requiredErrorMessageOfFirstNameInputField = new MyWebElement(By.XPath("//*[*[@placeholder='First Name']]/following-sibling::*[text()='Required']"));
    private MyWebElement _requiredErrorMessageOfLastNameInputField = new MyWebElement(By.XPath("//*[*[@placeholder='Last Name']]/following-sibling::*[text()='Required']"));
    
    // clicks Add button
    public void ClickAddButton() => _addButton.Click();
    
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

    // returns "true" if Personal Details page is displayed
    public bool IsPersonalDetailsPageDisplayed => _personalDetails.Displayed;

    // clicks Delete button
    public void ClickDeleteButton() => _deleteTableButton.ClickElement();

    // returns "true" if the employee data is displayed in the table
    public bool IsEmployeeDataDisplayed => _lastNameColumnTableValue.Displayed;

    // clicks 'Yes, Delete' button
    public void ClickYesDeleteButton() => _yesDeleteButton.Click();

    // returns "true" if "Required" error message of First Name input field is displayed in the table
    public bool IsRequiredErrorMessageOfFirstNameInputFieldDisplayed => _requiredErrorMessageOfFirstNameInputField.Displayed;

    // returns "true" if "Required" error message of Last Name input field is displayed in the table
    public bool IsRequiredErrorMessageOfLastNameInputFieldDisplayed => _requiredErrorMessageOfLastNameInputField.Displayed;
}