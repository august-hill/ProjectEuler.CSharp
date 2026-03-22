// Answer: 168
using System;

namespace Problem115;

internal static class Program
{
    static long CountWays(int m, int n)
    {
        long[] temp = new long[n + 1];
        temp[0] = 1;
        for (int i = 1; i <= n; i++)
        {
            temp[i] = temp[i - 1];
            for (int len = m; len <= i; len++)
            {
                int start = i - len;
                if (start == 0) temp[i] += 1;
                else if (start == 1) temp[i] += 1;
                else temp[i] += temp[start - 1];
            }
        }
        return temp[n];
    }

    static long Solve()
    {
        int m = 50;
        for (int n = m; n <= 1000; n++)
        {
            if (CountWays(m, n) > 1000000)
                return n;
        }
        return -1;
    }

    static void Main() => Bench.Run(115, Solve);
}
