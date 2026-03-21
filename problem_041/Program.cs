// Answer: 7652413
using System.Collections;

namespace Problem41;

internal static class Program
{
    private static bool IsPandigital(int i)
    {
        var flags = new BitArray(10)
        {
            [0] = true,
            [8] = true,
            [9] = true
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
            if (!flags[j]) return false;
        return true;
    }

    static long Solve()
    {
        const int pandigitalMax = 7654321;
        var p = new Primes(pandigitalMax);
        var primes = p.GetPrimeList();

        for (var i = primes.Count - 1; i >= 0; i--)
        {
            if (IsPandigital(primes[i]))
                return primes[i];
        }
        return 0;
    }

    static void Main() => Bench.Run(41, Solve);
}
