// Answer: 2772
using System;

namespace Problem85;

internal static class Program
{
    static long Solve()
    {
        long target = 2_000_000;
        int bestArea = 0;
        long bestDiff = target;
        for (int m = 1; m <= 2000; m++)
        {
            long cm = (long)m * (m + 1) / 2;
            if (cm > target) break;
            for (int n = m; n <= 2000; n++)
            {
                long count = cm * n * (n + 1) / 2;
                long diff = Math.Abs(count - target);
                if (diff < bestDiff) { bestDiff = diff; bestArea = m * n; }
                if (count > target) break;
            }
        }
        return bestArea;
    }

    static void Main() => Bench.Run(85, Solve);
}
