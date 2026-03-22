// Answer: 229161792008
using System;
using System.Collections.Generic;

namespace Problem200;

internal static class Program
{
    static ulong ModPow(ulong b, ulong exp, ulong mod)
    {
        System.UInt128 result = 1;
        System.UInt128 bb = b % mod;
        while (exp > 0)
        {
            if ((exp & 1) != 0) result = result * bb % mod;
            exp >>= 1;
            bb = bb * bb % mod;
        }
        return (ulong)result;
    }

    static bool MillerRabin(ulong n)
    {
        if (n < 2) return false;
        if (n < 4) return n >= 2;
        if (n % 2 == 0) return false;
        ulong d = n - 1;
        int r = 0;
        while (d % 2 == 0) { d /= 2; r++; }
        ulong[] witnesses = {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37};
        foreach (ulong a in witnesses)
        {
            if (a >= n) continue;
            ulong x = ModPow(a, d, n);
            if (x == 1 || x == n - 1) continue;
            bool composite = true;
            for (int i = 0; i < r - 1; i++)
            {
                x = (ulong)((System.UInt128)x * x % n);
                if (x == n - 1) { composite = false; break; }
            }
            if (composite) return false;
        }
        return true;
    }

    static bool Contains200(ulong n)
    {
        byte[] buf = new byte[20];
        int len = 0;
        ulong tmp = n;
        while (tmp > 0) { buf[len++] = (byte)(tmp % 10); tmp /= 10; }
        for (int i = len - 1; i >= 2; i--)
            if (buf[i] == 2 && buf[i - 1] == 0 && buf[i - 2] == 0) return true;
        return false;
    }

    static bool IsPrimeProof(ulong n)
    {
        byte[] digits = new byte[20];
        int len = 0;
        ulong tmp = n;
        while (tmp > 0) { digits[len++] = (byte)(tmp % 10); tmp /= 10; }

        for (int pos = 0; pos < len; pos++)
        {
            int orig = digits[pos];
            for (int d = 0; d <= 9; d++)
            {
                if (d == orig) continue;
                if (pos == len - 1 && d == 0) continue;
                digits[pos] = (byte)d;
                ulong val = 0;
                for (int i = len - 1; i >= 0; i--) val = val * 10 + digits[i];
                if (MillerRabin(val)) { digits[pos] = (byte)orig; return false; }
            }
            digits[pos] = (byte)orig;
        }
        return true;
    }

    const int SieveLim = 1000000;
    static int[]? _primes;
    static int _nprimes;
    static bool _initialized;

    static void InitSieve()
    {
        byte[] sieve = new byte[SieveLim];
        sieve[0] = sieve[1] = 1;
        for (int i = 2; (long)i * i < SieveLim; i++)
            if (sieve[i] == 0)
                for (int j = i * i; j < SieveLim; j += i) sieve[j] = 1;
        _nprimes = 0;
        for (int i = 2; i < SieveLim; i++) if (sieve[i] == 0) _nprimes++;
        _primes = new int[_nprimes];
        int idx = 0;
        for (int i = 2; i < SieveLim; i++) if (sieve[i] == 0) _primes[idx++] = i;
    }

    static long Solve()
    {
        if (!_initialized) { InitSieve(); _initialized = true; }

        const ulong Limit = 300000000000UL;

        var squbes = new List<ulong>(1000000);

        for (int qi = 0; qi < _nprimes; qi++)
        {
            ulong q = (ulong)_primes![qi];
            ulong q3 = q * q * q;
            if (q3 > Limit) break;
            for (int pi = 0; pi < _nprimes; pi++)
            {
                if (pi == qi) continue;
                ulong p = (ulong)_primes[pi];
                ulong p2 = p * p;
                ulong sqube = p2 * q3;
                if (sqube > Limit) break;
                if (Contains200(sqube)) squbes.Add(sqube);
            }
        }

        squbes.Sort();

        // Deduplicate
        var unique = new List<ulong>(squbes.Count);
        for (int i = 0; i < squbes.Count; i++)
            if (i == 0 || squbes[i] != squbes[i - 1]) unique.Add(squbes[i]);

        int count = 0;
        ulong result = 0;
        foreach (ulong s in unique)
        {
            if (IsPrimeProof(s))
            {
                count++;
                if (count == 200) { result = s; break; }
            }
        }

        return (long)result;
    }

    static void Main() => Bench.Run(200, Solve);
}
