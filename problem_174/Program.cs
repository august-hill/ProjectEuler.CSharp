// Answer: 209566
using System;

namespace Problem174;

internal static class Program
{
    const int Limit = 1000001;
    static int[]? _nt;
    static bool _initialized;

    static void Init()
    {
        _nt = new int[Limit];
        for (long n = 3; ; n++)
        {
            long mMax = n - 2;
            long mMin = (n % 2 == 0) ? 2 : 1;
            if (n * n - mMax * mMax >= Limit) break;
            for (long m = mMax; m >= mMin; m -= 2)
            {
                long t = n * n - m * m;
                if (t >= Limit) continue;
                _nt[t]++;
            }
        }
    }

    static long Solve()
    {
        if (!_initialized) { Init(); _initialized = true; }

        long count = 0;
        for (int t = 1; t < Limit; t++)
            if (_nt![t] >= 1 && _nt[t] <= 10) count++;
        return count;
    }

    static void Main() => Bench.Run(174, Solve);
}
