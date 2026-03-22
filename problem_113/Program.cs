// Answer: 51161058134250
using System;

namespace Problem113;

internal static class Program
{
    static long Comb(int n, int k)
    {
        if (k > n || k < 0) return 0;
        if (k > n - k) k = n - k;
        // Use checked arithmetic; numbers stay in long range for these values
        long result = 1;
        for (int i = 0; i < k; i++)
            result = result * (n - i) / (i + 1);
        return result;
    }

    static long Solve()
    {
        int n = 100;
        long increasing = Comb(n + 9, 9) - 1;
        long decreasing = Comb(n + 10, 10) - (n + 1);
        long flat = 9L * n;
        return increasing + decreasing - flat;
    }

    static void Main() => Bench.Run(113, Solve);
}
