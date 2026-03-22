// Answer: 20313839404245
using System;

namespace Problem103;

internal static class Program
{
    static bool IsSpecial(int[] set, int n)
    {
        int limit = 1 << n;
        int[] sums = new int[limit];
        int[] sizes = new int[limit];

        for (int mask = 1; mask < limit; mask++)
        {
            int s = 0, sz = 0;
            for (int i = 0; i < n; i++)
                if ((mask & (1 << i)) != 0) { s += set[i]; sz++; }
            sums[mask] = s;
            sizes[mask] = sz;
        }

        for (int a = 1; a < limit; a++)
        {
            for (int b = a + 1; b < limit; b++)
            {
                if ((a & b) != 0) continue;
                if (sums[a] == sums[b]) return false;
                if (sizes[a] > sizes[b] && sums[a] <= sums[b]) return false;
                if (sizes[b] > sizes[a] && sums[b] <= sums[a]) return false;
            }
        }
        return true;
    }

    static long Solve()
    {
        int[] baseSet = { 20, 31, 38, 39, 40, 42, 45 };
        int n = 7;
        int bestSum = 0;
        foreach (var v in baseSet) bestSum += v;
        int[] best = (int[])baseSet.Clone();

        int[] set = new int[7];
        for (int d0 = -3; d0 <= 3; d0++)
        for (int d1 = -3; d1 <= 3; d1++)
        for (int d2 = -3; d2 <= 3; d2++)
        for (int d3 = -3; d3 <= 3; d3++)
        for (int d4 = -3; d4 <= 3; d4++)
        for (int d5 = -3; d5 <= 3; d5++)
        for (int d6 = -3; d6 <= 3; d6++)
        {
            set[0] = baseSet[0] + d0;
            set[1] = baseSet[1] + d1;
            set[2] = baseSet[2] + d2;
            set[3] = baseSet[3] + d3;
            set[4] = baseSet[4] + d4;
            set[5] = baseSet[5] + d5;
            set[6] = baseSet[6] + d6;

            bool valid = true;
            for (int i = 0; i < n && valid; i++)
            {
                if (set[i] <= 0) { valid = false; break; }
                for (int j = i + 1; j < n && valid; j++)
                    if (set[i] >= set[j]) valid = false;
            }
            if (!valid) continue;

            int s = 0;
            foreach (var v in set) s += v;
            if (s >= bestSum) continue;

            if (IsSpecial(set, n))
            {
                bestSum = s;
                Array.Copy(set, best, n);
            }
        }

        long ans = 0;
        for (int i = 0; i < n; i++)
            ans = ans * 100 + best[i];
        return ans;
    }

    static void Main() => Bench.Run(103, Solve);
}
