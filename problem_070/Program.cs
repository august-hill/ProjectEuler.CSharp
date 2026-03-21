// Answer: 8319823
using System;

namespace Problem70;

internal static class Program
{
    private static bool IsPermutation(int a, int b)
    {
        Span<int> da = stackalloc int[10];
        Span<int> db = stackalloc int[10];
        while (a > 0) { da[a % 10]++; a /= 10; }
        while (b > 0) { db[b % 10]++; b /= 10; }
        for (int i = 0; i < 10; i++)
            if (da[i] != db[i]) return false;
        return true;
    }

    static long Solve()
    {
        const int limit = 10_000_000;
        var phi = new int[limit];
        for (int i = 0; i < limit; i++) phi[i] = i;
        for (int i = 2; i < limit; i++)
        {
            if (phi[i] == i)
                for (int j = i; j < limit; j += i)
                    phi[j] -= phi[j] / i;
        }

        long bestN = 0;
        double bestRatio = double.MaxValue;
        for (int n = 2; n < limit; n++)
        {
            if (IsPermutation(n, phi[n]))
            {
                double ratio = (double)n / phi[n];
                if (ratio < bestRatio) { bestRatio = ratio; bestN = n; }
            }
        }
        return bestN;
    }

    static void Main() => Bench.Run(70, Solve);
}
