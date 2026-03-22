// Answer: 134043
using System;

namespace Problem47;

internal static class Program
{
    const int Limit = 150000;
    const int Consecutive = 4;

    private static int CountDistinctPrimeFactors(int n, int[] primes)
    {
        int count = 0;
        foreach (int p in primes)
        {
            if ((long)p * p > n) break;
            if (n % p == 0)
            {
                count++;
                while (n % p == 0) n /= p;
            }
        }
        if (n > 1) count++;
        return count;
    }

    static long Solve()
    {
        // Sieve primes up to Limit/2
        int sieveLimit = Limit / 2;
        bool[] isPrime = new bool[sieveLimit + 1];
        Array.Fill(isPrime, true);
        isPrime[0] = isPrime[1] = false;
        for (int i = 2; i * i <= sieveLimit; i++)
            if (isPrime[i])
                for (int j = i * i; j <= sieveLimit; j += i)
                    isPrime[j] = false;

        var primes = new System.Collections.Generic.List<int>();
        for (int i = 2; i <= sieveLimit; i++)
            if (isPrime[i]) primes.Add(i);
        int[] primesArr = primes.ToArray();

        int count = 0;
        for (int i = 2; i < Limit; i++)
        {
            if (CountDistinctPrimeFactors(i, primesArr) == Consecutive)
            {
                count++;
                if (count == Consecutive) return i - Consecutive + 1;
            }
            else
            {
                count = 0;
            }
        }
        return 0;
    }

    static void Main() => Bench.Run(47, Solve);
}
