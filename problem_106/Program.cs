// Answer: 21384
using System;

namespace Problem106;

internal static class Program
{
    static long Comb(int n, int k)
    {
        if (k > n || k < 0) return 0;
        if (k > n - k) k = n - k;
        long result = 1;
        for (int i = 0; i < k; i++)
            result = result * (n - i) / (i + 1);
        return result;
    }

    static long Catalan(int n) => Comb(2 * n, n) / (n + 1);

    static long Solve()
    {
        int n = 12;
        long total = 0;
        for (int k = 2; k <= n / 2; k++)
        {
            long pairsTotal = Comb(n, 2 * k) * Comb(2 * k, k) / 2;
            long pairsOk = Comb(n, 2 * k) * Catalan(k);
            total += pairsTotal - pairsOk;
        }
        return total;
    }

    static void Main() => Bench.Run(106, Solve);
}
