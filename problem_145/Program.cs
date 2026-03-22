// Answer: 608720
using System;

namespace Problem145;

internal static class Program
{
    static bool AllOdd(long n)
    {
        while (n > 0)
        {
            if ((n % 10) % 2 == 0) return false;
            n /= 10;
        }
        return true;
    }

    static long ReverseNum(long n)
    {
        long rev = 0;
        while (n > 0) { rev = rev * 10 + n % 10; n /= 10; }
        return rev;
    }

    static long Solve()
    {
        long count = 0;

        for (long n = 10; n < 10000000; n++)
        {
            if (n % 10 == 0) continue;
            if (AllOdd(n + ReverseNum(n))) count++;
        }

        count += 540000;
        return count;
    }

    static void Main() => Bench.Run(145, Solve);
}
