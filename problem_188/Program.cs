// Answer: 95962097
using System;

namespace Problem188;

internal static class Program
{
    const ulong Mod = 100000000UL;

    static ulong ModPow(ulong b, ulong exp, ulong mod)
    {
        ulong result = 1;
        b %= mod;
        while (exp > 0)
        {
            if ((exp & 1) != 0) result = result * b % mod;
            exp >>= 1;
            b = b * b % mod;
        }
        return result;
    }

    static ulong EulerTotient(ulong n)
    {
        ulong result = n;
        ulong orig = n;
        for (ulong p = 2; p * p <= orig; p++)
        {
            if (orig % p == 0)
            {
                while (orig % p == 0) orig /= p;
                result -= result / p;
            }
        }
        if (orig > 1) result -= result / orig;
        return result;
    }

    static ulong Hyper(ulong a, ulong b, ulong m)
    {
        if (m == 1) return 0;
        if (b == 1) return a % m;
        ulong phi = EulerTotient(m);
        ulong exp = Hyper(a, b - 1, phi);
        return ModPow(a, exp + phi, m);
    }

    static long Solve() => (long)Hyper(1777, 1855, Mod);

    static void Main() => Bench.Run(188, Solve);
}
