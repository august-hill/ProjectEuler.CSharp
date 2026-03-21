// Answer: 1322
using System;

namespace Problem64;

internal static class Program
{
    static long Solve()
    {
        int count = 0;
        for (int n = 2; n <= 10000; n++)
        {
            int a0 = (int)Math.Sqrt(n);
            if (a0 * a0 == n) continue;
            int m = 0, d = 1, a = a0;
            int period = 0;
            do
            {
                m = d * a - m;
                d = (n - m * m) / d;
                a = (a0 + m) / d;
                period++;
            } while (a != 2 * a0);
            if (period % 2 == 1) count++;
        }
        return count;
    }

    static void Main() => Bench.Run(64, Solve);
}
