// Answer: -271248680
using System;

namespace Problem150;

internal static class Program
{
    const int Rows = 1000;

    static long[][]? _prefix;
    static bool _initialized;

    static void Init()
    {
        _prefix = new long[Rows][];
        long t = 0;

        for (int r = 0; r < Rows; r++)
        {
            _prefix[r] = new long[r + 2];
            _prefix[r][0] = 0;
            for (int j = 0; j <= r; j++)
            {
                t = (615949L * t + 797807L) & ((1L << 20) - 1);
                long s = t - (1L << 19);
                _prefix[r][j + 1] = _prefix[r][j] + s;
            }
        }
    }

    static long Solve()
    {
        if (!_initialized) { Init(); _initialized = true; }

        long minSum = long.MaxValue;

        for (int r = 0; r < Rows; r++)
        {
            for (int c = 0; c <= r; c++)
            {
                long sum = 0;
                for (int size = 0; r + size < Rows; size++)
                {
                    int row = r + size;
                    sum += _prefix![row][c + size + 1] - _prefix[row][c];
                    if (sum < minSum) minSum = sum;
                }
            }
        }

        return minSum;
    }

    static void Main() => Bench.Run(150, Solve);
}
