using System.Numerics;

namespace StringCalculator;
public class StringCalculator
{
    public StringCalculator()
    {
    }

    public int add(string numbersToBeAdded)
    {
        numbersToBeAdded =numbersToBeAdded.Replace(" ", "");

        if (numbersToBeAdded == "")
        {
            return 0;
        }

        int[] NumbersToBeAdded=numbersToBeAdded.Split(',').Where(n => n!="").Select(n=>Int32.Parse(n)).ToArray();

        if(NumbersToBeAdded.Length == 1) 
        {
            return NumbersToBeAdded[0];

        }

        return NumbersToBeAdded[0] + NumbersToBeAdded[1];
    }
}
