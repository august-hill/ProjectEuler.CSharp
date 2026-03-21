// Answer: 5482660
using System;

namespace Problem44;

internal static class Program
{
    private const int MaximumValue = 3000;

    private static int P(int n) => n * (3 * n - 1) / 2;

    static long Solve()
    {
        var p = new int[MaximumValue];
        for (int i = 0; i < MaximumValue; i++) p[i] = P(i);

        for (int j = 1; j < MaximumValue; j++)
        {
            for (int k = j + 1; k < MaximumValue; k++)
            {
                int sum = p[j] + p[k];
                if (Array.BinarySearch(p, sum) < 0) continue;
                int diff = p[k] - p[j];
                if (Array.BinarySearch(p, diff) < 0) continue;
                return diff;
            }
        }
        return 0;
    }

    static void Main() => Bench.Run(44, Solve);
}
