// Answer: 53490
using System;

namespace Problem157;

internal static class Program
{
    static int NumDivisors(long n)
    {
        if (n <= 0) return 0;
        int count = 0;
        for (long d = 1; d * d <= n; d++)
        {
            if (n % d == 0)
            {
                count++;
                if (d != n / d) count++;
            }
        }
        return count;
    }

    static long GcdLL(long a, long b)
    {
        while (b != 0) { long t = b; b = a % b; a = t; }
        return a;
    }

    static long Solve()
    {
        long total = 0;

        for (int n = 1; n <= 9; n++)
        {
            long tenN = 1;
            for (int i = 0; i < n; i++) tenN *= 10;

            int[] divs = new int[200];
            int ndivs = 0;
            for (long d = 1; d * d <= tenN; d++)
            {
                if (tenN % d == 0)
                {
                    divs[ndivs++] = (int)d;
                    if (d != tenN / d) divs[ndivs++] = (int)(tenN / d);
                }
            }

            for (int i = 0; i < ndivs; i++)
            {
                for (int j = i; j < ndivs; j++)
                {
                    long x = divs[i], y = divs[j];
                    if (x * y > tenN) continue;
                    if (tenN % (x * y) != 0) continue;
                    if (GcdLL(x, y) != 1) continue;

                    long m = tenN / (x * y);
                    long D = m * (x + y);
                    int nd = NumDivisors(D);
                    total += nd;
                }
            }
        }

        return total;
    }

    static void Main() => Bench.Run(157, Solve);
}
