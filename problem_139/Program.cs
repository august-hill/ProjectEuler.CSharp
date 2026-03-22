// Answer: 10057761
using System;

namespace Problem139;

internal static class Program
{
    const long PerimLimit = 100000000L;

    static int Gcd(int a, int b)
    {
        while (b != 0) { int t = b; b = a % b; a = t; }
        return a;
    }

    static long Solve()
    {
        long total = 0;

        for (long m = 2; 2 * m * (m + 1) < PerimLimit; m++)
        {
            for (long n = 1; n < m; n++)
            {
                if ((m + n) % 2 == 0) continue;
                if (Gcd((int)m, (int)n) != 1) continue;

                long a = m * m - n * n;
                long b = 2 * m * n;
                long c = m * m + n * n;
                long perim = a + b + c;
                if (perim >= PerimLimit) break;

                long gap = a > b ? a - b : b - a;
                if (c % gap == 0)
                    total += (PerimLimit - 1) / perim;
            }
        }
        return total;
    }

    static void Main() => Bench.Run(139, Solve);
}
