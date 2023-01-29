using System;
using System.Dynamic;
using Diploma.Data.Enums;
using Microsoft.Extensions.Configuration;

namespace Diploma.Data;

public static class TestSettings
{
    public static Browsers Browser { get; set; }
    public static string LoginPageUrl { get; set; }
    public static string AdminPageUrl { get; set; }
    public static string UserName { get; set; }
    public static string LoginPagePassword { get; set; }
    public static string InvalidUserName { get; set; }
    public static string InvalidPassword { get; set; }
    public static string AdminPageEmployeeName { get; set; }
    public static string AdminPagePassword { get; set; }
    public static string AdminPageUsername { get; set; }
    

    // after Build() it will contain context of .json file

    public static IConfiguration TestConfiguration { get; } =
        new ConfigurationBuilder().AddJsonFile("testsettings.json").Build();

    static TestSettings()
    {
        // getting values from .json file by keys
        Enum.TryParse(TestConfiguration["Common:Browser"], out Browsers browser);
        Browser = browser;
        LoginPageUrl = TestConfiguration["Common:Urls:LoginPage"];
        AdminPageUrl = TestConfiguration["Common:Urls:AdminPage"];
        UserName = TestConfiguration["LoginTestData:UserName"];
        LoginPagePassword = TestConfiguration["LoginTestData:Password"];
        InvalidUserName = TestConfiguration["LoginTestData:InvalidUserName"];
        InvalidPassword = TestConfiguration["LoginTestData:InvalidPassword"];
        AdminPageEmployeeName = TestConfiguration["AdminTestData:EmployeeName"];
        AdminPagePassword = TestConfiguration["AdminTestData:Password"];
        AdminPageUsername = TestConfiguration["AdminTestData:Username"];
    }
}