// Answer: 878454337159
using System;

namespace Problem141;

internal static class Program
{
    const long Limit = 1000000000000L;

    static int Gcd(int a, int b)
    {
        while (b != 0) { int t = b; b = a % b; a = t; }
        return a;
    }

    static long Solve()
    {
        long sum = 0;

        for (long b = 2; b * b * b < Limit; b++)
        {
            for (long a = 1; a < b; a++)
            {
                if (Gcd((int)a, (int)b) != 1) continue;
                for (long c = 1; ; c++)
                {
                    long n = a * c * (b * b * b * c + a);
                    if (n >= Limit) break;
                    long s = (long)Math.Sqrt((double)n);
                    while (s * s < n) s++;
                    while (s * s > n) s--;
                    if (s * s == n) sum += n;
                }
            }
        }
        return sum;
    }

    static void Main() => Bench.Run(141, Solve);
}
