// Answer: 1918080160
using System;

namespace Problem191;

internal static class Program
{
    static long Solve()
    {
        long[,,] dp = new long[31, 3, 2];
        dp[0, 0, 0] = 1;

        for (int day = 0; day < 30; day++)
        {
            for (int a = 0; a < 3; a++)
            {
                for (int l = 0; l < 2; l++)
                {
                    if (dp[day, a, l] == 0) continue;
                    long val = dp[day, a, l];
                    dp[day + 1, 0, l] += val;
                    if (l < 1) dp[day + 1, 0, l + 1] += val;
                    if (a < 2) dp[day + 1, a + 1, l] += val;
                }
            }
        }

        long total = 0;
        for (int a = 0; a < 3; a++)
            for (int l = 0; l < 2; l++)
                total += dp[30, a, l];
        return total;
    }

    static void Main() => Bench.Run(191, Solve);
}
