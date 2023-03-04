using System.Threading;
using Diploma.Common.WebElements;
using Diploma.Data;
using OpenQA.Selenium;

namespace Diploma.PageObjects;

public class AdminPage : BasePage
{
    // saving locators of AdminPage
    private MyWebElement _addButton = new MyWebElement(By.XPath("//*[text() = ' Add ']"));

    private MyWebElement _userRoleDropdown =
        new MyWebElement(By.XPath("//*[text()='User Role']/../following-sibling::*"));

    private MyWebElement _essUserRoleDropdownOption =
        new MyWebElement(By.XPath("//*[@role='listbox']//*[text()='ESS']"));

    private MyWebElement _statusDropdown = new MyWebElement(By.XPath("//*[text()='Status']/../following-sibling::*"));

    private MyWebElement _enabledStatusDropdownOption =
        new MyWebElement(By.XPath("//*[@role='listbox']//*[text()='Enabled']"));

    private MyWebElement _employeeNameInputField = new MyWebElement(By.XPath("//*[@placeholder='Type for hints...']"));

    private MyWebElement _employeeNameInputFieldSearchValue = new MyWebElement(By.XPath("//*[@role='listbox']/*"));

    private MyWebElement _passwordInputField =
        new MyWebElement(By.XPath("//*[text()='Password']/../following-sibling::*/*[@type='password']"));

    private MyWebElement _confirmPasswordInputField =
        new MyWebElement(By.XPath("//*[text()='Confirm Password']/../following-sibling::*/*[@type='password']"));

    private MyWebElement _usernameInputField =
        new MyWebElement(By.XPath("//*[text()='Username']/../following-sibling::*/*"));

    private MyWebElement _saveButton = new MyWebElement(By.XPath("//*[@type='submit']"));

    private MyWebElement _usernameColumnTableValue =
        new MyWebElement(By.XPath("//*[text()='" + TestSettings.AdminPageUsername + "']"));

    private MyWebElement _deleteTableButton =
        new MyWebElement(By.XPath(
            $"//*[text()=\"{TestSettings.AdminPageUsername}\"]/../following-sibling::*[4]//*[@type='button'][1]"));

    private MyWebElement _requiredErrorMessageOfUserRoleInputField =
        new MyWebElement(By.XPath("//*[text()='User Role']/../following-sibling::*/../*[text()='Required']"));

    private MyWebElement _requiredErrorMessageOfStatusInputField =
        new MyWebElement(By.XPath("//*[text()='Status']/../following-sibling::*/../*[text()='Required']"));

    private MyWebElement _requiredErrorMessageOfPasswordInputField =
        new MyWebElement(By.XPath("//*[text()='Password']/../following-sibling::*/../*[text()='Required']"));

    private MyWebElement _requiredErrorMessageOfEmployeeNameInputField =
        new MyWebElement(By.XPath("//*[text()='Employee Name']/../following-sibling::*/../*[text()='Required']"));

    private MyWebElement _requiredErrorMessageOfUserNameInputField =
        new MyWebElement(By.XPath("//*[text()='Username']/../following-sibling::*/../*[text()='Required']"));

    private MyWebElement _requiredErrorMessageOfConfirmPasswordInputField =
        new MyWebElement(By.XPath("//*[text()='Confirm Password']/../following-sibling::*/../*[text()='Required']"));

    private MyWebElement _yesDeleteButton = new MyWebElement(By.XPath("//*[text()=' Yes, Delete ']"));

    // clicks Add button
    public void ClickAddButton() => _addButton.ClickElement();

    // clicks User Role dropdown
    public void ClickUserRoleDropdown() => _userRoleDropdown.Click();

    // selects "ESS" option of User Role dropdown
    public void SelectEssUserRoleDropdownOption() => _essUserRoleDropdownOption.Click();

    // clicks Status dropdown
    public void ClickStatusDropdown() => _statusDropdown.Click();

    // selects "Enabled" option of Status dropdown
    public void SelectEnabledStatusDropdownOption() => _enabledStatusDropdownOption.Click();

    // enters value to Employee Name field
    public void EnterEmployeeName(string employeeName)
    {
        _employeeNameInputField.SendKeys(employeeName);
        Thread.Sleep(2000);
        _employeeNameInputFieldSearchValue.Click();
    }

    // enters value to Password field
    public void EnterPassword(string password) => _passwordInputField.SendKeys(password);

    // enters value to Confirm Password field
    public void ConfirmPassword(string password) => _confirmPasswordInputField.SendKeys(password);

    // enters value to Enter Username field
    public void EnterUsername(string username) => _usernameInputField.SendKeys(username);

    // clicks Save button
    public void ClickSaveButton()
    {
        Thread.Sleep(1000);
        _saveButton.Click();
    }

    // returns Username value displayed in the table 
    public string GetUsernameColumnTableValue() => _usernameColumnTableValue.GetText();

    // returns "true" if Username is displayed in the table
    public bool IsUsernameDisplayedInTheTable => _usernameColumnTableValue.Displayed;

    // clicks Delete button
    public void ClickDeleteTableButton() => _deleteTableButton.ClickElement();

    // returns "true" if "Required" error message of User Role input field is displayed in the table
    public bool IsRequiredErrorMessageOfUserRoleInputFieldDisplayed =>
        _requiredErrorMessageOfUserRoleInputField.Displayed;

    // returns "true" if "Required" error message of Status input field is displayed in the table
    public bool IsRequiredErrorMessageOfStatusInputFieldDisplayed => _requiredErrorMessageOfStatusInputField.Displayed;

    // returns "true" if "Required" error message of Password input field is displayed in the table
    public bool IsRequiredErrorMessageOfPasswordInputFieldDisplayed =>
        _requiredErrorMessageOfPasswordInputField.Displayed;

    // returns "true" if "Required" error message of Employee Name input field is displayed in the table
    public bool IsRequiredErrorMessageOfEmployeeNameInputFieldDisplayed =>
        _requiredErrorMessageOfEmployeeNameInputField.Displayed;

    // returns "true" if "Required" error message of User Name input field is displayed in the table
    public bool IsRequiredErrorMessageOfUserNameInputFieldDisplayed =>
        _requiredErrorMessageOfUserNameInputField.Displayed;

    // returns "true" if "Required" error message of Confirm Password input field is displayed in the table
    public bool IsRequiredErrorMessageOfConfirmPasswordInputFieldDisplayed =>
        _requiredErrorMessageOfConfirmPasswordInputField.Displayed;

    // returns "true" if Save button is displayed in the table
    public bool IsSaveButtonDisplayed => _saveButton.Displayed;

    // clicks "Yes, Delete" button
    public void ClickYesDeleteButton() => _yesDeleteButton.Click();
}