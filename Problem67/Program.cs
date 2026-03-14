using System;
using System.IO;
using System.Linq;

// Problem 67: Maximum Path Sum II
// Find the maximum total from top to bottom of a 100-row triangle.
// Answer: 7273

using System.Diagnostics;

static int Solve()
{
    var lines = File.ReadAllLines("p067_triangle.txt")
        .Where(l => !string.IsNullOrWhiteSpace(l))
        .ToArray();
    var rows = lines.Select(l =>
        l.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries)
         .Select(int.Parse).ToArray()
    ).ToArray();

    // Dynamic programming: work from bottom up
    for (int i = rows.Length - 2; i >= 0; i--)
    {
        for (int j = 0; j < rows[i].Length; j++)
        {
            rows[i][j] += Math.Max(rows[i + 1][j], rows[i + 1][j + 1]);
        }
    }
    return rows[0][0];
}

// Warmup
for (int i = 0; i < 10; i++) Solve();

var sw = Stopwatch.StartNew();
int iterations = 10000;
int result = 0;
for (int i = 0; i < iterations; i++) result = Solve();
sw.Stop();

double nsPerOp = sw.Elapsed.TotalNanoseconds / iterations;
Console.WriteLine("Problem 67: Maximum Path Sum II");
Console.WriteLine("===============================");
Console.WriteLine($"Result: {result} ({nsPerOp:F2} ns/op)");
