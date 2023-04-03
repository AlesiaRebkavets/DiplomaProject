using Diploma.Common.WebElements;
using OpenQA.Selenium;

namespace Diploma.PageObjects;

public class BuzzPage : BasePage
{
    //saving locators of Buzz page
    private MyWebElement _postInputField = new MyWebElement(By.CssSelector(".oxd-buzz-post-input"));
    private MyWebElement _postButton = new MyWebElement(By.CssSelector(".oxd-buzz-post-slot .oxd-button--main"));
    private MyWebElement _leaveCommentButton = new MyWebElement(By.XPath("//*[contains(@class, 'bi-chat-text-fill')][1]"));

    private MyWebElement AddedPostContext(string postText) => new MyWebElement(By.XPath($"//*[@class='oxd-grid-item oxd-grid-item--gutters']//*[text()=\"{postText}\"]"));

    private MyWebElement EditedPostContext(string postText) => new MyWebElement(By.XPath($"//*[@class='oxd-grid-item oxd-grid-item--gutters']//*[text()=\"{postText}\"]"));

    private MyWebElement ThreeDotsPostButton(string postText) => new MyWebElement(By.XPath($"//*[contains(@class,'oxd-sheet oxd-sheet--rounded')][.//text()=\"{postText}\"]//*[@class='oxd-icon bi-three-dots']"));

    private MyWebElement EditPostButton(string postText) => new MyWebElement(By.XPath($"//*[contains(@class,'oxd-sheet oxd-sheet--rounded')][.//text()=\"{postText}\"]//*[./@class='oxd-icon bi-pencil']"));

    private MyWebElement DeletePostButton(string postText) => new MyWebElement(By.XPath($"//*[contains(@class,'oxd-sheet oxd-sheet--rounded')][.//text()=\"{postText}\"]//*[./@class='oxd-icon bi-trash']"));

    // enters value to Post input field
    public void EnterPostText(string postText)
    {
        _leaveCommentButton.IsDisplayed();
        _postInputField.ScrollIntoView();
        _postInputField.SendKeys(postText);
    }

    // clicks Post button
    public void ClickPostButton() => _postButton.ClickViaJs();

    // returns "true" if post is successfully added
    public bool IsPostContextDisplayed(string postText) => AddedPostContext(postText).IsDisplayed();

    // returns "true" if post is successfully edited
    public bool IsEditedPostContextDisplayed(string postText)
    {
        SuccessPopup.IsSuccessMessageDisplayed();
        return EditedPostContext(postText).IsDisplayed();
    }

    // clicks Edit post button
    public void ClickEditPostButton(string postText)
    {
        ThreeDotsPostButton(postText).ClickViaJs();
        EditPostButton(postText).ClickViaJs();
    }

    // clicks Delete post button
    public void ClickDeletePostButton(string postText)
    {
        ThreeDotsPostButton(postText).ClickViaJs();
        DeletePostButton(postText).ClickViaJs();
    }
}