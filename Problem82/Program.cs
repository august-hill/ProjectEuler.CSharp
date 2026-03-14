using System;
using System.IO;
using System.Linq;

// Problem 82: Path Sum: Three Ways
// Find the minimal path sum from left column to right column, moving up, down, and right.
// Answer: 260324

using System.Diagnostics;

var matrixLines = File.ReadAllLines("p082_matrix.txt").Where(l => l.Trim().Length > 0).ToArray();
var matrix = matrixLines.Select(l => l.Split(',').Select(int.Parse).ToArray()).ToArray();

static long Solve(int[][] matrix)
{
    int n = matrix.Length, m = matrix[0].Length;
    var dp = new long[n];
    for (int i = 0; i < n; i++) dp[i] = matrix[i][0];

    for (int j = 1; j < m; j++)
    {
        var newDp = new long[n];
        for (int i = 0; i < n; i++) newDp[i] = dp[i] + matrix[i][j];
        // Pass down
        for (int i = 1; i < n; i++)
            newDp[i] = Math.Min(newDp[i], newDp[i-1] + matrix[i][j]);
        // Pass up
        for (int i = n - 2; i >= 0; i--)
            newDp[i] = Math.Min(newDp[i], newDp[i+1] + matrix[i][j]);
        dp = newDp;
    }
    return dp.Min();
}

for (int i = 0; i < 10; i++) Solve(matrix);

const int iterations = 10000;
var sw = Stopwatch.StartNew();
long result = 0;
for (int i = 0; i < iterations; i++) result = Solve(matrix);
sw.Stop();

double nsPerOp = (double)sw.Elapsed.Ticks / iterations * 100;
Console.WriteLine($"Result: {result} ({nsPerOp:F2} ns/op)");
