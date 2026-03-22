// Answer: 18613426663617118
using System;

namespace Problem134;

internal static class Program
{
    const int Limit = 1100000;
    static bool[] _notPrime = new bool[Limit];
    static bool _initialized;

    static void Init()
    {
        _notPrime[0] = _notPrime[1] = true;
        for (int i = 2; i * i < Limit; i++)
            if (!_notPrime[i])
                for (int j = i * i; j < Limit; j += i)
                    _notPrime[j] = true;
    }

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

    static long Solve()
    {
        if (!_initialized) { Init(); _initialized = true; }

        long total = 0;

        for (int p1 = 5; p1 <= 1000000; )
        {
            if (_notPrime[p1]) { p1 += 2; continue; }
            int p2 = p1 + 2;
            while (_notPrime[p2]) p2 += 2;

            long pow10 = 1;
            int tmp = p1;
            while (tmp > 0) { pow10 *= 10; tmp /= 10; }

            // k ≡ -p1 * pow10^{-1} (mod p2), using Fermat: pow10^{p2-2} mod p2
            long inv = ModPow(pow10 % p2, p2 - 2, p2);
            long k = ((-p1 % p2 + p2) % p2 * inv) % p2;
            long n = p1 + k * pow10;
            total += n;

            p1 = p2;
        }
        return total;
    }

    static void Main() => Bench.Run(134, Solve);
}
