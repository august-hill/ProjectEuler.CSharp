// Answer: 4989
using System;

namespace Problem135;

internal static class Program
{
    const int Limit = 1000000;

    static long Solve()
    {
        int[] count = new int[Limit];

        for (int y = 1; y < Limit; y++)
        {
            int dMin = y / 4 + 1;
            int dMax = y - 1;
            long maxD = ((long)(Limit - 1) + (long)y * y) / (4L * y);
            if (maxD < dMax) dMax = (int)maxD;

            for (int d = dMin; d <= dMax; d++)
            {
                int n = y * (4 * d - y);
                if (n > 0 && n < Limit)
                    count[n]++;
            }
        }

        int result = 0;
        for (int n = 1; n < Limit; n++)
            if (count[n] == 10) result++;
        return result;
    }

    static void Main() => Bench.Run(135, Solve);
}
