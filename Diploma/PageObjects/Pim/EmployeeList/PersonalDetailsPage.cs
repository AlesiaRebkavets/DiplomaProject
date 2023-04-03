using Diploma.Common.WebElements;
using OpenQA.Selenium;

namespace Diploma.PageObjects.Pim;

public class PersonalDetailsPage : EmployeeListPage
{
    //saving locators of PersonalDetailsPage
    private MyWebElement _personalDetails = new MyWebElement(By.XPath("//*[@role='tablist']//*[text()='Personal Details']"));

    // returns "true" if Personal Details page is displayed
    public bool IsPersonalDetailsPageDisplayed => _personalDetails.IsDisplayed();
}