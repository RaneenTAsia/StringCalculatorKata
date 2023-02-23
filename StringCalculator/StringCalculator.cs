using System.Numerics;

namespace StringCalculator;
public class StringCalculator
{
    public StringCalculator()
    {
    }

    public int add(string? numbersString)
    {
        if (numbersString == null)
        {
            throw new ArgumentNullException();
        }

        numbersString = numbersString.Replace(" ", "");

        string[] Delimiters = GetDelimiterConfigurations(ref numbersString);

        int[] NumbersToBeAdded = GetNumbersToBeAdded(numbersString, Delimiters);

        return GetSum(NumbersToBeAdded);
    }

    private static int GetSum(int[] NumbersToBeAdded)
    {
        int sum = 0;
        for (int i = 0; i < NumbersToBeAdded.Length; i++)
        {
            sum = sum + NumbersToBeAdded[i];
        }

        return sum;
    }

    private static int[] GetNumbersToBeAdded(string numbersString, string[] Delimiters)
    {
        int[] NumbersToBeAdded = GetNumbersFromInput(numbersString, Delimiters);

        CheckForNegativeInArray(NumbersToBeAdded);

        NumbersToBeAdded = RemoveLargeNumbers(NumbersToBeAdded);

        return NumbersToBeAdded;
    }

    private static int[] GetNumbersFromInput(string numbersString, string[] Delimiters)
    {
        return numbersString.Split(Delimiters, StringSplitOptions.None).Where(n => n != "").Select(n => Int32.Parse(n)).ToArray();
    }

    private static void CheckForNegativeInArray(int[] NumbersToBeAdded)
    {
        if (NumbersToBeAdded.Any(n => n < 0))
        {
            throw new Exception($"Negatives Not Allowed: {string.Join(",", NumbersToBeAdded.Where(n => n < 0).ToList())}");
        }
    }

    private static int[] RemoveLargeNumbers(int[] NumbersToBeAdded)
    {
        return NumbersToBeAdded.Where(val => val < 1001).ToArray();
    }

    private string[] GetDelimiterConfigurations(ref string numbersString)
    {
        string[] Delimiters;

        int CustomDelimiterBeginningIndicatorIndex = numbersString.IndexOf("//");

        if (CustomDelimiterBeginningIndicatorIndex != -1)
        {
            int CustomDelimiterEndingIndicatorIndex = numbersString.Substring(CustomDelimiterBeginningIndicatorIndex).IndexOf("\n");

            Delimiters = GetCustomDelimiters(numbersString, CustomDelimiterBeginningIndicatorIndex, CustomDelimiterEndingIndicatorIndex);
            numbersString = numbersString.Substring(CustomDelimiterEndingIndicatorIndex + 1);
        }
        else
        {
            Delimiters = new string[] { "\n", "," };
        }

        return Delimiters;
    }

    private string[] GetCustomDelimiters(String numberString, int CustomDelimiterBeginningIndicatorIndex, int CustomDelimiterEndingIndicatorIndex)
    {
        return numberString.Substring(CustomDelimiterBeginningIndicatorIndex + 2, CustomDelimiterEndingIndicatorIndex - CustomDelimiterBeginningIndicatorIndex - 2).Split("|");
    }
}
