// Answer: 2129970655314432
using System;

namespace Problem148;

internal static class Program
{
    static long Solve()
    {
        long N = 1000000000L;

        int[] digits = new int[20];
        int ndigits = 0;
        long tmp = N;
        while (tmp > 0)
        {
            digits[ndigits++] = (int)(tmp % 7);
            tmp /= 7;
        }
        // digits[0] is least significant

        long[] pow28 = new long[ndigits];
        pow28[0] = 1;
        for (int i = 1; i < ndigits; i++) pow28[i] = pow28[i - 1] * 28;

        long total = 0;
        long multiplier = 1;
        for (int i = ndigits - 1; i >= 0; i--)
        {
            int d = digits[i];
            total += multiplier * d * (d + 1) / 2 * pow28[i];
            multiplier *= (d + 1);
        }

        return total;
    }

    static void Main() => Bench.Run(148, Solve);
}
