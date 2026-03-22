// Answer: 21035
using System;

namespace Problem123;

internal static class Program
{
    const int SieveSize = 1000000;
    static byte[] _sieve = new byte[SieveSize / 8 + 1];
    static int[] _primes = new int[100000];
    static int _nprimes;
    static bool _initialized;

    static void Init()
    {
        _sieve[0] |= 3;
        for (int i = 2; (long)i * i < SieveSize; i++)
        {
            if ((_sieve[i / 8] & (1 << (i % 8))) == 0)
                for (long j = (long)i * i; j < SieveSize; j += i)
                    _sieve[j / 8] |= (byte)(1 << ((int)(j % 8)));
        }
        _nprimes = 0;
        for (int i = 2; i < SieveSize; i++)
            if ((_sieve[i / 8] & (1 << (i % 8))) == 0)
                _primes[_nprimes++] = i;
    }

    static long Solve()
    {
        if (!_initialized) { Init(); _initialized = true; }

        long target = 10000000000L;
        for (int i = 0; i < _nprimes; i++)
        {
            int n = i + 1;
            if (n % 2 == 0) continue;
            long p = _primes[i];
            long r = (2L * n * p) % (p * p);
            if (r > target) return n;
        }
        return -1;
    }

    static void Main() => Bench.Run(123, Solve);
}
