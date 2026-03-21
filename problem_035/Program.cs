// Answer: 55
using System;
using System.Collections;
using System.Collections.Generic;

namespace Problem35;

internal static class Program
{
    private static SortedSet<int> GeneratePrimes(int limit)
    {
        int sievebound = (limit - 1) / 2;
        BitArray sieve = new BitArray(sievebound + 1, false);
        int crosslimit = (Convert.ToInt32(Math.Floor(Math.Sqrt(limit))) - 1) / 2;
        for (int i = 1; i <= crosslimit; i++)
            if (!sieve[i])
                for (int j = 2 * i * (i + 1); j <= sievebound; j += 2 * i + 1)
                    sieve[j] = true;

        SortedSet<int> primes = new SortedSet<int>();
        primes.Add(2);
        for (int i = 1; i <= sievebound; i++)
            if (!sieve[i]) primes.Add(2 * i + 1);
        return primes;
    }

    private static SortedSet<int> Rotate(int p)
    {
        string s = p.ToString();
        int length = s.Length;
        SortedSet<int> result = new SortedSet<int>();
        for (int i = 0; i < length; i++)
        {
            string r = s.Substring(i, length - i) + s.Substring(0, i);
            result.Add(Convert.ToInt32(r));
        }
        return result;
    }

    static long Solve()
    {
        var Primes = GeneratePrimes(1000000);
        SortedSet<int> CircularPrimes = new SortedSet<int>();

        foreach (int p in Primes)
        {
            if (p < 9) { CircularPrimes.Add(p); continue; }
            SortedSet<int> rotations = Rotate(p);
            if (rotations.IsProperSubsetOf(Primes))
                CircularPrimes.Add(p);
        }

        return CircularPrimes.Count;
    }

    static void Main() => Bench.Run(35, Solve);
}
