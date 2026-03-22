// Answer: 13717429 (sum of run-lengths 1 + 13717420 + 8)
using System;

namespace Problem175;

internal static class Program
{
    static long Solve()
    {
        long p = 123456789L, q = 987654321L;
        // Reduce by gcd
        long a = p, b = q;
        while (b != 0) { long t = b; b = a % b; a = t; }
        p /= a; q /= a;

        long[] runs = new long[1000];
        int nruns = 0;

        while (p > 0 && q > 0)
        {
            if (p <= q)
            {
                long k;
                if (p == q)
                {
                    k = 1;
                    q = 0;
                }
                else
                {
                    k = (q - 1) / p;
                    q -= k * p;
                    if (q == p) { k++; q = 0; }
                }
                runs[nruns++] = k;
            }
            else
            {
                long k = (p - 1) / q;
                p -= k * q;
                runs[nruns++] = k;
            }
        }

        // Reverse for MSB-first order
        for (int i = 0; i < nruns / 2; i++)
        {
            long t = runs[i]; runs[i] = runs[nruns - 1 - i]; runs[nruns - 1 - i] = t;
        }

        long sumRuns = 0;
        for (int i = 0; i < nruns; i++) sumRuns += runs[i];
        return sumRuns;
    }

    static void Main() => Bench.Run(175, Solve);
}
