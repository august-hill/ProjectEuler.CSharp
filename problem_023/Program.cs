// Answer: 4179871
using System;

namespace Problem23;

internal static class Program
{
    private static int[] _sumDiv;

    static long Solve()
    {
        const int limit = 28124;

        if (_sumDiv == null)
        {
            // Sieve for sum of proper divisors
            _sumDiv = new int[limit];
            for (int i = 1; i < limit; i++)
            {
                for (int j = 2 * i; j < limit; j += i)
                {
                    _sumDiv[j] += i;
                }
            }
        }

        // Find abundant numbers
        bool[] isAbundant = new bool[limit];
        int[] abundants = new int[limit];
        int count = 0;
        for (int i = 12; i < limit; i++)
        {
            if (_sumDiv[i] > i)
            {
                isAbundant[i] = true;
                abundants[count++] = i;
            }
        }

        // Mark numbers expressible as sum of two abundants
        bool[] expressible = new bool[limit];
        for (int i = 0; i < count; i++)
        {
            for (int j = i; j < count; j++)
            {
                int s = abundants[i] + abundants[j];
                if (s >= limit) break;
                expressible[s] = true;
            }
        }

        long sum = 0;
        for (int i = 1; i < limit; i++)
        {
            if (!expressible[i]) sum += i;
        }
        return sum;
    }

    static void Main() => Bench.Run(23, Solve);
}
