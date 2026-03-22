// Answer: 18522
using System;

namespace Problem126;

internal static class Program
{
    const int Limit = 20000;

    static long LayerCubes(long a, long b, long c, long k)
    {
        return 2 * (a * b + b * c + a * c) + 4 * (k - 1) * (a + b + c) + 4 * (k - 1) * (k - 2);
    }

    static long Solve()
    {
        int[] count = new int[Limit + 1];

        for (int a = 1; a <= Limit; a++)
        {
            for (int b = a; ; b++)
            {
                if (LayerCubes(a, b, b, 1) > Limit) break;
                for (int c = b; ; c++)
                {
                    long f = LayerCubes(a, b, c, 1);
                    if (f > Limit) break;
                    for (int k = 1; ; k++)
                    {
                        long cubes = LayerCubes(a, b, c, k);
                        if (cubes > Limit) break;
                        count[(int)cubes]++;
                    }
                }
            }
        }

        for (int n = 1; n <= Limit; n++)
            if (count[n] == 1000) return n;
        return -1;
    }

    static void Main() => Bench.Run(126, Solve);
}
