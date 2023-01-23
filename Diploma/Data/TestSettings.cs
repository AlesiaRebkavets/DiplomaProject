using System;
using System.Dynamic;
using Diploma.Data.Enums;
using Microsoft.Extensions.Configuration;

namespace Diploma.Data;

public static class TestSettings
{
    public static Browsers Browser { get; set; }
    public static string UserName { get; set; }
    public static string Password { get; set; }
    public static string InvalidUserName { get; set; }
    public static string InvalidPassword { get; set; }
    public static string LoginPageUrl { get; set; }
    
    // after Build() it will contain context of .json file

    public static IConfiguration TestConfiguration { get; } =
        new ConfigurationBuilder().AddJsonFile("testsettings.json").Build();

    static TestSettings()
    {
        // getting values from .json file by keys
        Enum.TryParse(TestConfiguration["Common:Browser"], out Browsers browser);
        Browser = browser;
        LoginPageUrl = TestConfiguration["Common:Urls:LoginPage"];
        UserName = TestConfiguration["LoginTestData:UserName"];
        Password = TestConfiguration["LoginTestData:Password"];
        InvalidUserName = TestConfiguration["LoginTestData:InvalidUserName"];
        InvalidPassword = TestConfiguration["LoginTestData:InvalidPassword"];
    }
}