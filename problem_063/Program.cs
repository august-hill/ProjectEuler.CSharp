// Answer: 49
using System;

namespace Problem63;

internal static class Program
{
    static long Solve()
    {
        // For base^n to have exactly n digits: n-1 <= log10(base^n) < n
        // i.e. n-1 <= n*log10(base) < n
        // The left inequality: n*log10(base) >= n-1 => n <= 1/(1-log10(base))
        // Only bases 1-9 can work (base 10 gives n+1 digits for n-th power)
        int count = 0;
        for (int b = 1; b <= 9; b++)
        {
            int maxN = (int)Math.Floor(1.0 / (1.0 - Math.Log10(b)));
            count += maxN;
        }
        return count;
    }

    static void Main() => Bench.Run(63, Solve);
}
