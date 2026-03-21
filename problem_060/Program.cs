// Answer: 26033
using System;
using System.Collections.Generic;

namespace Problem60;

internal static class Program
{
    static long Solve()
    {
        const int LIMIT = 10000;
        const int SIEVE_SIZE = 100_000_000;

        bool[] isComposite = new bool[SIEVE_SIZE];
        isComposite[0] = true;
        isComposite[1] = true;
        for (int i = 2; (long)i * i < SIEVE_SIZE; i++)
        {
            if (!isComposite[i])
                for (long j = (long)i * i; j < SIEVE_SIZE; j += i)
                    isComposite[j] = true;
        }

        bool SievePrime(long n) => n >= 2 && n < SIEVE_SIZE && !isComposite[n];

        ulong ModPow(ulong b, ulong exp, ulong mod)
        {
            ulong result = 1;
            b %= mod;
            while (exp > 0)
            {
                if ((exp & 1) == 1)
                    result = (ulong)((System.Numerics.BigInteger)result * b % mod);
                exp >>= 1;
                b = (ulong)((System.Numerics.BigInteger)b * b % mod);
            }
            return result;
        }

        bool MillerRabin(ulong n)
        {
            if (n < 2) return false;
            if (n < 4) return true;
            if (n % 2 == 0) return false;
            ulong d = n - 1;
            int r = 0;
            while (d % 2 == 0) { d /= 2; r++; }
            ulong[] witnesses = { 2, 3, 5, 7 };
            foreach (var a in witnesses)
            {
                if (a >= n) continue;
                ulong x = ModPow(a, d, n);
                if (x == 1 || x == n - 1) continue;
                bool composite = true;
                for (int i = 0; i < r - 1; i++)
                {
                    x = (ulong)((System.Numerics.BigInteger)x * x % n);
                    if (x == n - 1) { composite = false; break; }
                }
                if (composite) return false;
            }
            return true;
        }

        bool CheckPrime(long n) => n < SIEVE_SIZE ? SievePrime(n) : MillerRabin((ulong)n);

        long Concat(long a, long b)
        {
            long mult = 1, tmp = b;
            while (tmp > 0) { mult *= 10; tmp /= 10; }
            return a * mult + b;
        }

        bool IsPair(long a, long b) => CheckPrime(Concat(a, b)) && CheckPrime(Concat(b, a));

        var primes = new List<int>();
        for (int i = 2; i < LIMIT; i++)
            if (!isComposite[i]) primes.Add(i);

        int n2 = primes.Count;
        long best = long.MaxValue;

        for (int ai = 0; ai < n2; ai++)
        {
            long a2 = primes[ai];
            if (a2 * 5 >= best) break;
            for (int bi = ai + 1; bi < n2; bi++)
            {
                long b2 = primes[bi];
                if ((a2 + b2) * 5 / 2 >= best) break;
                if (!IsPair(a2, b2)) continue;
                for (int ci = bi + 1; ci < n2; ci++)
                {
                    long c = primes[ci];
                    if ((a2 + b2 + c) * 5 / 3 >= best) break;
                    if (!IsPair(a2, c) || !IsPair(b2, c)) continue;
                    for (int di = ci + 1; di < n2; di++)
                    {
                        long d2 = primes[di];
                        long partial = a2 + b2 + c + d2;
                        if (partial >= best) break;
                        if (!IsPair(a2, d2) || !IsPair(b2, d2) || !IsPair(c, d2)) continue;
                        for (int ei = di + 1; ei < n2; ei++)
                        {
                            long e = primes[ei];
                            long sum = partial + e;
                            if (sum >= best) break;
                            if (!IsPair(a2, e) || !IsPair(b2, e) || !IsPair(c, e) || !IsPair(d2, e)) continue;
                            best = sum;
                        }
                    }
                }
            }
        }

        return best;
    }

    static void Main() => Bench.Run(60, Solve);
}
