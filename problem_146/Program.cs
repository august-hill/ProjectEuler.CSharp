// Answer: 676333270
using System;

namespace Problem146;

internal static class Program
{
    const long Limit = 150000000L;

    static bool MillerRabin(long n)
    {
        if (n < 2) return false;
        if (n == 2 || n == 3 || n == 5 || n == 7) return true;
        if (n % 2 == 0 || n % 3 == 0 || n % 5 == 0) return false;

        long d = n - 1;
        int r = 0;
        while (d % 2 == 0) { d /= 2; r++; }

        long[] witnesses = { 2, 3, 5, 7, 11, 13 };
        foreach (var a in witnesses)
        {
            if (a >= n) continue;
            long x = ModPow(a, d, n);
            if (x == 1 || x == n - 1) continue;

            bool composite = true;
            for (int i = 0; i < r - 1; i++)
            {
                x = (long)((System.UInt128)(ulong)x * (ulong)x % (ulong)n);
                if (x == n - 1) { composite = false; break; }
            }
            if (composite) return false;
        }
        return true;
    }

    static long ModPow(long b, long exp, long mod)
    {
        long result = 1;
        b %= mod;
        while (exp > 0)
        {
            if ((exp & 1) != 0) result = (long)((System.UInt128)(ulong)result * (ulong)b % (ulong)mod);
            b = (long)((System.UInt128)(ulong)b * (ulong)b % (ulong)mod);
            exp >>= 1;
        }
        return result;
    }

    static long Solve()
    {
        long sum = 0;

        for (long n = 10; n < Limit; n += 10)
        {
            if (n % 3 == 0) continue;

            int n7 = (int)(n % 7);
            int n2_7 = n7 * n7 % 7;
            if ((n2_7 + 1) % 7 == 0 || (n2_7 + 3) % 7 == 0 ||
                (n2_7 + 7) % 7 == 0 || (n2_7 + 9) % 7 == 0 ||
                (n2_7 + 13) % 7 == 0 || (n2_7 + 27) % 7 == 0) continue;

            int n13 = (int)(n % 13);
            int n2_13 = n13 * n13 % 13;
            if ((n2_13 + 1) % 13 == 0 || (n2_13 + 3) % 13 == 0 ||
                (n2_13 + 7) % 13 == 0 || (n2_13 + 9) % 13 == 0 ||
                (n2_13 + 13) % 13 == 0 || (n2_13 + 27) % 13 == 0) continue;

            long n2 = n * n;

            if (!MillerRabin(n2 + 1)) continue;
            if (!MillerRabin(n2 + 3)) continue;
            if (!MillerRabin(n2 + 7)) continue;
            if (!MillerRabin(n2 + 9)) continue;
            if (!MillerRabin(n2 + 13)) continue;
            if (!MillerRabin(n2 + 27)) continue;

            if (MillerRabin(n2 + 5)) continue;
            if (MillerRabin(n2 + 11)) continue;
            if (MillerRabin(n2 + 15)) continue;
            if (MillerRabin(n2 + 17)) continue;
            if (MillerRabin(n2 + 19)) continue;
            if (MillerRabin(n2 + 21)) continue;
            if (MillerRabin(n2 + 23)) continue;
            if (MillerRabin(n2 + 25)) continue;

            sum += n;
        }
        return sum;
    }

    static void Main() => Bench.Run(146, Solve);
}
