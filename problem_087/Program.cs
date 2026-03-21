// Answer: 1097343
using System;
using System.Collections.Generic;

namespace Problem87;

internal static class Program
{
    private static List<long> Sieve(int limit)
    {
        var isP = new bool[limit + 1];
        Array.Fill(isP, true);
        isP[0] = false; isP[1] = false;
        for (int i = 2; (long)i * i <= limit; i++)
            if (isP[i])
                for (int j = i * i; j <= limit; j += i) isP[j] = false;
        var primes = new List<long>();
        for (int i = 2; i <= limit; i++)
            if (isP[i]) primes.Add(i);
        return primes;
    }

    static long Solve()
    {
        const long LIMIT = 50_000_000;
        var primes = Sieve(7072);
        var seen = new bool[LIMIT];
        int count = 0;
        foreach (long r in primes)
        {
            long r4 = r * r * r * r;
            if (r4 >= LIMIT) break;
            foreach (long q in primes)
            {
                long q3 = q * q * q;
                if (r4 + q3 >= LIMIT) break;
                foreach (long p in primes)
                {
                    long p2 = p * p;
                    long total = r4 + q3 + p2;
                    if (total >= LIMIT) break;
                    if (!seen[total]) { seen[total] = true; count++; }
                }
            }
        }
        return count;
    }

    static void Main() => Bench.Run(87, Solve);
}
