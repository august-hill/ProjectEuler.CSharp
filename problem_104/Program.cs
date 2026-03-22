// Answer: 329468
using System;

namespace Problem104;

internal static class Program
{
    static bool IsPandigital(long n)
    {
        int digits = 0;
        for (int i = 0; i < 9; i++)
        {
            int d = (int)(n % 10);
            n /= 10;
            if (d == 0) return false;
            if ((digits & (1 << d)) != 0) return false;
            digits |= (1 << d);
        }
        return digits == 0x3FE;
    }

    static long Solve()
    {
        const long MOD = 1000000000L;
        long a = 1, b = 1;
        double logPhi = Math.Log10((1.0 + Math.Sqrt(5.0)) / 2.0);
        double logSqrt5 = Math.Log10(5.0) / 2.0;

        for (int k = 3; ; k++)
        {
            long c = (a + b) % MOD;
            a = b;
            b = c;

            if (IsPandigital(b))
            {
                double logFk = (double)k * logPhi - logSqrt5;
                double frac = logFk - Math.Floor(logFk);
                long first9 = (long)Math.Pow(10.0, frac + 8.0);
                if (IsPandigital(first9))
                    return k;
            }
        }
    }

    static void Main() => Bench.Run(104, Solve);
}
