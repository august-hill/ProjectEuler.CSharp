// Answer: 986262
using System;

namespace Problem179;

internal static class Program
{
    const int Limit = 10000000;
    static int[]? _divcount;
    static bool _initialized;

    static void Init()
    {
        _divcount = new int[Limit + 1];
        for (int i = 1; i <= Limit; i++)
            for (int j = i; j <= Limit; j += i)
                _divcount[j]++;
    }

    static long Solve()
    {
        if (!_initialized) { Init(); _initialized = true; }
        int count = 0;
        for (int n = 2; n < Limit; n++)
            if (_divcount![n] == _divcount[n + 1]) count++;
        return count;
    }

    static void Main() => Bench.Run(179, Solve);
}
