// Answer: 399788195976
using System;

namespace Problem182;

internal static class Program
{
    static long Gcd(long a, long b)
    {
        while (b != 0) { long t = b; b = a % b; a = t; }
        return a;
    }

    static long Solve()
    {
        long p = 1009, q = 3643;
        long phi = (p - 1) * (q - 1);

        long sum = 0;
        for (long e = 2; e < phi; e++)
        {
            if (Gcd(e, phi) != 1) continue;
            if (Gcd(e - 1, p - 1) == 2 && Gcd(e - 1, q - 1) == 2)
                sum += e;
        }
        return sum;
    }

    static void Main() => Bench.Run(182, Solve);
}
