// Answer: 840
using System;

namespace Problem39;

internal static class Program
{
    static long Solve()
    {
        int[] solutions = new int[1001];

        for (int a = 1; a < 334; a++)
        {
            for (int b = a; b < 500; b++)
            {
                int cSquared = a * a + b * b;
                int c = (int)Math.Sqrt(cSquared);
                if (c * c == cSquared)
                {
                    int p = a + b + c;
                    if (p <= 1000) solutions[p]++;
                }
            }
        }

        int maxSolutions = 0;
        int result = 0;
        for (int p = 1; p <= 1000; p++)
        {
            if (solutions[p] > maxSolutions)
            {
                maxSolutions = solutions[p];
                result = p;
            }
        }
        return result;
    }

    static void Main() => Bench.Run(39, Solve);
}
