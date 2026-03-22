// Answer: 149253
using System;

namespace Problem130;

internal static class Program
{
    static int RepunitDiv(int n)
    {
        int r = 1, k = 1;
        while (r % n != 0) { r = (r * 10 + 1) % n; k++; }
        return k;
    }

    static bool IsPrime(int n)
    {
        if (n < 2) return false;
        if (n < 4) return true;
        if (n % 2 == 0 || n % 3 == 0) return false;
        for (int i = 5; i * i <= n; i += 6)
            if (n % i == 0 || n % (i + 2) == 0) return false;
        return true;
    }

    static long Solve()
    {
        long sum = 0;
        int count = 0;
        for (int n = 2; count < 25; n++)
        {
            if (n % 2 == 0 || n % 5 == 0) continue;
            if (IsPrime(n)) continue;
            int a = RepunitDiv(n);
            if ((n - 1) % a == 0) { sum += n; count++; }
        }
        return sum;
    }

    static void Main() => Bench.Run(130, Solve);
}
