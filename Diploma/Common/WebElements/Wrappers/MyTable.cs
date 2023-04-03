using OpenQA.Selenium;

namespace Diploma.Common.WebElements;

public class MyTable : MyWebElement
{
    public MyTable(By by) : base(by)
    {
    }

    public string GetUsernameColumnTableValue(string value) => GetTableValue(value).GetText();

    public bool IsValueDisplayedInTheTable(string value) => GetTableValue(value).IsDisplayed();

    private MyWebElement GetTableValue(string value) => new MyWebElement(By.XPath($"//*[@role='cell']//*[text()='{value}']"));
}