// Answer: 52852124
using System;

namespace Problem149;

internal static class Program
{
    const int N = 2000;
    const int Total = N * N;

    static long[]? _s;
    static long[,]? _table;
    static bool _initialized;

    static void Init()
    {
        _s = new long[Total + 1];
        _table = new long[N, N];

        for (int k = 1; k <= 55; k++)
            _s[k] = ((100003L - 200003L * k + 300007L * k * (long)k * k) % 1000000L + 1000000L) % 1000000L - 500000L;
        for (int k = 56; k <= Total; k++)
            _s[k] = ((_s[k - 24] + _s[k - 55] + 1000000L) % 1000000L + 1000000L) % 1000000L - 500000L;

        for (int i = 0; i < N; i++)
            for (int j = 0; j < N; j++)
                _table[i, j] = _s[i * N + j + 1];
    }

    static long MaxSubarray(long[] arr, int len)
    {
        long best = arr[0], current = arr[0];
        for (int i = 1; i < len; i++)
        {
            if (current < 0) current = arr[i];
            else current += arr[i];
            if (current > best) best = current;
        }
        return best;
    }

    static long Solve()
    {
        if (!_initialized) { Init(); _initialized = true; }

        long best = long.MinValue / 2;
        long[] line = new long[N];

        // Rows
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++) line[j] = _table![i, j];
            long val = MaxSubarray(line, N);
            if (val > best) best = val;
        }

        // Columns
        for (int j = 0; j < N; j++)
        {
            for (int i = 0; i < N; i++) line[i] = _table![i, j];
            long val = MaxSubarray(line, N);
            if (val > best) best = val;
        }

        // Diagonals (top-left to bottom-right)
        for (int start = -(N - 1); start < N; start++)
        {
            int len = 0;
            for (int i = 0; i < N; i++)
            {
                int j = i - start;
                if (j >= 0 && j < N) line[len++] = _table![i, j];
            }
            if (len > 0)
            {
                long val = MaxSubarray(line, len);
                if (val > best) best = val;
            }
        }

        // Anti-diagonals
        for (int start = 0; start < 2 * N - 1; start++)
        {
            int len = 0;
            for (int i = 0; i < N; i++)
            {
                int j = start - i;
                if (j >= 0 && j < N) line[len++] = _table![i, j];
            }
            if (len > 0)
            {
                long val = MaxSubarray(line, len);
                if (val > best) best = val;
            }
        }

        return best;
    }

    static void Main() => Bench.Run(149, Solve);
}
