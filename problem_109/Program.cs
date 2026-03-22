// Answer: 38182
using System;

namespace Problem109;

internal static class Program
{
    static long Solve()
    {
        int[] singles = new int[62];
        int ndarts = 0;

        for (int i = 1; i <= 20; i++) singles[ndarts++] = i;
        singles[ndarts++] = 25;
        for (int i = 1; i <= 20; i++) singles[ndarts++] = 2 * i;
        singles[ndarts++] = 50;
        for (int i = 1; i <= 20; i++) singles[ndarts++] = 3 * i;

        int[] doubles = new int[21];
        int ndoubles = 0;
        for (int i = 1; i <= 20; i++) doubles[ndoubles++] = 2 * i;
        doubles[ndoubles++] = 50;

        int count = 0;

        // 1 dart: just a double
        for (int i = 0; i < ndoubles; i++)
            if (doubles[i] < 100) count++;

        // 2 darts: any + double
        for (int i = 0; i < ndarts; i++)
            for (int j = 0; j < ndoubles; j++)
                if (singles[i] + doubles[j] < 100) count++;

        // 3 darts: any + any + double (order of first two doesn't matter)
        for (int i = 0; i < ndarts; i++)
            for (int j = i; j < ndarts; j++)
                for (int k = 0; k < ndoubles; k++)
                    if (singles[i] + singles[j] + doubles[k] < 100) count++;

        return count;
    }

    static void Main() => Bench.Run(109, Solve);
}
