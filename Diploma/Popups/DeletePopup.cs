using Diploma.Common.WebElements;
using OpenQA.Selenium;

namespace Diploma.Popups;

public class DeletePopup : BasePopup
{
    //saving locators of DeletePopup
    private MyWebElement _yesDeleteButton = new MyWebElement(By.CssSelector(".oxd-button--label-danger"));

    // clicks 'Yes, Delete' button
    public void ClickYesDeleteButton() => _yesDeleteButton.Click();
}