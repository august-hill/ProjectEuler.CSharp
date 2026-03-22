// Answer: 9350130049860600
using System;

namespace Problem110;

internal static class Program
{
    static readonly int[] Primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47 };
    static double _best;
    static int[] _bestExps = new int[15];

    static void Search(int idx, double logn, long divCount, int maxExp, int[] exps)
    {
        if (divCount > 7999999)
        {
            if (logn < _best)
            {
                _best = logn;
                Array.Copy(exps, _bestExps, Primes.Length);
            }
            return;
        }

        if (idx >= Primes.Length) return;

        // Pruning
        long remaining = 1;
        for (int i = idx; i < Primes.Length; i++)
        {
            remaining *= (2 * maxExp + 1);
            if (remaining > (long)1e18) break;
        }
        if (divCount * remaining <= 7999999) return;

        for (int e = maxExp; e >= 1; e--)
        {
            double newLogn = logn + e * Math.Log(Primes[idx]);
            if (newLogn >= _best) continue;
            exps[idx] = e;
            Search(idx + 1, newLogn, divCount * (2 * e + 1), e, exps);
        }
        exps[idx] = 0;
        Search(idx + 1, logn, divCount, maxExp, exps);
    }

    static long Solve()
    {
        _best = 1e30;
        int[] exps = new int[15];
        Search(0, 0.0, 1, 7, exps);

        long result = 1;
        for (int i = 0; i < Primes.Length; i++)
            for (int j = 0; j < _bestExps[i]; j++)
                result *= Primes[i];
        return result;
    }

    static void Main() => Bench.Run(110, Solve);
}
