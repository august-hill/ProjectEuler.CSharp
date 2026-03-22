// Answer: 2269
using System;

namespace Problem121;

internal static class Program
{
    static long Solve()
    {
        int n = 15;
        long[] dp = new long[n + 1];
        dp[0] = 1;

        for (int k = 1; k <= n; k++)
        {
            for (int j = k; j >= 1; j--)
                dp[j] = dp[j] * k + dp[j - 1];
            dp[0] *= k;
        }

        long denom = 1;
        for (int i = 1; i <= n + 1; i++) denom *= i;

        long winNum = 0;
        for (int j = n / 2 + 1; j <= n; j++)
            winNum += dp[j];

        return denom / winNum;
    }

    static void Main() => Bench.Run(121, Solve);
}
