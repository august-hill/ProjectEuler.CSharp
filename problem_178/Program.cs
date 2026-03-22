// Answer: 126461847755
using System;

namespace Problem178;

internal static class Program
{
    static long Solve()
    {
        long[,] dp = new long[10, 1024];
        long[,] ndp = new long[10, 1024];
        long total = 0;
        int fullMask = (1 << 10) - 1;

        for (int d = 1; d <= 9; d++)
            dp[d, 1 << d] = 1;

        for (int len = 2; len <= 40; len++)
        {
            Array.Clear(ndp, 0, ndp.Length);
            for (int d = 0; d <= 9; d++)
            {
                for (int mask = 0; mask < 1024; mask++)
                {
                    if (dp[d, mask] == 0) continue;
                    long val = dp[d, mask];
                    if (d > 0) ndp[d - 1, mask | (1 << (d - 1))] += val;
                    if (d < 9) ndp[d + 1, mask | (1 << (d + 1))] += val;
                }
            }
            for (int d = 0; d <= 9; d++)
                total += ndp[d, fullMask];
            Array.Copy(ndp, dp, dp.Length);
        }

        return total;
    }

    static void Main() => Bench.Run(178, Solve);
}
