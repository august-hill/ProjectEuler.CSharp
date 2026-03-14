using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Problem 83: Path Sum: Four Ways
// Find the minimal path sum from top-left to bottom-right, moving in all 4 directions.
// Answer: 425185

using System.Diagnostics;

var matrixLines = File.ReadAllLines("p083_matrix.txt").Where(l => l.Trim().Length > 0).ToArray();
var matrix = matrixLines.Select(l => l.Split(',').Select(int.Parse).ToArray()).ToArray();

static long Solve(int[][] matrix)
{
    int n = matrix.Length, m = matrix[0].Length;
    var dist = new long[n, m];
    for (int i = 0; i < n; i++)
        for (int j = 0; j < m; j++)
            dist[i, j] = long.MaxValue;

    // PriorityQueue: (cost, row, col)
    var pq = new PriorityQueue<(int r, int c), long>();
    dist[0, 0] = matrix[0][0];
    pq.Enqueue((0, 0), matrix[0][0]);

    int[] dr = [-1, 1, 0, 0];
    int[] dc = [0, 0, -1, 1];

    while (pq.Count > 0)
    {
        pq.TryDequeue(out var node, out long cost);
        if (cost > dist[node.r, node.c]) continue;
        if (node.r == n - 1 && node.c == m - 1) return cost;

        for (int d = 0; d < 4; d++)
        {
            int nr = node.r + dr[d], nc = node.c + dc[d];
            if (nr >= 0 && nr < n && nc >= 0 && nc < m)
            {
                long newCost = cost + matrix[nr][nc];
                if (newCost < dist[nr, nc])
                {
                    dist[nr, nc] = newCost;
                    pq.Enqueue((nr, nc), newCost);
                }
            }
        }
    }

    return dist[n-1, m-1];
}

for (int i = 0; i < 10; i++) Solve(matrix);

const int iterations = 10000;
var sw = Stopwatch.StartNew();
long result = 0;
for (int i = 0; i < iterations; i++) result = Solve(matrix);
sw.Stop();

double nsPerOp = (double)sw.Elapsed.Ticks / iterations * 100;
Console.WriteLine($"Result: {result} ({nsPerOp:F2} ns/op)");
