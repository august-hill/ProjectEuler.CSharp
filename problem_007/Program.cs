// Answer: 104743
using System;

namespace Problem7;

internal static class Program
{
    static long Solve()
    {
        // Sieve of Eratosthenes - upper bound for 10001st prime is ~115000
        const int sieveSize = 120000;
        bool[] composite = new bool[sieveSize];
        composite[0] = true;
        composite[1] = true;

        for (int i = 2; i * i < sieveSize; i++)
        {
            if (!composite[i])
            {
                for (int j = i * i; j < sieveSize; j += i)
                {
                    composite[j] = true;
                }
            }
        }

        int count = 0;
        for (int i = 2; i < sieveSize; i++)
        {
            if (!composite[i])
            {
                count++;
                if (count == 10001) return i;
            }
        }
        return 0;
    }

    static void Main() => Bench.Run(7, Solve);
}
