using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Xunit.Assert;

namespace StringCalculator.Tests;

public class StringCalculatorTests
{
    private readonly StringCalculator StringCalculator = new StringCalculator();

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
    [InlineData(" ",0)]
    public void Add_SpaceInput_ReturnZero(string numbers,int expected)
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
       Assert.Throws<ArgumentNullException>(()=>StringCalculator.add(null));
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

}