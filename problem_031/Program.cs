// Answer: 73682

namespace Problem31;

internal static class Program
{
    static long Solve()
    {
        // Coin change DP: count ways to make 200 pence
        int[] coins = { 1, 2, 5, 10, 20, 50, 100, 200 };
        int target = 200;
        long[] ways = new long[target + 1];
        ways[0] = 1;
        foreach (int coin in coins)
        {
            for (int j = coin; j <= target; j++)
                ways[j] += ways[j - coin];
        }
        return ways[target];
    }

    static void Main() => Bench.Run(31, Solve);
}
