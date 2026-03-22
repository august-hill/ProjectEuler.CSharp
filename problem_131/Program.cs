// Answer: 173
using System;

namespace Problem131;

internal static class Program
{
    static bool IsPrime(long n)
    {
        if (n < 2) return false;
        if (n < 4) return true;
        if (n % 2 == 0 || n % 3 == 0) return false;
        for (long i = 5; i * i <= n; i += 6)
            if (n % i == 0 || n % (i + 2) == 0) return false;
        return true;
    }

    static long Solve()
    {
        int count = 0;
        for (long a = 1; ; a++)
        {
            long p = 3 * a * a + 3 * a + 1;
            if (p >= 1000000) break;
            if (IsPrime(p)) count++;
        }
        return count;
    }

    static void Main() => Bench.Run(131, Solve);
}
