// Answer: 4075
using System;

namespace Problem53;

internal static class Program
{
    const int Threshold = 1000000;

    static long Solve()
    {
        long[] prev = new long[102];
        long[] curr = new long[102];
        prev[0] = 1;

        int count = 0;
        for (int n = 1; n <= 100; n++)
        {
            Array.Clear(curr, 0, curr.Length);
            curr[0] = 1;
            for (int r = 1; r <= n; r++)
            {
                curr[r] = prev[r - 1] + prev[r];
                if (curr[r] > Threshold)
                {
                    curr[r] = Threshold + 1;
                    count++;
                }
            }
            Array.Copy(curr, prev, curr.Length);
        }
        return count;
    }

    static void Main() => Bench.Run(53, Solve);
}
