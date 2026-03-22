// Problem 198: Ambiguous Numbers
// Answer: 52374425
using System;

namespace Problem198;

internal static class Program
{
    const int N = 100_000_000;
    static sbyte[]? mu = null;
    static bool initialized = false;

    static void Init()
    {
        mu = new sbyte[N + 1];
        for (int i = 0; i <= N; i++) mu[i] = 1;
        mu[0] = 0;

        int[] lp = new int[N + 1];
        int[] primes = new int[6_000_000];
        int nprimes = 0;

        for (int p = 2; p <= N; p++)
        {
            if (lp[p] == 0)
            {
                lp[p] = p;
                primes[nprimes++] = p;
                mu[p] = -1;
            }
            for (int j = 0; j < nprimes; j++)
            {
                long q = primes[j];
                if (q > lp[p] || p * q > N) break;
                lp[(int)(p * q)] = primes[j];
                if (p % primes[j] == 0)
                    mu[(int)(p * q)] = 0;
                else
                    mu[(int)(p * q)] = (sbyte)(-mu[p]);
            }
        }
    }

    static long F(long M)
    {
        if (M <= 100) return 0;
        long A = (M - 1) / 100;
        return A * (M - 50 * A - 50);
    }

    static long Solve()
    {
        if (!initialized) { Init(); initialized = true; }
        long ans = 0;
        for (int d = 1; d <= N; d++)
        {
            if (mu![d] == 0) continue;
            long M = (long)N / d;
            if (M <= 100) continue;
            ans += mu[d] * F(M);
        }
        return ans;
    }

    static void Main() => Bench.Run(198, Solve);
}
