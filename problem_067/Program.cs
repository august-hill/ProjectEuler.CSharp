// Answer: 7273
using System;
using System.IO;
using System.Linq;

namespace Problem67;

internal static class Program
{
    private static int[][]? _cachedRows;
    private static int[][] LoadRows()
    {
        if (_cachedRows != null) return _cachedRows;
        var lines = File.ReadAllLines("p067_triangle.txt")
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .ToArray();
        _cachedRows = lines.Select(l =>
            l.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse).ToArray()
        ).ToArray();
        return _cachedRows;
    }

    static long Solve()
    {
        var template = LoadRows();
        // Deep copy to avoid mutation
        var rows = template.Select(r => r.ToArray()).ToArray();
        for (int i = rows.Length - 2; i >= 0; i--)
            for (int j = 0; j < rows[i].Length; j++)
                rows[i][j] += Math.Max(rows[i + 1][j], rows[i + 1][j + 1]);
        return rows[0][0];
    }

    static void Main() => Bench.Run(67, Solve);
}
