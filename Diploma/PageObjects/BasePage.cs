using Diploma.Common.WebElements;
using Diploma.Popups;
using OpenQA.Selenium;

namespace Diploma.PageObjects;

public class BasePage
{
    protected static readonly SuccessPopup SuccessPopup = new SuccessPopup();

    // saving locators of BasePage
    private static MyWebElement _orangeImage = new MyWebElement(By.CssSelector(".oxd-brand-banner"));

    // general method to locate menu buttons with a similar XPath
    private static MyWebElement MenuButton(string buttonText) => new MyWebElement(By.XPath($"//*[@class='oxd-main-menu']//*[text()='{buttonText}']"));

    // the menu buttons
    private static MyWebElement AdminMenuButton => MenuButton("Admin");
    private static MyWebElement PimMenuButton => MenuButton("PIM");
    private static MyWebElement BuzzMenuButton => MenuButton("Buzz");

    // returns 'true' if OrangeImage is displayed (user is successfully logged in)
    public static bool IsOrangeImageDisplayed => _orangeImage.IsDisplayed();

    // clicks Admin menu button
    public static void ClickAdminMenuButton() => AdminMenuButton.Click();

    // clicks PIM menu button
    public static void ClickPimMenuButton() => PimMenuButton.Click();

    // clicks Buzz menu button
    public static void ClickBuzzMenuButton() => BuzzMenuButton.Click();
}