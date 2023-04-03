using Diploma.Common.WebElements;
using OpenQA.Selenium;

namespace Diploma.PageObjects;

public class EmployeeListPage : BasePage
{
    //saving locators of EmployeeListPage
    private MyWebElement _addButton = new MyWebElement(By.XPath("//*[text()=' Add ']"));
    private MyWebElement LastNameColumnTableValue(string value) => new MyWebElement(By.XPath($"//*[text()='{value}']"));

    private MyWebElement DeleteTableButton(string value) => new MyWebElement(By.XPath($"//*[.//text()='{value}'][contains(@class, 'oxd-table-row')]//*[./@class='oxd-icon bi-trash']"));

    // clicks Add button
    public void ClickAddButton() => _addButton.ClickViaJs();

    // clicks Delete button
    public void ClickDeleteButton(string value) => DeleteTableButton(value).ClickViaJs();

    // returns "true" if the employee data is displayed in the table
    public bool IsEmployeeDataDisplayed(string value) => LastNameColumnTableValue(value).IsDisplayed();
}