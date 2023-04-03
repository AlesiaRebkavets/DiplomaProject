using Diploma.Common.WebElements;
using OpenQA.Selenium;

namespace Diploma.PageObjects;

public class UserManagementPage : BasePage
{
    // saving locators of UserManagementPage
    private MyWebElement _addButton = new MyWebElement(By.CssSelector(".orangehrm-header-container .oxd-button--secondary"));

    private MyTable UsernameColumnTableValue(string value) => new MyTable(By.XPath($"//*[text()='{value}']"));

    private MyTable DeleteTableButton(string value) => new MyTable(By.XPath($"//*[.//text()='{value}'][contains(@class, 'oxd-table-row')]//*[./@class='oxd-icon bi-trash']"));

    // clicks Add button
    public void ClickAddButton() => _addButton.ClickViaJs();

    // returns Username value displayed in the table 
    public string GetUsernameColumnTableValue(string value) => UsernameColumnTableValue(value).GetUsernameColumnTableValue(value);

    // returns "true" if Username is displayed in the table
    public bool IsUsernameDisplayedInTheTable(string value) => UsernameColumnTableValue(value).IsValueDisplayedInTheTable(value);

    // clicks Delete button
    public void ClickDeleteTableButton(string value) => DeleteTableButton(value).ClickViaJs();
}