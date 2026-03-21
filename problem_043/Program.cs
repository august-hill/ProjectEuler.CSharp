// Answer: 16695334890
using System;
using System.Collections.Generic;

namespace Problem43;

internal static class Program
{
    private static bool IsDivisible(int n, int m) => n % m == 0;

    private static bool NextPermutation<T>(IList<T> a) where T : IComparable
    {
        if (a.Count < 2) return false;
        var k = a.Count - 2;
        while (k >= 0 && a[k].CompareTo(a[k + 1]) >= 0) k--;
        if (k < 0) return false;
        var l = a.Count - 1;
        while (l > k && a[l].CompareTo(a[k]) <= 0) l--;
        var tmp = a[k]; a[k] = a[l]; a[l] = tmp;
        var i = k + 1; var j = a.Count - 1;
        while (i < j) { tmp = a[i]; a[i] = a[j]; a[j] = tmp; i++; j--; }
        return true;
    }

    static long Solve()
    {
        var number = new List<byte> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        long sum = 0;
        do
        {
            if (!IsDivisible(number[1] * 100 + number[2] * 10 + number[3], 2)) continue;
            if (!IsDivisible(number[2] * 100 + number[3] * 10 + number[4], 3)) continue;
            if (!IsDivisible(number[3] * 100 + number[4] * 10 + number[5], 5)) continue;
            if (!IsDivisible(number[4] * 100 + number[5] * 10 + number[6], 7)) continue;
            if (!IsDivisible(number[5] * 100 + number[6] * 10 + number[7], 11)) continue;
            if (!IsDivisible(number[6] * 100 + number[7] * 10 + number[8], 13)) continue;
            if (!IsDivisible(number[7] * 100 + number[8] * 10 + number[9], 17)) continue;

            long n = 0;
            for (int i = 0; i < 10; i++)
                n = n * 10 + number[i];
            sum += n;
        } while (NextPermutation(number));

        return sum;
    }

    static void Main() => Bench.Run(43, Solve);
}
