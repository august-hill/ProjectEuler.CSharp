// Answer: 427337
using System;
using System.IO;
using System.Linq;

namespace Problem81;

internal static class Program
{
    private static int[][]? _cachedMatrix;
    private static int[][] LoadMatrix()
    {
        if (_cachedMatrix != null) return _cachedMatrix;
        var lines = File.ReadAllLines("p081_matrix.txt").Where(l => l.Trim().Length > 0).ToArray();
        _cachedMatrix = lines.Select(l => l.Split(',').Select(int.Parse).ToArray()).ToArray();
        return _cachedMatrix;
    }

    static long Solve()
    {
        var matrix = LoadMatrix();
        int n = matrix.Length, m = matrix[0].Length;
        var dp = new long[n, m];
        dp[0, 0] = matrix[0][0];
        for (int j = 1; j < m; j++) dp[0, j] = dp[0, j - 1] + matrix[0][j];
        for (int i = 1; i < n; i++) dp[i, 0] = dp[i - 1, 0] + matrix[i][0];
        for (int i = 1; i < n; i++)
            for (int j = 1; j < m; j++)
                dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + matrix[i][j];
        return dp[n - 1, m - 1];
    }

    static void Main() => Bench.Run(81, Solve);
}
