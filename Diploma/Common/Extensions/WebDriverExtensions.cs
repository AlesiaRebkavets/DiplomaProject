using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Diploma.Common.Extensions
{
    public static class WebDriverExtensions
    {
        // extension method to get WebDriverWait
        // this method extends IWebDriver functionality
        public static WebDriverWait GetWebDriverWait(this IWebDriver driver, int timeoutSeconds = 30,
            TimeSpan? pollingInterval = null, params Type[] exceptionTypes)
        {
            var webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            if (pollingInterval != null) // we can set our custom polling interval 
            {
                webDriverWait.PollingInterval = (TimeSpan)pollingInterval;
            }
            webDriverWait.IgnoreExceptionTypes(exceptionTypes); // allows us to ignore any type of exception 
            return webDriverWait;
        }
        
        // extension method to perform FindElement with explicit wait
        public static IWebElement GetWebElementWhenExist(this IWebDriver driver, By by) =>
            driver.GetWebDriverWait().Until(drv => drv.FindElement(by));
    }
}