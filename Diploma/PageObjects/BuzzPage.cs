using System.Threading;
using Diploma.Common.WebElements;
using Diploma.Data;
using OpenQA.Selenium;

namespace Diploma.PageObjects;

public class BuzzPage : BasePage
{
    //saving locators of Buzz page
    private MyWebElement _postInputField =
        new MyWebElement(
            By.XPath("//*[@class='orangehrm-buzz-create-post-header']//*[@placeholder=\"What's on your mind?\"]"));

    private MyWebElement _postButton = new MyWebElement(By.XPath("//*[@type='submit'][text()=' Post ']"));

    private MyWebElement _addedPostContext =
        new MyWebElement(By.XPath(
            $"//*[@class='oxd-grid-item oxd-grid-item--gutters']//*[text()=\"{TestSettings.BuzzPagePostText}\"]"));

    private MyWebElement _editedPostContext = new MyWebElement(By.XPath(
        $"//*[@class='oxd-grid-item oxd-grid-item--gutters']//*[text()=\"{TestSettings.BuzzPageEditedPostText}\"]"));

    private MyWebElement _threeDotsPostButton = new MyWebElement(By.XPath(
        $"//*[text()=\"{TestSettings.BuzzPagePostText}\"]/ancestor::*[@class='oxd-sheet oxd-sheet--rounded oxd-sheet--white orangehrm-buzz']//*[@class='oxd-icon bi-three-dots']"));

    private MyWebElement _threeDotsPostButtonAfterEditing = new MyWebElement(By.XPath(
        $"//*[text()=\"{TestSettings.BuzzPageEditedPostText}\"]/ancestor::*[@class='oxd-sheet oxd-sheet--rounded oxd-sheet--white orangehrm-buzz']//*[@class='oxd-icon bi-three-dots']"));

    private MyWebElement _editPostButton = new MyWebElement(By.XPath(
        $"//*[text()=\"{TestSettings.BuzzPagePostText}\"]/ancestor::*[@class='oxd-sheet oxd-sheet--rounded oxd-sheet--white orangehrm-buzz']//*[text()='Edit Post']"));

    private MyWebElement _deletePostButton = new MyWebElement(By.XPath(
        $"//*[text()=\"{TestSettings.BuzzPageEditedPostText}\"]/ancestor::*[@class='oxd-sheet oxd-sheet--rounded oxd-sheet--white orangehrm-buzz']//*[text()='Delete Post']"));

    private MyWebElement _editPostTextArea =
        new MyWebElement(By.XPath("//*[@class='orangehrm-buzz-post-modal-header']//*[@class='oxd-buzz-post-input']"));

    private MyWebElement _saveEditedPostButton =
        new MyWebElement(
            By.XPath("//*[@class='oxd-form-actions orangehrm-buzz-post-modal-actions']//*[@type='submit']"));

    private MyWebElement _yesDeleteButton = new MyWebElement(By.XPath("//*[text()=' Yes, Delete ']"));


    // enters value to Post input field
    public void EnterPostText(string postText)
    {
        Thread.Sleep(2000);
        _postInputField.SendKeys(postText);
    }

    // clicks Post button
    public void ClickPostButton() => _postButton.ClickElement();

    // returns "true" if post is successfully added
    public bool IsPostContextDisplayed => _addedPostContext.Displayed;

    // returns "true" if post is successfully edited
    public bool IsEditedPostContextDisplayed => _editedPostContext.Displayed;

    // clicks Edit post button
    public void ClickEditPostButton()
    {
        _threeDotsPostButton.Click();
        _editPostButton.Click();
    }

    // enters value to edit post input field
    public void EnterEditedText(string editedText)
    {
        _editPostTextArea.ClearText();
        _editPostTextArea.SendKeys(editedText);
    }

    // clicks Post button after editing
    public void ClickSaveEditedPostButton() => _saveEditedPostButton.Click();

    // clicks Delete post button
    public void ClickDeletePostButton()
    {
        _threeDotsPostButtonAfterEditing.Click();
        _deletePostButton.Click();
    }

    // clicks 'Yes, Delete' button
    public void ClickYesDeleteButton() => _yesDeleteButton.Click();
}