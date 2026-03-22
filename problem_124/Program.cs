// Answer: 21417
using System;

namespace Problem124;

internal static class Program
{
    const int N = 100000;
    static int[] _rad = new int[N + 1];
    static bool _initialized;

    static void Init()
    {
        for (int i = 1; i <= N; i++) _rad[i] = 1;
        for (int i = 2; i <= N; i++)
        {
            if (_rad[i] == 1) // i is prime
                for (int j = i; j <= N; j += i)
                    _rad[j] *= i;
        }
    }

    static long Solve()
    {
        if (!_initialized) { Init(); _initialized = true; }

        (int n, int rad)[] entries = new (int, int)[N];
        for (int i = 1; i <= N; i++)
            entries[i - 1] = (i, _rad[i]);

        Array.Sort(entries, (a, b) => a.rad != b.rad ? a.rad - b.rad : a.n - b.n);

        return entries[9999].n;
    }

    static void Main() => Bench.Run(124, Solve);
}
