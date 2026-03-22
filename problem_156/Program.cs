// Answer: 21295121502550
using System;

namespace Problem156;

internal static class Program
{
    static long CountDigit(long n, int d)
    {
        if (n <= 0) return 0;
        long count = 0;
        long factor = 1;
        while (factor <= n)
        {
            long higher = n / (factor * 10);
            long curr = (n / factor) % 10;
            long lower = n % factor;
            if (curr < d) count += higher * factor;
            else if (curr == d) count += higher * factor + lower + 1;
            else count += (higher + 1) * factor;
            factor *= 10;
        }
        return count;
    }

    static long _sumFixed;

    static void FindZeros(int d, long lo, long hi)
    {
        if (lo > hi) return;
        long gLo = CountDigit(lo, d) - lo;
        long gHi = CountDigit(hi, d) - hi;

        if (lo == hi) { if (gLo == 0) _sumFixed += lo; return; }

        if (gLo > 0 && gHi > 0)
            if (gLo > hi - lo && gHi > hi - lo) return;

        if (gLo < 0 && gHi < 0)
            if (-gLo > 12L * (hi - lo) && -gHi > 12L * (hi - lo)) return;

        if (hi - lo < 1000)
        {
            for (long n = lo; n <= hi; n++)
                if (CountDigit(n, d) == n) _sumFixed += n;
            return;
        }

        long mid = lo + (hi - lo) / 2;
        FindZeros(d, lo, mid);
        FindZeros(d, mid + 1, hi);
    }

    static long Solve()
    {
        _sumFixed = 0;
        for (int d = 1; d <= 9; d++)
            FindZeros(d, 1, 200000000000L);
        return _sumFixed;
    }

    static void Main() => Bench.Run(156, Solve);
}
