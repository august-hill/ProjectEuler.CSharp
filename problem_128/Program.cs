// Answer: 14516824220
using System;

namespace Problem128;

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
        int count = 1; // tile 1

        for (long r = 1; ; r++)
        {
            // First tile of ring r
            if (IsPrime(6 * r - 1) && IsPrime(6 * r + 1) && IsPrime(12 * r + 5))
            {
                count++;
                if (count == 2000) return 3 * r * r - 3 * r + 2;
            }

            // Last tile of ring r (r >= 2)
            if (r >= 2)
            {
                if (IsPrime(6 * r - 1) && IsPrime(6 * r + 5) && IsPrime(12 * r - 7))
                {
                    count++;
                    if (count == 2000) return 3 * r * r + 3 * r + 1;
                }
            }
        }
    }

    static void Main() => Bench.Run(128, Solve);
}
