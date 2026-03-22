// Answer: 227485267000992000
using System;

namespace Problem172;

internal static class Program
{
    static long[,] _C = new long[20, 20];
    static bool _initialized;

    static void InitC()
    {
        for (int n = 0; n < 20; n++)
        {
            _C[n, 0] = 1;
            for (int k = 1; k <= n; k++)
                _C[n, k] = _C[n - 1, k - 1] + _C[n - 1, k];
        }
    }

    static long Solve()
    {
        if (!_initialized) { InitC(); _initialized = true; }

        long[] dp = new long[20];
        dp[18] = 1;

        for (int d = 0; d < 10; d++)
        {
            long[] ndp = new long[20];
            for (int r = 0; r <= 18; r++)
            {
                if (dp[r] == 0) continue;
                for (int c = 0; c <= 3 && c <= r; c++)
                    ndp[r - c] += dp[r] * _C[r, c];
            }
            dp = ndp;
        }
        long total = dp[0];

        dp = new long[20];
        dp[17] = 1;

        // Digit 0: max 2 more
        {
            long[] ndp = new long[20];
            for (int r = 0; r <= 17; r++)
            {
                if (dp[r] == 0) continue;
                for (int c = 0; c <= 2 && c <= r; c++)
                    ndp[r - c] += dp[r] * _C[r, c];
            }
            dp = ndp;
        }

        for (int d = 1; d < 10; d++)
        {
            long[] ndp = new long[20];
            for (int r = 0; r <= 17; r++)
            {
                if (dp[r] == 0) continue;
                for (int c = 0; c <= 3 && c <= r; c++)
                    ndp[r - c] += dp[r] * _C[r, c];
            }
            dp = ndp;
        }
        long withLeadingZero = dp[0];

        return total - withLeadingZero;
    }

    static void Main() => Bench.Run(172, Solve);
}
