// Answer: 1118049290473932
using System;

namespace Problem138;

internal static class Program
{
    static long Solve()
    {
        long sum = 0;
        long lPrev = 1;
        long lCurr = 17;

        for (int i = 0; i < 12; i++)
        {
            sum += lCurr;
            long lNext = 18 * lCurr - lPrev;
            lPrev = lCurr;
            lCurr = lNext;
        }
        return sum;
    }

    static void Main() => Bench.Run(138, Solve);
}
