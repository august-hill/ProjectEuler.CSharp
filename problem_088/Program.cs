// Answer: 7587457
using System;
using System.Collections.Generic;

namespace Problem88;

internal static class Program
{
    const int K_MAX = 12000;
    const int LIMIT = 2 * K_MAX;

    private static void Factorize(int product, int sum, int count, int minFactor, int[] minPs)
    {
        int k = product - sum + count;
        if (k <= K_MAX && product < minPs[k])
            minPs[k] = product;
        for (int f = minFactor; f <= LIMIT; f++)
        {
            long newProduct = (long)product * f;
            if (newProduct > LIMIT) break;
            Factorize((int)newProduct, sum + f, count + 1, f, minPs);
        }
    }

    static long Solve()
    {
        var minPs = new int[K_MAX + 1];
        Array.Fill(minPs, LIMIT + 1);
        for (int f = 2; f <= LIMIT; f++)
            Factorize(f, f, 1, f, minPs);
        var seen = new HashSet<int>();
        long total = 0;
        for (int k = 2; k <= K_MAX; k++)
            if (seen.Add(minPs[k])) total += minPs[k];
        return total;
    }

    static void Main() => Bench.Run(88, Solve);
}
