// Answer: 180180
using System;

namespace Problem108;

internal static class Program
{
    static readonly int[] Primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43 };
    static long _best;

    static void Search(int idx, long n, long divCount, int maxExp)
    {
        long solutions = (divCount + 1) / 2;
        if (solutions > 1000)
        {
            if (n < _best) _best = n;
            return;
        }
        if (idx >= Primes.Length) return;

        for (int e = maxExp; e >= 1; e--)
        {
            long newN = n;
            bool overflow = false;
            for (int j = 0; j < e; j++)
            {
                if (newN > _best / Primes[idx]) { overflow = true; break; }
                newN *= Primes[idx];
            }
            if (overflow || newN >= _best) continue;
            Search(idx + 1, newN, divCount * (2 * e + 1), e);
        }
    }

    static long Solve()
    {
        _best = (long)1e18;
        Search(0, 1, 1, 20);
        return _best;
    }

    static void Main() => Bench.Run(108, Solve);
}
