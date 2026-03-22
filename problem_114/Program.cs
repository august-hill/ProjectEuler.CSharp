// Answer: 16475640049
using System;

namespace Problem114;

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
            for (int len = 3; len <= i; len++)
            {
                int start = i - len;
                if (start == 0)
                    dp[i] += 1;
                else if (start == 1)
                    dp[i] += 1;
                else
                    dp[i] += dp[start - 1];
            }
        }

        return dp[n];
    }

    static void Main() => Bench.Run(114, Solve);
}
