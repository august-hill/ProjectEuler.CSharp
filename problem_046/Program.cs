// Answer: 5777
using System;

namespace Problem46;

internal static class Program
{
    static long Solve()
    {
        const int Limit = 10000;
        bool[] isPrime = new bool[Limit + 1];
        Array.Fill(isPrime, true);
        isPrime[0] = isPrime[1] = false;
        for (int i = 2; i * i <= Limit; i++)
            if (isPrime[i])
                for (int j = i * i; j <= Limit; j += i)
                    isPrime[j] = false;

        for (int c = 9; c < Limit; c += 2)
        {
            if (isPrime[c]) continue;
            bool found = false;
            for (int p = 2; p < c && !found; p++)
            {
                if (isPrime[p])
                {
                    for (int y = 1; !found; y++)
                    {
                        int z = p + 2 * y * y;
                        if (z > c) break;
                        if (z == c) found = true;
                    }
                }
            }
            if (!found) return c;
        }
        return 0;
    }

    static void Main() => Bench.Run(46, Solve);
}
