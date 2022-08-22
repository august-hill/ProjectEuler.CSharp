using System.Collections;
using System.Diagnostics;

namespace Problem41;

internal static class Program
{
    private static bool IsPandigital(int i)
    {
        var flags = new BitArray(10)
        {
            [0] = true
        };

        var k = 1;
        while (i != 0)
        {
            var digit = i % 10;
            if (flags[digit]) return false;
            flags[digit] = true;
            i = i / 10;
            ++k;
        }

        for (var j = 1; j < k; ++j)
            if (!flags[j])
                return false;

        return true;
    }

    private static void Main()
    {
        var timeTaken = Stopwatch.StartNew();
        // Note: Nine numbers cannot be done (1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 = 45 = > always dividable by 3)
        // Note: Eight numbers cannot be done (1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 = 36 = > always dividable by 3)

        const int pandigitalMax = 7654321;
        var p = new Primes(pandigitalMax);
        var primes = p.GetPrimeList();

        var result = 0;
        
        // search the list in reverse order
        for (var i = primes.Count - 1 ; i >= 0; i--)
        {
            if (IsPandigital(primes[i]))
            {
                result = primes[i];
                break;
            }
        }

        timeTaken.Stop();
        Console.WriteLine($"largest pandigital is {result} in {timeTaken.ElapsedMilliseconds} ms.");
        
        Debug.Assert(result == 7652413, "The correct answer is: 7652413.");
    }
}