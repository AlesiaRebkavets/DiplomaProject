using NUnit.Framework;

namespace Diploma.Data;

// class to get values from TestContext
public static class TextContextValues
{
    public static string ExecutableClassName => TestContext.CurrentContext.Test.ClassName;
}