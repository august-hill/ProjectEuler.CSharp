// Answer: 44680
using System;

namespace Problem118;

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
        if (n == 2 || n == 3) return true;
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

    static int _totalCount;

    static bool NextPerm(int[] arr, int n)
    {
        int i = n - 2;
        while (i >= 0 && arr[i] >= arr[i + 1]) i--;
        if (i < 0) return false;
        int j = n - 1;
        while (arr[j] <= arr[i]) j--;
        int tmp = arr[i]; arr[i] = arr[j]; arr[j] = tmp;
        for (int a = i + 1, b = n - 1; a < b; a++, b--)
        { tmp = arr[a]; arr[a] = arr[b]; arr[b] = tmp; }
        return true;
    }

    static void Search(int usedMask, long prevNum)
    {
        if (usedMask == 0x1FF) { _totalCount++; return; }

        int remaining = (~usedMask) & 0x1FF;
        for (int sub = remaining; sub > 0; sub = (sub - 1) & remaining)
        {
            int[] digs = new int[9];
            int nd = 0;
            for (int i = 0; i < 9; i++)
                if ((sub & (1 << i)) != 0) digs[nd++] = i + 1;

            int[] perm = new int[nd];
            Array.Copy(digs, perm, nd);
            do
            {
                long num = 0;
                for (int i = 0; i < nd; i++) num = num * 10 + perm[i];
                if (num > prevNum && IsPrime((ulong)num))
                    Search(usedMask | sub, num);
            } while (NextPerm(perm, nd));

            if (sub == 0) break; // avoid infinite loop when remaining == 0
        }
    }

    static long Solve()
    {
        _totalCount = 0;
        Search(0, 0);
        return _totalCount;
    }

    static void Main() => Bench.Run(118, Solve);
}
