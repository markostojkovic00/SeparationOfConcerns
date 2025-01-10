using System.Runtime.CompilerServices;

namespace SeparationOfConcerns;

public class MultiplicationTable
{
    public static void For(List<int> numbers)
    {
        int biggest = findBiggestValue(numbers);
        int magnitude = findBiggestPossibleResult(biggest);
        createFormattedMultiplicationTable(magnitude
            , numbers);
    }

    public static int findBiggestValue(List<int> numbers)
    {
        var biggest = int.MinValue;
        foreach (var number in numbers)
        {
            if (number < 0)
            {
                throw new ArgumentException("negative numbers are not supported");
            }

            if (number > biggest)
            {
                biggest = number;
            }
        }

        return biggest;
    }

    public static int findBiggestPossibleResult(int biggest)
    {
        var biggestResult = biggest * biggest;
        var magnitude = 0;
        while (biggestResult > 0)
        {
            magnitude++;
            biggestResult /= 10;
        }

        magnitude++; // the magnitude (plus some space) will be used for the width

        return magnitude;
    }

    public static void createFormattedMultiplicationTable(int magnitude, List<int> numbers)
    {
        var titleRow = "";
        titleRow += "*".PadLeft(magnitude) + " ||";
        foreach (var col in numbers)
        {
            titleRow += $"{col}".PadLeft(magnitude) + " |";
        }

        Console.WriteLine(titleRow);
        for (var i = 0; i < titleRow.Length; i++)
        {
            Console.Write("=");
        }

        Console.WriteLine();
        foreach (var row in numbers)
        {
            Console.Write($"{row}".PadLeft(magnitude) + " ||");
            foreach (var col in numbers)
            {
                var product = row * col;
                Console.Write($"{product}".PadLeft(magnitude) + " |");
            }

            Console.WriteLine();
        }
    }
}