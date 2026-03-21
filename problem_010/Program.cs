// Answer: 142913828922
using System;
using System.Collections;

namespace Problem10;

internal static class Program
{
    static long Solve()
    {
        const int limit = 2000000;
        var upperLimit = (limit - 1) / 2;
        var sieve = new BitArray(upperLimit + 1, true);

        var greatestMultiple = (Convert.ToInt32(Math.Floor(Math.Sqrt(limit))) - 1) / 2;
        for (var i = 1; i <= greatestMultiple; i++)
            if (sieve[i])
                for (var j = 2 * i * (i + 1); j <= upperLimit; j += 2 * i + 1)
                    sieve[j] = false;

        long sum = 2;
        for (var i = 1; i <= upperLimit; i++)
            if (sieve[i])
                sum += 2 * i + 1;

        return sum;
    }

    static void Main() => Bench.Run(10, Solve);
}
