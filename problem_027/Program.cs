// Answer: -59231
using System;
using System.Collections;
using System.Collections.Generic;

namespace Problem27;

internal static class Program
{
    private static List<int> GeneratePrimes(int limit)
    {
        int sievebound = (limit - 1) / 2;
        BitArray sieve = new BitArray(sievebound + 1, false);
        int crosslimit = (Convert.ToInt32(Math.Floor(Math.Sqrt(limit))) - 1) / 2;
        for (int i = 1; i <= crosslimit; i++)
        {
            if (!sieve[i])
                for (int j = 2 * i * (i + 1); j <= sievebound; j += 2 * i + 1)
                    sieve[j] = true;
        }
        List<int> primes = new List<int>();
        for (int i = 1; i <= sievebound; i++)
            if (!sieve[i]) primes.Add(2 * i + 1);
        return primes;
    }

    static long Solve()
    {
        var Primes = GeneratePrimes(1000000);

        int Quadratic(int n, int a, int b) => (n * n) + (a * n) + b;

        int F(int a, int b)
        {
            int n = 0;
            while (true)
            {
                int p = Quadratic(n, a, b);
                if (p < 0 || Primes.BinarySearch(p) < 0) break;
                n++;
            }
            return n;
        }

        int max = 0;
        int bestProduct = 0;
        for (int a = -999; a < 1000; a++)
        {
            for (int b = -999; b < 1000; b++)
            {
                int count = F(a, b);
                if (count > max)
                {
                    max = count;
                    bestProduct = a * b;
                }
            }
        }
        return bestProduct;
    }

    static void Main() => Bench.Run(27, Solve);
}
