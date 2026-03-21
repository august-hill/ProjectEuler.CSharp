// Answer: 26241
using System;

namespace Problem58;

internal static class Program
{
    private static bool IsPrime(long n)
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
        int primeCount = 0;
        int totalDiagonals = 1;
        long cornerValue = 1;

        for (int sideLength = 3; ; sideLength += 2)
        {
            int step = sideLength - 1;
            for (int i = 0; i < 4; i++)
            {
                cornerValue += step;
                totalDiagonals++;
                if (IsPrime(cornerValue)) primeCount++;
            }

            double ratio = (double)primeCount / totalDiagonals;
            if (ratio < 0.10) return sideLength;
        }
    }

    static void Main() => Bench.Run(58, Solve);
}
