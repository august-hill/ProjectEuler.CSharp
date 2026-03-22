// Answer: 684465067343069
using System;

namespace Problem193;

internal static class Program
{
    const int Limit = 33554432; // 2^25 = sqrt(2^50)

    static sbyte[]? _mu;
    static bool _initialized;

    static void Init()
    {
        _mu = new sbyte[Limit];
        for (int i = 0; i < Limit; i++) _mu[i] = 1;
        _mu[0] = 0;

        // Eratosthenes-style Mobius sieve
        for (int p = 2; p < Limit; p++)
        {
            if (_mu[p] != 1) continue; // not prime (already sieved)
            // p is prime
            for (long j = p; j < Limit; j += p)
                _mu[j] = (sbyte)(-_mu[j]);
            long p2 = (long)p * p;
            for (long j = p2; j < Limit; j += p2)
                _mu[j] = 0;
        }
    }

    static long Solve()
    {
        if (!_initialized) { Init(); _initialized = true; }

        long N = 1L << 50;
        long count = 0;

        for (long k = 1; k < Limit; k++)
        {
            if (_mu![k] == 0) continue;
            long k2 = k * k;
            if (k2 > N) break;
            count += _mu[k] * (N / k2);
        }

        return count;
    }

    static void Main() => Bench.Run(193, Solve);
}
