using Diploma.Common.WebElements;
using OpenQA.Selenium;

namespace Diploma.Popups;

public class SuccessPopup : BasePopup
{
    //saving locators of SuccessPopup
    private MyWebElement _successMessage = new MyWebElement(By.CssSelector(".oxd-toast-list-leave-active"));

    // returns "true" if success message is displayed
    public bool IsSuccessMessageDisplayed() => _successMessage.IsDisplayed();
}