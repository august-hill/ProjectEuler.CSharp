// Answer: 71
using System;
using System.Collections.Generic;

namespace Problem77;

internal static class Program
{
    static long Solve()
    {
        const int sieveLimit = 1000;
        bool[] isPrime = new bool[sieveLimit];
        Array.Fill(isPrime, true);
        isPrime[0] = isPrime[1] = false;
        for (int i = 2; i * i < sieveLimit; i++)
            if (isPrime[i])
                for (int j = i * i; j < sieveLimit; j += i)
                    isPrime[j] = false;

        List<int> primes = new();
        for (int i = 2; i < sieveLimit; i++)
            if (isPrime[i]) primes.Add(i);

        for (int target = 2; target < sieveLimit; target++)
        {
            long[] dp = new long[target + 1];
            dp[0] = 1;
            foreach (int p in primes)
            {
                if (p > target) break;
                for (int i = p; i <= target; i++)
                    dp[i] += dp[i - p];
            }
            if (dp[target] > 5000) return target;
        }
        return 0;
    }

    static void Main() => Bench.Run(77, Solve);
}
