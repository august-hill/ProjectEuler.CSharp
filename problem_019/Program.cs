// Answer: 171
using System;

namespace Problem19;

internal static class Program
{
    static long Solve()
    {
        DateTime start = new DateTime(1901, 1, 1);
        TimeSpan fiveDays = new TimeSpan(5, 0, 0, 0);
        start += fiveDays;

        TimeSpan week = new TimeSpan(7, 0, 0, 0);
        DateTime end = new DateTime(2000, 12, 31);
        int count = 0;
        while (start <= end)
        {
            if (start.Day == 1) count++;
            start += week;
        }
        return count;
    }

    static void Main() => Bench.Run(19, Solve);
}
