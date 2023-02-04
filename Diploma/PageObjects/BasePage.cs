using Diploma.Common.WebElements;
using OpenQA.Selenium;

namespace Diploma.PageObjects;

public class BasePage
{
    // saving locators of BasePage
    private static MyWebElement _orangeImage = new MyWebElement(By.XPath("//*[@alt='client brand banner']"));
    private static MyWebElement _adminMenuButton = new MyWebElement(By.XPath("//*[@class='oxd-main-menu']//*[text()='Admin']"));
    private static MyWebElement _pimMenuButton = new MyWebElement(By.XPath("//*[@class='oxd-main-menu']//*[text()='PIM']"));

    // returns 'true' if OrangeImage is displayed (user is successfully logged in)
    public static bool IsOrangeImageDisplayed => _orangeImage.Displayed;
    
    // clicks Admin menu button
    public static void ClickAdminMenuButton() => _adminMenuButton.Click();
    
    // clicks PIM menu button
    public static void ClickPimMenuButton() => _pimMenuButton.Click();


    // method to expand category

    /*public void ExpandCategory(string categoryName)
    {
        // base part of "element-group" item
        var elementGroupXpathLocator = $"//*[@class='element-group' and .//text()='{categoryName}']";
        
        // element with "collapse" class. When this one is expanded class contains "show". This one is needed to check if element is collapsed or expanded
        var elementListWithCollapseClass =
            new MyWebElement(By.XPath($"{elementGroupXpathLocator}//div[contains(@class, 'collapse')]"));
        
        // element to click if "element-group" is collapsed to expand it
        var groupHeader =
            new MyWebElement(By.XPath($"{elementGroupXpathLocator}//*[@class='group-header']"));
        
        // click groupHeader if "element-group" is collapsed
        if (!elementListWithCollapseClass.GetValueOfClassAttribute().Contains("show"))
        {
            groupHeader.Click();
        }
    } */
}