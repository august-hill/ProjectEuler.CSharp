// Answer: 378158756814587
using System;

namespace Problem164;

internal static class Program
{
    static long Solve()
    {
        long[,] dp = new long[10, 10];
        long[,] ndp = new long[10, 10];

        for (int d1 = 1; d1 <= 9; d1++)
            for (int d2 = 0; d2 <= 9; d2++)
                dp[d1, d2] = 1;

        for (int pos = 3; pos <= 20; pos++)
        {
            Array.Clear(ndp, 0, ndp.Length);
            for (int d1 = 0; d1 <= 9; d1++)
            {
                for (int d2 = 0; d2 <= 9; d2++)
                {
                    if (dp[d1, d2] == 0) continue;
                    int maxD3 = 9 - d1 - d2;
                    if (maxD3 < 0) continue;
                    for (int d3 = 0; d3 <= maxD3; d3++)
                        ndp[d2, d3] += dp[d1, d2];
                }
            }
            Array.Copy(ndp, dp, dp.Length);
        }

        long total = 0;
        for (int d1 = 0; d1 <= 9; d1++)
            for (int d2 = 0; d2 <= 9; d2++)
                total += dp[d1, d2];
        return total;
    }

    static void Main() => Bench.Run(164, Solve);
}
