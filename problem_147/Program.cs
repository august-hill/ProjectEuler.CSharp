// Answer: 846910284
using System;

namespace Problem147;

internal static class Program
{
    static long Solve()
    {
        long total = 0;
        for (int m = 1; m <= 47; m++)
        {
            for (int n = 1; n <= 43; n++)
            {
                long aa = (long)m * (m + 1) / 2 * n * (n + 1) / 2;

                long diag = 0;
                for (int s1 = 1; s1 <= m + n - 2; s1++)
                {
                    for (int s2 = s1 + 1; s2 <= m + n - 1; s2++)
                    {
                        int lo = -s1;
                        int tmp = s2 - 2 * n;
                        if (tmp > lo) lo = tmp;

                        int hi = s1;
                        tmp = 2 * m - s2;
                        if (tmp < hi) hi = tmp;

                        if (lo >= hi) continue;

                        long cnt = hi - lo + 1;
                        if (cnt >= 2)
                            diag += cnt * (cnt - 1) / 2;
                    }
                }

                total += aa + diag;
            }
        }
        return total;
    }

    static void Main() => Bench.Run(147, Solve);
}
