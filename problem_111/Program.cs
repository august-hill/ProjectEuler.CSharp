// Answer: 612407567715
using System;

namespace Problem111;

internal static class Program
{
    static ulong ModPow(ulong b, ulong exp, ulong mod)
    {
        ulong result = 1;
        b %= mod;
        while (exp > 0)
        {
            if ((exp & 1) != 0) result = (ulong)((System.UInt128)result * b % mod);
            exp >>= 1;
            b = (ulong)((System.UInt128)b * b % mod);
        }
        return result;
    }

    static bool IsPrime(ulong n)
    {
        if (n < 2) return false;
        if (n < 4) return true;
        if (n % 2 == 0 || n % 3 == 0) return false;
        ulong[] witnesses = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37 };
        ulong d = n - 1;
        int r = 0;
        while (d % 2 == 0) { d /= 2; r++; }
        foreach (var a in witnesses)
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

    static long SumPrimesWithRepeated(int d, int nfree, out int found)
    {
        int n = 10;
        long total = 0;
        found = 0;

        for (int mask = 0; mask < (1 << n); mask++)
        {
            if (PopCount(mask) != nfree) continue;

            int[] freePos = new int[nfree];
            int nf = 0;
            for (int i = 0; i < n; i++)
                if ((mask & (1 << i)) != 0) freePos[nf++] = i;

            int[] digits = new int[n];
            for (int i = 0; i < n; i++) digits[i] = d;

            int[] assignment = new int[nf];

            while (true)
            {
                bool valid = true;
                for (int i = 0; i < nf; i++)
                    if (assignment[i] == d) { valid = false; break; }

                if (valid)
                {
                    for (int i = 0; i < nf; i++) digits[freePos[i]] = assignment[i];
                    for (int i = 0; i < n; i++)
                        if ((mask & (1 << i)) == 0) digits[i] = d;

                    if (digits[0] != 0)
                    {
                        ulong num = 0;
                        for (int i = 0; i < n; i++) num = num * 10 + (ulong)digits[i];
                        if (IsPrime(num))
                        {
                            total += (long)num;
                            found++;
                        }
                    }
                }

                // Increment assignment
                bool carry = true;
                for (int i = nf - 1; i >= 0 && carry; i--)
                {
                    assignment[i]++;
                    if (assignment[i] >= 10) assignment[i] = 0;
                    else carry = false;
                }
                if (carry) break;
            }
        }
        return total;
    }

    static int PopCount(int x)
    {
        int count = 0;
        while (x != 0) { count += x & 1; x >>= 1; }
        return count;
    }

    static long Solve()
    {
        long total = 0;
        for (int d = 0; d <= 9; d++)
        {
            for (int nfree = 0; nfree <= 9; nfree++)
            {
                long s = SumPrimesWithRepeated(d, nfree, out int found);
                if (found > 0)
                {
                    total += s;
                    break;
                }
            }
        }
        return total;
    }

    static void Main() => Bench.Run(111, Solve);
}
