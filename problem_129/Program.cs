// Answer: 1000023
using System;

namespace Problem129;

internal static class Program
{
    static int RepunitDiv(int n)
    {
        int r = 1, k = 1;
        while (r % n != 0) { r = (r * 10 + 1) % n; k++; }
        return k;
    }

    static long Solve()
    {
        for (int n = 1000001; ; n++)
        {
            if (n % 2 == 0 || n % 5 == 0) continue;
            if (RepunitDiv(n) > 1000000) return n;
        }
    }

    static void Main() => Bench.Run(129, Solve);
}
