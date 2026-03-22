// Answer: 248155780267521
using System;

namespace Problem119;

internal static class Program
{
    static int DigitSum(long n)
    {
        int s = 0;
        while (n > 0) { s += (int)(n % 10); n /= 10; }
        return s;
    }

    static long Solve()
    {
        long[] results = new long[10000];
        int count = 0;

        for (int b = 2; b <= 200; b++)
        {
            long power = (long)b * b;
            for (int exp = 2; exp <= 50 && power < (long)1e16; exp++)
            {
                if (power >= 10 && DigitSum(power) == b)
                    results[count++] = power;
                if (power > (long)(1e16 / b)) break;
                power *= b;
            }
        }

        Array.Sort(results, 0, count);
        return results[29];
    }

    static void Main() => Bench.Run(119, Solve);
}
