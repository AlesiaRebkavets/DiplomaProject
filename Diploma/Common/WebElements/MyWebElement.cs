using System.Collections.ObjectModel;
using System.Drawing;
using Diploma.Common.Drivers;
using Diploma.Common.Extensions;
using OpenQA.Selenium;

namespace Diploma.Common.WebElements
{
    public class MyWebElement: IWebElement
    {
        // constructor to initialize an instance of the element
        public MyWebElement(By by)
        {
            By = by;
        }
        
        // property for locator 
        protected By By { get; set; }
        
        // protected property for IWebElement returns value using IWebDriver extension method GetWebElementWhenExist
        // after that we can be sure that element is always in a stable state and prevent possible exceptions
        protected IWebElement WebElement => WebDriverFactory.Driver.GetWebElementWhenExist(By);
        
        // default IWebElement properties
        
        public string TagName => WebElement.TagName;

        public string Text => WebElement.Text;
        
        public string GetText()
        {
            ScrollIntoView();
            return WebElement.Text;
        }

        public bool Enabled => WebElement.Enabled;

        public bool Selected => WebElement.Selected;

        public Point Location => WebElement.Location;

        public Size Size => WebElement.Size;

        public bool Displayed => WebElement.Displayed;
        
        // default IWebElement methods

        public void Clear() => WebElement.Clear();
        
        public void Click()
        {
            try
            {
                
                WebElement.Click();
            }
            catch (ElementClickInterceptedException) // here we can handle if click is intercepted and scroll element into view
            {
                ScrollIntoView();
                WebElement.Click();
            }
        }

        public IWebElement FindElement(By by) => WebElement.FindElement(by);

        public ReadOnlyCollection<IWebElement> FindElements(By by) => WebElement.FindElements(by);

        public string GetAttribute(string attributeName) => WebElement.GetAttribute(attributeName);

        public string GetCssValue(string propertyName) => WebElement.GetCssValue(propertyName);

        public string GetDomAttribute(string attributeName) => WebElement.GetDomAttribute(attributeName);

        public string GetDomProperty(string propertyName) => WebElement.GetDomProperty(propertyName);

        public ISearchContext GetShadowRoot() => WebElement.GetShadowRoot();

        public void SendKeys(string text) => WebElement.SendKeys(text);

        public void Submit() => WebElement.Submit();
        
        // custom methods
        
        // method to scroll element into view using JaveScript

        public void ScrollIntoView() =>
            WebDriverFactory.JavaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView()", WebElement);

        // method to click element using JaveScript
        public void ClickElement() => WebDriverFactory.JavaScriptExecutor.ExecuteScript("arguments[0].click();", WebElement);   //WebDriverFactory.Actions.MoveToElement(WebElement).Click().Perform();
        
        // method to get value of class attribute 
        public string GetValueOfClassAttribute() => GetAttribute("class");
    }
}