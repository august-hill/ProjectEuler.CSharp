// Answer: 453647705
using System;

namespace Problem133;

internal static class Program
{
    const int Limit = 100000;
    static bool[] _notPrime = new bool[Limit];
    static bool _initialized;

    static long ModPow(long b, long exp, long mod)
    {
        long result = 1;
        b %= mod;
        while (exp > 0)
        {
            if ((exp & 1) != 0) result = result * b % mod;
            b = b * b % mod;
            exp >>= 1;
        }
        return result;
    }

    static void Init()
    {
        _notPrime[0] = _notPrime[1] = true;
        for (int i = 2; i * i < Limit; i++)
            if (!_notPrime[i])
                for (int j = i * i; j < Limit; j += i)
                    _notPrime[j] = true;
    }

    static long Solve()
    {
        if (!_initialized) { Init(); _initialized = true; }

        long exp = 1;
        for (int i = 0; i < 16; i++) exp *= 10;

        long sum = 0;
        for (int p = 2; p < Limit; p++)
        {
            if (_notPrime[p]) continue;
            if (p == 2 || p == 5) { sum += p; continue; }
            if (p == 3) { sum += 3; continue; }
            if (ModPow(10, exp, p) != 1) sum += p;
        }
        return sum;
    }

    static void Main() => Bench.Run(133, Solve);
}
