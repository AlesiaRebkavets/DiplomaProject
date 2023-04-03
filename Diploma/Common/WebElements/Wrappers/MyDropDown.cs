using OpenQA.Selenium;

namespace Diploma.Common.WebElements;

public class MyDropDown : MyWebElement
{
    public MyDropDown(By by) : base(by)
    {
    }

    public void SelectValue(string value)
    {
        Click();
        GetDropDownValue(value).Click();
    }

    public void EnterDataAndSelectValue(string value)
    {
        SendKeys(value);
        GetDropDownValue(value).Click();
    }

    private MyWebElement GetDropDownValue(string value) => new MyWebElement(By.XPath($"//*[@role='option']//*[text()='{value}']"));
}