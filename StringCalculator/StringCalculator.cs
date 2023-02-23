using System.Numerics;

namespace StringCalculator;
public class StringCalculator
{
    public StringCalculator()
    {
    }

    public int add(string? numbersToBeAdded)
    {
        if (numbersToBeAdded == null)
        {
            throw new ArgumentNullException();
        }

        numbersToBeAdded = numbersToBeAdded.Replace(" ", "");

        int[] NumbersToBeAdded=numbersToBeAdded.Split(',').Where(n => n!="").Select(n=>Int32.Parse(n)).ToArray();

        int sum = 0;
        for (int i = 0; i < NumbersToBeAdded.Length; i++)
        {
            sum = sum + NumbersToBeAdded[i];
        }

        return sum;
    }
}
