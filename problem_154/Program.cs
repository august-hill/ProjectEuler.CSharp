// Answer: 479742450
using System;

namespace Problem154;

internal static class Program
{
    const int N = 200000;

    static long[]? _f2;
    static long[]? _f5;
    static bool _initialized;

    static void Init()
    {
        _f2 = new long[N + 1];
        _f5 = new long[N + 1];
        _f2[0] = 0; _f5[0] = 0;
        for (int i = 1; i <= N; i++)
        {
            int v = 0, x = i;
            while (x % 2 == 0) { v++; x /= 2; }
            _f2[i] = _f2[i - 1] + v;
            v = 0; x = i;
            while (x % 5 == 0) { v++; x /= 5; }
            _f5[i] = _f5[i - 1] + v;
        }
    }

    static long Solve()
    {
        if (!_initialized) { Init(); _initialized = true; }

        long total2 = _f2![N];
        long total5 = _f5![N];
        long count = 0;

        for (int a = 0; a <= N / 3; a++)
        {
            long ra2 = total2 - _f2[a];
            long ra5 = total5 - _f5[a];
            for (int b = a; b <= (N - a) / 2; b++)
            {
                int c = N - a - b;
                long rem2 = ra2 - _f2[b] - _f2[c];
                long rem5 = ra5 - _f5[b] - _f5[c];
                if (rem2 >= 12 && rem5 >= 12)
                {
                    if (a == b && b == c) count += 1;
                    else if (a == b || b == c) count += 3;
                    else count += 6;
                }
            }
        }
        return count;
    }

    static void Main() => Bench.Run(154, Solve);
}
