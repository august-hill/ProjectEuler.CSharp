// Answer: 371048281
using System;

namespace Problem190;

internal static class Program
{
    static long Solve()
    {
        long total = 0;
        for (int m = 2; m <= 15; m++)
        {
            double logPm = 0.0;
            for (int k = 1; k <= m; k++)
                logPm += k * Math.Log(2.0 * k / (m + 1));
            total += (long)Math.Floor(Math.Exp(logPm));
        }
        return total;
    }

    static void Main() => Bench.Run(190, Solve);
}
