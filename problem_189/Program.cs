// Answer: 10834893628237824
using System;

namespace Problem189;

internal static class Program
{
    const int MaxRow = 8;
    static int[] _pow3 = new int[10];
    static bool _initialized;

    static void InitPow3()
    {
        _pow3[0] = 1;
        for (int i = 1; i <= 9; i++) _pow3[i] = _pow3[i - 1] * 3;
    }

    static int GetColour(int state, int pos) => (state / _pow3[pos]) % 3;

    static long CountDownWays(int[] prevUp, int r, int[] curUp)
    {
        long ways = 1;
        for (int j = 0; j < r; j++)
        {
            int a = prevUp[j], b = curUp[j], c = curUp[j + 1];
            int distinct = 1;
            if (b != a) distinct++;
            if (c != a && c != b) distinct++;
            if (distinct == 3) return 0;
            ways *= 3 - distinct;
        }
        return ways;
    }

    static long Solve()
    {
        if (!_initialized) { InitPow3(); _initialized = true; }

        const int MaxStates = 6561; // 3^8
        long[] dp = new long[MaxStates];
        long[] ndp = new long[MaxStates];

        dp[0] = dp[1] = dp[2] = 1;

        for (int row = 1; row < MaxRow; row++)
        {
            int nupCur = row;
            int nupNext = row + 1;

            Array.Clear(ndp, 0, MaxStates);

            for (int s = 0; s < _pow3[nupCur]; s++)
            {
                if (dp[s] == 0) continue;

                int[] prevUp = new int[MaxRow + 1];
                for (int j = 0; j < nupCur; j++) prevUp[j] = GetColour(s, j);

                for (int ns = 0; ns < _pow3[nupNext]; ns++)
                {
                    int[] curUp = new int[MaxRow + 1];
                    for (int j = 0; j < nupNext; j++) curUp[j] = GetColour(ns, j);

                    long ways = CountDownWays(prevUp, nupCur, curUp);
                    if (ways > 0) ndp[ns] += dp[s] * ways;
                }
            }

            Array.Copy(ndp, dp, MaxStates);
        }

        long total = 0;
        for (int s = 0; s < _pow3[MaxRow]; s++) total += dp[s];
        return total;
    }

    static void Main() => Bench.Run(189, Solve);
}
