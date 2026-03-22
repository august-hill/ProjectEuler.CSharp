// Answer: 14489159
using System;

namespace Problem159;

internal static class Program
{
    const int Limit = 1000000;
    static int[]? _mdrs;
    static bool _initialized;

    static int DigitalRoot(int n)
    {
        if (n == 0) return 0;
        int r = n % 9;
        return r == 0 ? 9 : r;
    }

    static void Init()
    {
        _mdrs = new int[Limit];
        for (int i = 2; i < Limit; i++)
            _mdrs[i] = DigitalRoot(i);

        for (int i = 2; i < Limit; i++)
            for (long j = 2; i * j < Limit; j++)
            {
                int prod = (int)(i * j);
                int val = _mdrs![i] + _mdrs[(int)j];
                if (val > _mdrs[prod]) _mdrs[prod] = val;
            }
    }

    static long Solve()
    {
        if (!_initialized) { Init(); _initialized = true; }
        long sum = 0;
        for (int i = 2; i < Limit; i++) sum += _mdrs![i];
        return sum;
    }

    static void Main() => Bench.Run(159, Solve);
}
