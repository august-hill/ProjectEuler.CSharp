// Answer: 18407904
using System;

namespace Problem127;

internal static class Program
{
    const int Limit = 120000;
    static int[] _rad = new int[Limit];
    static int[] _sortedByRad = new int[Limit];
    static bool _initialized;

    static int Gcd(int a, int b)
    {
        while (b != 0) { int t = b; b = a % b; a = t; }
        return a;
    }

    static void Init()
    {
        for (int i = 0; i < Limit; i++) _rad[i] = 1;
        for (int p = 2; p < Limit; p++)
        {
            if (_rad[p] == 1) // prime
                for (int j = p; j < Limit; j += p)
                    _rad[j] *= p;
        }
        for (int i = 0; i < Limit; i++) _sortedByRad[i] = i;
        Array.Sort(_sortedByRad, (ia, ib) =>
            _rad[ia] != _rad[ib] ? _rad[ia] - _rad[ib] : ia - ib);
    }

    static long Solve()
    {
        if (!_initialized) { Init(); _initialized = true; }

        long total = 0;
        for (int c = 2; c < Limit; c++)
        {
            long radLimit = (long)c / _rad[c];
            for (int i = 1; i < Limit; i++)
            {
                int a = _sortedByRad[i];
                if (a == 0) continue;
                if (_rad[a] >= radLimit) break;
                if (a >= c) continue;
                int b = c - a;
                if (b <= a) continue;
                if ((long)_rad[a] * _rad[b] >= radLimit) continue;
                if (Gcd(a, b) != 1) continue;
                total += c;
            }
        }
        return total;
    }

    static void Main() => Bench.Run(127, Solve);
}
