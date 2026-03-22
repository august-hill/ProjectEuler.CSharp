// Answer: 333082500
using System;

namespace Problem120;

internal static class Program
{
    static long Solve()
    {
        long total = 0;
        for (int a = 3; a <= 1000; a++)
        {
            long a2 = (long)a * a;
            long maxR = 0;
            for (int n = 1; n < 2 * a; n += 2)
            {
                long r = (2L * n * a) % a2;
                if (r > maxR) maxR = r;
            }
            total += maxR;
        }
        return total;
    }

    static void Main() => Bench.Run(120, Solve);
}
