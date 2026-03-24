// Answer: 1572729
using System;

namespace Problem173;

internal static class Program
{
    static long Solve()
    {
        long count = 0;
        long limit = 1000000;

        for (long n = 3; ; n++)
        {
            long mMax = n - 2;
            long mMin = (n % 2 == 0) ? 2 : 1;
            if (n * n - mMax * mMax > limit) break;

            long mSqMin = n * n - limit;
            long actualMMin = mMin;
            if (mSqMin > 0)
            {
                actualMMin = (long)Math.Sqrt((double)mSqMin);
                if (actualMMin * actualMMin < mSqMin) actualMMin++;
            }
            if (actualMMin < mMin) actualMMin = mMin;
            if ((actualMMin % 2) != (n % 2)) actualMMin++;
            if (actualMMin > mMax) continue;

            count += (mMax - actualMMin) / 2 + 1;
        }

        return count;
    }

    static void Main() => Bench.Run(173, Solve);
}
