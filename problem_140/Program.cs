// Answer: 5673835352990
using System;

namespace Problem140;

internal static class Program
{
    static long Solve()
    {
        long[,] seeds = {
            {7, 1}, {8, 2}, {13, 5}, {17, 7}, {32, 14}, {43, 19}
        };
        int nseed = 6;

        long[] nuggets = new long[200];
        int count = 0;

        for (int s = 0; s < nseed; s++)
        {
            long m = seeds[s, 0], k = seeds[s, 1];
            for (int iter = 0; iter < 40 && count < 200; iter++)
            {
                if (m > 7 && m % 5 == 2)
                {
                    long n = (m - 7) / 5;
                    if (n > 0) nuggets[count++] = n;
                }
                long nm = 9 * m + 20 * k;
                long nk = 4 * m + 9 * k;
                m = nm; k = nk;
            }
        }

        Array.Sort(nuggets, 0, count);

        long sum = 0;
        int unique = 0;
        for (int i = 0; i < count && unique < 30; i++)
        {
            if (i == 0 || nuggets[i] != nuggets[i - 1])
            {
                sum += nuggets[i];
                unique++;
            }
        }
        return sum;
    }

    static void Main() => Bench.Run(140, Solve);
}
