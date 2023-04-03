using Diploma.Common.WebElements;
using OpenQA.Selenium;

namespace Diploma.PageObjects;

public class LoginPage : BasePage
{
    // saving locators of LoginPage
    private MyWebElement _usernameTextBox = new MyWebElement(By.Name("username"));
    private MyWebElement _passwordTextBox = new MyWebElement(By.Name("password"));
    private MyWebElement _loginButton = new MyWebElement(By.XPath("//*[@type='submit'][text()=' Login ']"));
    private MyWebElement _requiredErrorForUsernameTextBox = new MyWebElement(By.XPath("//*[*[@name='username']]/../*[text()='Required']"));
    private MyWebElement _requiredErrorForPasswordTextBox = new MyWebElement(By.XPath("//*[*[@name='password']]/../*[text()='Required']"));
    private MyWebElement _invalidCredentialsErrorMessage = new MyWebElement(By.XPath("//*[text()='Invalid credentials']"));

    // enters data to Username input field 
    public void EnterUsername(string userName) => _usernameTextBox.SendKeys(userName);

    // enters data to Password input field
    public void EnterPassword(string password) => _passwordTextBox.SendKeys(password);

    // clicks Login button
    public void ClickLoginButton() => _loginButton.Click();

    // returns 'true' if the 'Required' error message is displayed next to the 'Username' text box
    public bool IsRequiredErrorForUsernameTextBoxDisplayed => _requiredErrorForUsernameTextBox.IsDisplayed();

    // returns 'true' if the 'Required' error message is displayed next to the 'Password' text box
    public bool IsRequiredErrorForPasswordTextBoxDisplayed => _requiredErrorForPasswordTextBox.IsDisplayed();

    // returns 'true' if 'Invalid Credentials' error message is displayed
    public bool IsInvalidCredentialsErrorMessageDisplayed => _invalidCredentialsErrorMessage.IsDisplayed();
}