using System;
using Diploma.Data.Enums;
using Microsoft.Extensions.Configuration;

namespace Diploma.Data;

public static class TestSettings
{
    public static Browsers Browser { get; }
    public static string LoginPageUrl { get; }
    public static string AdminPageUrl { get; }
    public static string UserName { get; }
    public static string LoginPagePassword { get; }
    public static string InvalidUserName { get; }
    public static string InvalidPassword { get; }
    public static string AdminPageEmployeeName { get; }
    public static string AdminPagePassword { get; }
    public static string AdminPageUsername { get; }

    public static string PimPageFirstName { get; }

    public static string PimPageMiddleName { get; }

    public static string PimPageLastName { get; }

    public static string PimPageEmployeeId { get; }

    public static string BuzzPagePostText { get; }

    public static string BuzzPageEditedPostText { get; }


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
        PimPageFirstName = TestConfiguration["PimTestData:FirstName"];
        PimPageMiddleName = TestConfiguration["PimTestData:MiddleName"];
        PimPageLastName = TestConfiguration["PimTestData:LastName"];
        PimPageEmployeeId = TestConfiguration["PimTestData:EmployeeId"];
        BuzzPagePostText = TestConfiguration["BuzzTestData:PostText"];
        BuzzPageEditedPostText = TestConfiguration["BuzzTestData:EditedPostText"];
    }
}