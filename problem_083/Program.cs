// Answer: 425185
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Problem83;

internal static class Program
{
    private static int[][]? _cachedMatrix;
    private static int[][] LoadMatrix()
    {
        if (_cachedMatrix != null) return _cachedMatrix;
        var lines = File.ReadAllLines("p083_matrix.txt").Where(l => l.Trim().Length > 0).ToArray();
        _cachedMatrix = lines.Select(l => l.Split(',').Select(int.Parse).ToArray()).ToArray();
        return _cachedMatrix;
    }

    static long Solve()
    {
        var matrix = LoadMatrix();
        int n = matrix.Length, m = matrix[0].Length;
        var dist = new long[n, m];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                dist[i, j] = long.MaxValue;

        var pq = new PriorityQueue<(int r, int c), long>();
        dist[0, 0] = matrix[0][0];
        pq.Enqueue((0, 0), matrix[0][0]);
        int[] dr = { -1, 1, 0, 0 };
        int[] dc = { 0, 0, -1, 1 };
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
        return dist[n - 1, m - 1];
    }

    static void Main() => Bench.Run(83, Solve);
}
