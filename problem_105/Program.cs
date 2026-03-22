// Answer: 73702
using System;
using System.IO;

namespace Problem105;

internal static class Program
{
    private static string[]? _cachedLines;

    static string[] LoadLines()
    {
        if (_cachedLines != null) return _cachedLines;
        _cachedLines = File.ReadAllLines("p105_sets.txt");
        return _cachedLines;
    }

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
        var lines = LoadLines();
        long total = 0;
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            var parts = line.Trim().Split(',');
            int n = parts.Length;
            int[] set = new int[n];
            for (int i = 0; i < n; i++) set[i] = int.Parse(parts[i]);
            Array.Sort(set);
            if (IsSpecial(set, n))
                foreach (var v in set) total += v;
        }
        return total;
    }

    static void Main() => Bench.Run(105, Solve);
}
