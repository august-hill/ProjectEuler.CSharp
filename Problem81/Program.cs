using System;
using System.IO;
using System.Linq;

// Problem 81: Path Sum: Two Ways
// Find the minimal path sum from top-left to bottom-right, moving only right and down.
// Answer: 427337

using System.Diagnostics;

var matrixLines = File.ReadAllLines("p081_matrix.txt").Where(l => l.Trim().Length > 0).ToArray();
var matrix = matrixLines.Select(l => l.Split(',').Select(int.Parse).ToArray()).ToArray();

static long Solve(int[][] matrix)
{
    int n = matrix.Length, m = matrix[0].Length;
    var dp = new long[n, m];
    dp[0, 0] = matrix[0][0];
    for (int j = 1; j < m; j++) dp[0, j] = dp[0, j-1] + matrix[0][j];
    for (int i = 1; i < n; i++) dp[i, 0] = dp[i-1, 0] + matrix[i][0];
    for (int i = 1; i < n; i++)
        for (int j = 1; j < m; j++)
            dp[i, j] = Math.Min(dp[i-1, j], dp[i, j-1]) + matrix[i][j];
    return dp[n-1, m-1];
}

for (int i = 0; i < 10; i++) Solve(matrix);

const int iterations = 10000;
var sw = Stopwatch.StartNew();
long result = 0;
for (int i = 0; i < iterations; i++) result = Solve(matrix);
sw.Stop();

double nsPerOp = (double)sw.Elapsed.Ticks / iterations * 100;
Console.WriteLine($"Result: {result} ({nsPerOp:F2} ns/op)");
