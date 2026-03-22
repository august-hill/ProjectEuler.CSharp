// Answer: 1587000
using System;

namespace Problem112;

internal static class Program
{
    static bool IsBouncy(int n)
    {
        bool increasing = false, decreasing = false;
        int prev = n % 10;
        n /= 10;
        while (n > 0)
        {
            int d = n % 10;
            if (d < prev) increasing = true;
            if (d > prev) decreasing = true;
            if (increasing && decreasing) return true;
            prev = d;
            n /= 10;
        }
        return false;
    }

    static long Solve()
    {
        int bouncy = 0;
        for (int n = 1; ; n++)
        {
            if (IsBouncy(n)) bouncy++;
            if (bouncy * 100 == n * 99)
                return n;
        }
    }

    static void Main() => Bench.Run(112, Solve);
}
