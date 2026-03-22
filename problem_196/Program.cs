// Problem 196: Prime Triplets
// Answer: 322303240771079935
using System;
using System.Numerics;

namespace Problem196;

internal static class Program
{
    static ulong Mulmod(ulong a, ulong b, ulong m)
    {
        return (ulong)((BigInteger)a * b % m);
    }

    static ulong Powmod(ulong baseVal, ulong exp, ulong mod)
    {
        ulong result = 1;
        baseVal %= mod;
        while (exp > 0)
        {
            if ((exp & 1) == 1) result = Mulmod(result, baseVal, mod);
            exp >>= 1;
            baseVal = Mulmod(baseVal, baseVal, mod);
        }
        return result;
    }

    static bool MillerRabin(ulong n)
    {
        if (n < 2) return false;
        if (n == 2 || n == 3 || n == 5 || n == 7) return true;
        if (n % 2 == 0 || n % 3 == 0 || n % 5 == 0) return false;
        ulong d = n - 1;
        int r = 0;
        while (d % 2 == 0) { d /= 2; r++; }
        ulong[] witnesses = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37 };
        foreach (ulong a in witnesses)
        {
            if (a >= n) continue;
            ulong x = Powmod(a, d, n);
            if (x == 1 || x == n - 1) continue;
            bool composite = true;
            for (int i = 0; i < r - 1; i++)
            {
                x = Mulmod(x, x, n);
                if (x == n - 1) { composite = false; break; }
            }
            if (composite) return false;
        }
        return true;
    }

    static ulong RowStart(ulong r) => r * (r - 1) / 2 + 1;

    static bool AreNeighbours(ulong r1, int c1, ulong r2, int c2)
    {
        if (r1 == r2) return c1 == c2 - 1 || c1 == c2 + 1;
        if (r1 + 1 == r2) return c1 == c2 - 1 || c1 == c2;
        if (r1 == r2 + 1) return c2 == c1 - 1 || c2 == c1;
        return false;
    }

    static ulong SumPrimeTriplets(ulong r)
    {
        ulong s = RowStart(r);
        ulong total = 0;
        ulong[] prow = new ulong[20];
        int[] pcol = new int[20];

        for (int c = 0; c < (int)r; c++)
        {
            ulong p = s + (ulong)c;
            if (!MillerRabin(p)) continue;

            int np = 0;

            // Row r-1
            if (r >= 2)
            {
                ulong s2 = RowStart(r - 1);
                int lo = Math.Max(0, c - 2);
                int hi = Math.Min(c + 1, (int)(r - 1) - 1);
                for (int j = lo; j <= hi; j++)
                {
                    if (MillerRabin(s2 + (ulong)j)) { prow[np] = r - 1; pcol[np] = j; np++; }
                }
            }
            // Row r (skip self)
            {
                int lo = Math.Max(0, c - 2);
                int hi = Math.Min(c + 2, (int)r - 1);
                for (int j = lo; j <= hi; j++)
                {
                    if (j == c) continue;
                    if (MillerRabin(s + (ulong)j)) { prow[np] = r; pcol[np] = j; np++; }
                }
            }
            // Add self
            prow[np] = r; pcol[np] = c; np++;
            int selfIdx = np - 1;

            // Row r+1
            {
                ulong s2 = RowStart(r + 1);
                int lo = Math.Max(0, c - 1);
                int hi = Math.Min(c + 2, (int)r);
                for (int j = lo; j <= hi; j++)
                {
                    if (MillerRabin(s2 + (ulong)j)) { prow[np] = r + 1; pcol[np] = j; np++; }
                }
            }

            bool inTriplet = false;
            for (int i = 0; i < np && !inTriplet; i++)
            {
                if (i == selfIdx) continue;
                if (!AreNeighbours(r, c, prow[i], pcol[i])) continue;
                for (int j = i + 1; j < np && !inTriplet; j++)
                {
                    if (j == selfIdx) continue;
                    if (!AreNeighbours(r, c, prow[j], pcol[j])) continue;
                    if (AreNeighbours(prow[i], pcol[i], prow[j], pcol[j]))
                        inTriplet = true;
                }
            }

            if (inTriplet) total += p;
        }
        return total;
    }

    static long Solve()
    {
        ulong a = SumPrimeTriplets(5678027UL);
        ulong b = SumPrimeTriplets(7208785UL);
        return (long)(a + b);
    }

    static void Main() => Bench.Run(196, Solve);
}
