// Answer: 17427258
using System;

namespace Problem187;

internal static class Program
{
    const int Limit = 100000000;
    static int[]? _primes;
    static int _nprimes;
    static bool _initialized;

    static void Init()
    {
        byte[] sieve = new byte[Limit];
        sieve[0] = sieve[1] = 1;
        for (long i = 2; i * i < Limit; i++)
            if (sieve[i] == 0)
                for (long j = i * i; j < Limit; j += i)
                    sieve[j] = 1;

        _nprimes = 0;
        for (int i = 2; i < Limit; i++) if (sieve[i] == 0) _nprimes++;
        _primes = new int[_nprimes];
        int idx = 0;
        for (int i = 2; i < Limit; i++) if (sieve[i] == 0) _primes[idx++] = i;
    }

    static long Solve()
    {
        if (!_initialized) { Init(); _initialized = true; }

        long count = 0;
        for (int i = 0; i < _nprimes; i++)
        {
            long p = _primes![i];
            if (p * p >= Limit) break;
            long maxQ = (Limit - 1) / p;
            int lo = i, hi = _nprimes - 1, ans = i - 1;
            while (lo <= hi)
            {
                int mid = (lo + hi) / 2;
                if (_primes[mid] <= maxQ) { ans = mid; lo = mid + 1; }
                else hi = mid - 1;
            }
            if (ans >= i) count += ans - i + 1;
        }

        return count;
    }

    static void Main() => Bench.Run(187, Solve);
}
