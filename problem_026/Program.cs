// Answer: 983
using System;

namespace Problem26;

internal static class Program
{
    private static int CycleLength(int d)
    {
        int[] seen = new int[d];
        Array.Fill(seen, -1);

        int remainder = 1;
        int position = 0;

        while (remainder != 0)
        {
            if (seen[remainder] >= 0)
                return position - seen[remainder];
            seen[remainder] = position;
            remainder = (remainder * 10) % d;
            position++;
        }

        return 0; // Terminating decimal
    }

    static long Solve()
    {
        int maxCycle = 0;
        int result = 0;

        for (int d = 2; d < 1000; d++)
        {
            int cycle = CycleLength(d);
            if (cycle > maxCycle)
            {
                maxCycle = cycle;
                result = d;
            }
        }
        return result;
    }

    static void Main() => Bench.Run(26, Solve);
}
