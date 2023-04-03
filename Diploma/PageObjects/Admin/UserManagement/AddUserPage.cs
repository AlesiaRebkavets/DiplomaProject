using Diploma.Common.WebElements;
using OpenQA.Selenium;

namespace Diploma.PageObjects;

public class AddUserPage : UserManagementPage
{
    // saving locators of AddUserPage
    private MyDropDown _userRoleDropdown = new MyDropDown(By.XPath("//*[contains(@class, 'oxd-grid-item')][.//text()='User Role']//*[@class='oxd-select-wrapper']"));

    private MyDropDown _statusDropdown = new MyDropDown(By.XPath("//*[contains(@class, 'oxd-grid-item')][.//text()='Status']//*[@class='oxd-select-wrapper']"));

    private MyDropDown _employeeNameInputField = new MyDropDown(By.XPath("//*[contains(@class, 'oxd-grid-item')][.//text()='Employee Name']//input"));

    private MyWebElement _passwordInputField = new MyWebElement(By.XPath("//*[contains(@class, 'oxd-input-group')][.//text()='Password']//*[@type='password']"));

    private MyWebElement _confirmPasswordInputField = new MyWebElement(By.XPath("//*[contains(@class, 'oxd-input-group')][.//text()='Confirm Password']//*[@type='password']"));

    private MyWebElement _usernameInputField = new MyWebElement(By.XPath("//*[contains(@class, 'oxd-grid-item')][.//text()='Username']//*[contains(@class, 'oxd-input--active')]"));

    private MyWebElement _saveButton = new MyWebElement(By.XPath("//*[@type='submit']"));

    // general method to locate error messages with a similar XPath
    private MyWebElement ErrorMessage(string fieldName, string errorText) => new MyWebElement(By.XPath($"//*[contains(@class, 'oxd-grid-item oxd-grid-item--gutters')][.//text()='{fieldName}']//*[text()='{errorText}']"));

    // the error messages
    private MyWebElement RequiredErrorMessageOfUserRoleInputField => ErrorMessage("User Role", "Required");
    private MyWebElement RequiredErrorMessageOfStatusInputField => ErrorMessage("Status", "Required");
    private MyWebElement RequiredErrorMessageOfPasswordInputField => ErrorMessage("Password", "Required");
    private MyWebElement RequiredErrorMessageOfEmployeeNameInputField => ErrorMessage("Employee Name", "Required");
    private MyWebElement RequiredErrorMessageOfUserNameInputField => ErrorMessage("Username", "Required");

    private MyWebElement RequiredErrorMessageOfConfirmPasswordInputField => ErrorMessage("Confirm Password", "Required");

    private MyWebElement ShouldBeAtLeastFiveCharactersUsernameError => ErrorMessage("Username", "Should be at least 5 characters");

    // clicks User Role dropdown and selects an option
    public void SelectUserRoleDropDownValue(string value) => _userRoleDropdown.SelectValue(value);

    // clicks Status dropdown and selects an option 
    public void SelectStatusDropDownValue(string value) => _statusDropdown.SelectValue(value);

    // enters value to Employee Name field
    public void SelectEmployeeNameDropDownValue(string value) => _employeeNameInputField.EnterDataAndSelectValue(value);

    // enters value to Password field
    public void EnterPassword(string password) => _passwordInputField.SendKeys(password);

    // enters value to Confirm Password field
    public void ConfirmPassword(string password) => _confirmPasswordInputField.SendKeys(password);

    // enters value to Enter Username field
    public void EnterUsername(string username)
    {
        _usernameInputField.SendKeys(username);
        ShouldBeAtLeastFiveCharactersUsernameError.WaitUntilVisible();
    }

    // clicks Save button
    public void ClickSaveButton() => _saveButton.Click();

    // returns "true" if "Required" error message of User Role input field is displayed
    public bool IsRequiredErrorMessageOfUserRoleInputFieldDisplayed => RequiredErrorMessageOfUserRoleInputField.IsDisplayed();

    // returns "true" if "Required" error message of Status input field is displayed
    public bool IsRequiredErrorMessageOfStatusInputFieldDisplayed => RequiredErrorMessageOfStatusInputField.IsDisplayed();

    // returns "true" if "Required" error message of Password input field is displayed
    public bool IsRequiredErrorMessageOfPasswordInputFieldDisplayed => RequiredErrorMessageOfPasswordInputField.IsDisplayed();

    // returns "true" if "Required" error message of Employee Name input field is displayed
    public bool IsRequiredErrorMessageOfEmployeeNameInputFieldDisplayed => RequiredErrorMessageOfEmployeeNameInputField.IsDisplayed();

    // returns "true" if "Required" error message of User Name input field is displayed
    public bool IsRequiredErrorMessageOfUserNameInputFieldDisplayed => RequiredErrorMessageOfUserNameInputField.IsDisplayed();

    // returns "true" if "Required" error message of Confirm Password input field is displayed
    public bool IsRequiredErrorMessageOfConfirmPasswordInputFieldDisplayed => RequiredErrorMessageOfConfirmPasswordInputField.IsDisplayed();

    // returns "true" if Save button is displayed
    public bool IsSaveButtonDisplayed => _saveButton.IsDisplayed();
}