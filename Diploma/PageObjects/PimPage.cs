using Diploma.Common.WebElements;
using OpenQA.Selenium;

namespace Diploma.PageObjects;

public class TextBoxPage: BasePage
{
    /*// saving locators of Buttons page
    private MyWebElement _fullNameTextBox = new MyWebElement(By.Id("userName"));
    private MyWebElement _emailTextBox = new MyWebElement(By.Id("userEmail"));
    private MyWebElement _submitButton = new MyWebElement(By.Id("submit"));
    private MyWebElement _nameResult = new MyWebElement(By.Id("name"));
    private MyWebElement _emailResult = new MyWebElement(By.Id("email"));
    
    // public methods to incapsulate interactions with elements
    public void EnterFullName(string fullName) => _fullNameTextBox.SendKeys(fullName);

    public void EnterEmail(string email) => _emailTextBox.SendKeys(email);

    public void ClickSubmitButton() => _submitButton.Click();

    public string GetNameResultText() => _nameResult.Text;

    public string GetEmailResultText() => _emailResult.Text;*/
}