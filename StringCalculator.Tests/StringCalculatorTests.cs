using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit.Abstractions;
using Xunit.Sdk;
using Assert = Xunit.Assert;
namespace StringCalculator.Tests;
public class StringCalculatorTests 
{
    private readonly StringCalculator StringCalculator;

    private readonly ITestOutputHelper _output;

    public StringCalculatorTests(ITestOutputHelper output)
    {
        _output = output;
        StringCalculator = new StringCalculator();
    }

    [Theory]
    [InlineData("5,4", 9)]
    public void Add_TwoNumbers_ReturnSum(string numbers, int expected)
    {
        var actual = StringCalculator.add(numbers);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("", 0)]
    public void Add_EmptyString_ReturnsZero(string numbers, int expected)
    {
        var actual = StringCalculator.add(numbers);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("6", 6)]
    public void Add_SingleInput_ReturnInput(string numbers, int expected)
    {
        var actual = StringCalculator.add(numbers);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(" ", 0)]
    public void Add_SpaceInput_ReturnZero(string numbers, int expected)
    {
        var actual = StringCalculator.add(numbers);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("6,", 6)]
    public void Add_SingleNumberWithComma_ReturnInput(string numbers, int expected)
    {
        var actual = StringCalculator.add(numbers);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("6,3,2,3", 14)]
    public void Add_MultipleNumbers_ReturnSum(string numbers, int expected)
    {
        var actual = StringCalculator.add(numbers);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("6, ,3,2,3", 14)]
    [InlineData("6, 3,2,3", 14)]
    public void Add_MultipleNumbersWithEmptySpace_ReturnSum(string numbers, int expected)
    {
        var actual = StringCalculator.add(numbers);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Add_NullInput_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => StringCalculator.add(null));
    }

    [Theory]
    [InlineData("6\n3,2,3", 14)]
    public void Add_MultipleNumbersWithNewLines_IgnoreNewLinesReturnSum(string numbers, int expected)
    {
        var actual = StringCalculator.add(numbers);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("6\n3,2,3,\n", 14)]
    [InlineData("6\n3,2,3,\n,", 14)]
    public void Add_MultipleNumbersWithNewLineFollowedByComma_IgnoreNewLineAndCommaReturnSum(string numbers, int expected)
    {
        var actual = StringCalculator.add(numbers);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("//;\n6;3;2;3;", 14)]
    [InlineData("//;|,\n6;3;2,3;", 14)]
    public void Add_MultipleNumbersWithCustomDelimiter_IgnoreNewLineAndCommaReturnSum(string numbers, int expected)
    {
        var actual = StringCalculator.add(numbers);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("5,4,-3")]
    [InlineData("5,-4,-3")]
    [InlineData("-5,-4,-3")]
    public void Add_NegativeNumber_ThrowsException(string numbers)
    {

        var Exception = Assert.Throws<Exception>(() => StringCalculator.add(numbers));
        _output.WriteLine(Exception.Message);
    }

    [Theory]
    [InlineData("6,3\n1001", 9)]
    [InlineData("20000,6,3\n1001,1003", 9)]
    public void Add_LargeNumbersGreaterThan1000_IgnoreLargeNumbersReturnSum(string numbers, int expected)
    {
        var actual = StringCalculator.add(numbers);

        Assert.Equal(expected, actual);
    }
}