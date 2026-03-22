// Answer: 1006193
using System;

namespace Problem142;

internal static class Program
{
    static bool IsqrtCheck(long n)
    {
        if (n < 0) return false;
        long s = (long)Math.Sqrt((double)n);
        while (s * s < n) s++;
        while (s * s > n) s--;
        return s * s == n;
    }

    static long Solve()
    {
        for (int a = 3; ; a++)
        {
            for (int c = a - 1; c >= 2; c--)
            {
                long f2 = (long)a * a - (long)c * c;
                if (!IsqrtCheck(f2)) continue;

                for (int e = c - 1; e >= 1; e--)
                {
                    long b2 = (long)c * c - (long)e * e;
                    if (!IsqrtCheck(b2)) continue;

                    long d2 = (long)a * a - (long)e * e;
                    if (!IsqrtCheck(d2)) continue;

                    long bv = (long)Math.Sqrt((double)b2);
                    while (bv * bv < b2) bv++;
                    while (bv * bv > b2) bv--;
                    if ((a + bv) % 2 != 0) continue;

                    long x = ((long)a * a + b2) / 2;
                    long y = ((long)a * a - b2) / 2;
                    long z = x - d2;

                    if (z <= 0 || y <= z) continue;

                    return x + y + z;
                }
            }
        }
    }

    static void Main() => Bench.Run(142, Solve);
}
