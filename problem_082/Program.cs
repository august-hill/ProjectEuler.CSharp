// Answer: 260324
using System;
using System.IO;
using System.Linq;

namespace Problem82;

internal static class Program
{
    private static int[][]? _cachedMatrix;
    private static int[][] LoadMatrix()
    {
        if (_cachedMatrix != null) return _cachedMatrix;
        var lines = File.ReadAllLines("p082_matrix.txt").Where(l => l.Trim().Length > 0).ToArray();
        _cachedMatrix = lines.Select(l => l.Split(',').Select(int.Parse).ToArray()).ToArray();
        return _cachedMatrix;
    }

    static long Solve()
    {
        var matrix = LoadMatrix();
        int n = matrix.Length, m = matrix[0].Length;
        var dp = new long[n];
        for (int i = 0; i < n; i++) dp[i] = matrix[i][0];
        for (int j = 1; j < m; j++)
        {
            var newDp = new long[n];
            for (int i = 0; i < n; i++) newDp[i] = dp[i] + matrix[i][j];
            for (int i = 1; i < n; i++)
                newDp[i] = Math.Min(newDp[i], newDp[i - 1] + matrix[i][j]);
            for (int i = n - 2; i >= 0; i--)
                newDp[i] = Math.Min(newDp[i], newDp[i + 1] + matrix[i][j]);
            dp = newDp;
        }
        return dp.Min();
    }

    static void Main() => Bench.Run(82, Solve);
}
