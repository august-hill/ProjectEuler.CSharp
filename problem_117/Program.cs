// Answer: 100808458960497
using System;

namespace Problem117;

internal static class Program
{
    static long Solve()
    {
        int n = 50;
        long[] dp = new long[n + 1];
        dp[0] = 1;
        for (int i = 1; i <= n; i++)
        {
            dp[i] = dp[i - 1];
            if (i >= 2) dp[i] += dp[i - 2];
            if (i >= 3) dp[i] += dp[i - 3];
            if (i >= 4) dp[i] += dp[i - 4];
        }
        return dp[n];
    }

    static void Main() => Bench.Run(117, Solve);
}
