using Diploma.Common.WebElements;
using OpenQA.Selenium;

namespace Diploma.Popups;

public class EditPostPopup : BasePopup
{
    //saving locators of EditPostPopup
    private MyWebElement _editPostTextArea = new MyWebElement(By.CssSelector(".orangehrm-buzz-post-modal-header-text .oxd-buzz-post-input"));
    private MyWebElement _saveEditedPostButton = new MyWebElement(By.XPath("//*[@class='oxd-form-actions orangehrm-buzz-post-modal-actions']//*[@type='submit']"));

    // enters value to Edit Post input field
    public void EnterEditedText(string editedText)
    {
        _editPostTextArea.ClearText();
        _editPostTextArea.SendKeys(editedText);
    }

    // clicks Post button after editing
    public void ClickSaveEditedPostButton() => _saveEditedPostButton.Click();
}