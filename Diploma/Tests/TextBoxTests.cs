using System.Configuration;
using Diploma.Common.Drivers;
using Diploma.Data;
using Diploma.Data.Constants;
using Diploma.PageObjects;
using NUnit.Framework;

namespace Diploma.Tests;

public class TextBoxTests: BaseTest
{
    /*// used to go to URL to make sure that each test from the class will start from initial state
    [SetUp]
    public void TextBoxTestSetUp()
    {
        WebDriverFactory.Driver.Navigate().GoToUrl(TestSettings.TextBoxPageUrl);
    }*/

    /*[Test]
    public void EnterFullNameAndEmailTenSubmit()
    {
        // initialize Page Object
        var textBoxPage = new TextBoxPage();

        // methods from BasePage
        // category names from constants
        textBoxPage.ExpandCategory(Categories.Elements);
        textBoxPage.ExpandCategory(Categories.Forms);
        
        //method from page objects
        // test data from testsettings.json
        textBoxPage.EnterFullName(TestSettings.UserName);
        textBoxPage.EnterEmail(TestSettings.UserEmail);
        textBoxPage.ClickSubmitButton();
        var userNameResultText = textBoxPage.GetNameResultText();
        var userEmailResultText = textBoxPage.GetEmailResultText();
        
        Assert.AreEqual($"Name:{TestSettings.UserName}", userNameResultText);
        Assert.AreEqual($"Email:{TestSettings.UserEmail}", userEmailResultText);
    }*/
    
    
}