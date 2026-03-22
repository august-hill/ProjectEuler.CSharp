// Problem 195: 60-degree Triangle Inscribed Circle Counting
// Answer: 75085391
using System;

namespace Problem195;

internal static class Program
{
    static long Gcd2(long a, long b)
    {
        while (b != 0) { long t = b; b = a % b; a = t; }
        return a;
    }

    static long FormulaCount(long l)
    {
        long count = l / 3;

        for (long m = 3; ; m++)
        {
            for (long n = 1; 2 * n < m; n++)
            {
                if (Gcd2(m, n) != 1) continue;
                if ((m + n) % 3 == 0) continue;
                long perim = (2 * m - n) * (m + n);
                if (perim > l) break;
                count += l / perim;
            }
            if ((2 * m - 1) * (m + 1) > l) break;
        }

        for (long m = 2; ; m++)
        {
            long nMin = m / 2 + 1;
            for (long n = nMin; n < m; n++)
            {
                if (Gcd2(m, n) != 1) continue;
                if ((m + n) % 3 == 0) continue;
                long perim = 3 * m * n;
                if (perim > l) break;
                count += l / perim;
            }
            if (3 * m * (m / 2 + 1) > l) break;
        }

        return count;
    }

    static long Solve() => FormulaCount(39_900_000L);

    static void Main() => Bench.Run(195, Solve);
}
