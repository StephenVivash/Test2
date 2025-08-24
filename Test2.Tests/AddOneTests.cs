using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Test2.Tests;

public class AddOneTests
{
    private static int InvokeAddOne(int value)
    {
        var programAssembly = Assembly.Load("Test2");
        var programType = programAssembly.GetType("Program")
            ?? throw new InvalidOperationException("Program type not found.");

        var method = programType
            .GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
            .Single(m => m.Name.Contains("AddOne"));

        return (int)method.Invoke(null, new object[] { value })!;
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 3)]
    [InlineData(3, 4)]
    public void AddOne_ReturnsExpectedValue(int input, int expected)
    {
        var result = InvokeAddOne(input);
        Assert.Equal(expected, result);
    }
}
