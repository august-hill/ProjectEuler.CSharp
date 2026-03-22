// Answer: 2544559
using System;

namespace Problem136;

internal static class Program
{
    const int Limit = 50000000;
    static byte[]? _count;
    static bool _initialized;

    static long Solve()
    {
        if (!_initialized)
        {
            _count = new byte[Limit];
            _initialized = true;
        }
        Array.Clear(_count!, 0, Limit);

        for (int y = 1; y < Limit; y++)
        {
            int dMin = y / 4 + 1;
            int dMax = y - 1;
            long maxD = ((long)(Limit - 1) + (long)y * y) / (4L * y);
            if (maxD < dMax) dMax = (int)maxD;

            for (int d = dMin; d <= dMax; d++)
            {
                long n = (long)y * (4 * d - y);
                if (n > 0 && n < Limit)
                {
                    if (_count![n] < 3) _count[n]++;
                }
            }
        }

        int result = 0;
        for (int n = 1; n < Limit; n++)
            if (_count![n] == 1) result++;
        return result;
    }

    static void Main() => Bench.Run(136, Solve);
}
