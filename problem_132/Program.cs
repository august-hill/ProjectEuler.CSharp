// Answer: 843296
using System;

namespace Problem132;

internal static class Program
{
    static long ModPow(long b, long exp, long mod)
    {
        long result = 1;
        b %= mod;
        while (exp > 0)
        {
            if ((exp & 1) != 0) result = result * b % mod;
            b = b * b % mod;
            exp >>= 1;
        }
        return result;
    }

    static bool IsPrime(int n)
    {
        if (n < 2) return false;
        if (n < 4) return true;
        if (n % 2 == 0 || n % 3 == 0) return false;
        for (int i = 5; i * i <= n; i += 6)
            if (n % i == 0 || n % (i + 2) == 0) return false;
        return true;
    }

    static long Solve()
    {
        long sum = 0;
        int count = 0;
        for (int p = 2; count < 40; p++)
        {
            if (!IsPrime(p)) continue;
            if (p == 3) continue;
            if (ModPow(10, 1000000000L, p) == 1)
            {
                sum += p;
                count++;
            }
        }
        return sum;
    }

    static void Main() => Bench.Run(132, Solve);
}
