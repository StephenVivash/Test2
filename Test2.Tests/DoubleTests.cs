using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Test2.Tests;

public class DoubleTests
{
    private static int InvokeDouble(int value)
    {
        var programAssembly = Assembly.Load("Test2");
        var programType = programAssembly.GetType("Program")
            ?? throw new InvalidOperationException("Program type not found.");

        var method = programType
            .GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
            .Single(m => m.Name.Contains("Double"));

        return (int)method.Invoke(null, new object[] { value })!;
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 4)]
    [InlineData(3, 6)]
    public void Double_ReturnsExpectedValue(int input, int expected)
    {
        var result = InvokeDouble(input);
        Assert.Equal(expected, result);
    }
}
