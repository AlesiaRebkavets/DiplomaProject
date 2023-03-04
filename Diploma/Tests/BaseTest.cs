using Diploma.Common.Drivers;
using NUnit.Framework;

namespace Diploma.Tests;

public class BaseTest
{
    // contains all the necessary methods to call them once before all tests in descendant classes
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        // setting the custom size of window
        //WebDriverFactory.Driver.Manage().Window.Size = new System.Drawing.Size(1200, 800);
    }

    // contains all necessary methods to call them once after all tests in descendant classes  
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        WebDriverFactory.QuitDriver();
    }
}