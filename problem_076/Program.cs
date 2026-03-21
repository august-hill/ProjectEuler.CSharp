// Answer: 190569291

namespace Problem76;

internal static class Program
{
    static long Solve()
    {
        int target = 100;
        long[] dp = new long[target + 1];
        dp[0] = 1;
        for (int part = 1; part < target; part++)
            for (int i = part; i <= target; i++)
                dp[i] += dp[i - part];
        return dp[target];
    }

    static void Main() => Bench.Run(76, Solve);
}
