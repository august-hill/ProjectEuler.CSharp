// Answer: 20492570929
using System;

namespace Problem116;

internal static class Program
{
    static long CountWays(int tileLen, int n)
    {
        long[] dp = new long[n + 1];
        dp[0] = 1;
        for (int i = 1; i <= n; i++)
        {
            dp[i] = dp[i - 1];
            if (i >= tileLen)
                dp[i] += dp[i - tileLen];
        }
        return dp[n] - 1;
    }

    static long Solve()
    {
        int n = 50;
        return CountWays(2, n) + CountWays(3, n) + CountWays(4, n);
    }

    static void Main() => Bench.Run(116, Solve);
}
