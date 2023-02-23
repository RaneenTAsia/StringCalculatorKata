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
    public void Add_SpaceInput_Return0(string numbers,int expected)
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

}