// Answer: 16576
using System;

namespace Problem160;

internal static class Program
{
    static long PowerMod(long b, long exp, long mod)
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

    // Product of i for i=1..n with all factors of p removed, mod pk
    static long Factmod(long n, long p, long pk)
    {
        if (n <= 1) return 1;

        long fullPeriodProd = 1;
        for (long i = 1; i <= pk; i++)
            if (i % p != 0) fullPeriodProd = fullPeriodProd * (i % pk) % pk;

        long numFull = n / pk;
        long result = PowerMod(fullPeriodProd, numFull, pk);

        long remainder = n % pk;
        for (long i = 1; i <= remainder; i++)
            if (i % p != 0) result = result * i % pk;

        result = result * Factmod(n / p, p, pk) % pk;
        return result;
    }

    static long CountFactors(long n, long p)
    {
        long count = 0;
        long pk = p;
        while (pk <= n) { count += n / pk; pk *= p; }
        return count;
    }

    static long Solve()
    {
        long N = 1000000000000L;
        long v5 = CountFactors(N, 5);

        long mod5 = 3125;
        long r5 = Factmod(N, 5, mod5);
        // phi(3125) = 2500
        long inv2Mod3125 = PowerMod(2, 2499, mod5);
        long fMod3125 = r5 * PowerMod(inv2Mod3125, v5 % 2500, mod5) % mod5;

        long fMod32 = 0;

        long inv32 = PowerMod(32, 2499, mod5);
        long k = fMod3125 * inv32 % mod5;
        long result = 32 * k;

        return result % 100000;
    }

    static void Main() => Bench.Run(160, Solve);
}
