using System;
using System.Collections.Concurrent;
using System.Linq;
using Diploma.Data;
using Diploma.Data.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;

namespace Diploma.Common.Drivers
{
    public class WebDriverFactory
    {
        // collection created to isolate threads for possible parallelization
        private static readonly ConcurrentDictionary<string, IWebDriver> DriverCollection = new();

        public static IWebDriver Driver
        {
            get
            {
                if (!DriverCollection.Keys.Contains(TextContextValues
                        .ExecutableClassName)) // if driver is not initialized yet we do it
                {
                    InitializeDriver();
                }

                return DriverCollection.First(pair => pair.Key == TextContextValues.ExecutableClassName)
                    .Value; // return driver for needed test class
            }
            private set =>
                DriverCollection.TryAdd(TextContextValues.ExecutableClassName,
                    value); // new driver will be assigned only if DriverCollection doesn't contains value by this key
        }

        // return instance of Action
        public static Actions Actions => new Actions(Driver);

        // return instance of IJavaScriptExecutor
        public static IJavaScriptExecutor JavaScriptExecutor => (IJavaScriptExecutor)Driver;

        public static void QuitDriver() => Driver.Quit();

        // initialization method for driver
        private static void InitializeDriver()
        {
            Driver = TestSettings.Browser switch
            {
                Browsers.Chrome => new ChromeDriver(),
                Browsers.Edge => new EdgeDriver(),
                _ => throw new InvalidOperationException(),
            };
            Driver.Manage().Window.Maximize();
        }
    }
}