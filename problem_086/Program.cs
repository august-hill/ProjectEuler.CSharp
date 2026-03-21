// Answer: 1818
using System;

namespace Problem86;

internal static class Program
{
    static long Solve()
    {
        int count = 0;
        int m = 1;
        while (true)
        {
            for (int s = 2; s <= 2 * m; s++)
            {
                int sq = m * m + s * s;
                int root = (int)Math.Sqrt(sq);
                if (root * root == sq)
                {
                    int cMin = (s > m) ? s - m : 1;
                    int cMax = s / 2;
                    if (cMax >= cMin) count += cMax - cMin + 1;
                }
            }
            if (count > 1_000_000) return m;
            m++;
        }
    }

    static void Main() => Bench.Run(86, Solve);
}
