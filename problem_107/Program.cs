// Answer: 259679
using System;
using System.IO;

namespace Problem107;

internal struct Edge { public int U, V, W; }

internal static class Program
{
    private static string[]? _cachedLines;

    static string[] LoadLines()
    {
        if (_cachedLines != null) return _cachedLines;
        _cachedLines = File.ReadAllLines("p107_network.txt");
        return _cachedLines;
    }

    static int[] _parent = new int[40];

    static int Find(int x)
    {
        while (_parent[x] != x) { _parent[x] = _parent[_parent[x]]; x = _parent[x]; }
        return x;
    }

    static bool Unite(int a, int b)
    {
        a = Find(a); b = Find(b);
        if (a == b) return false;
        _parent[a] = b;
        return true;
    }

    static long Solve()
    {
        var lines = LoadLines();
        int nlines = 0;
        int[,] adj = new int[40, 40];

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            var tokens = line.Split(',');
            for (int j = 0; j < tokens.Length; j++)
            {
                var tok = tokens[j].Trim();
                if (tok != "-")
                    adj[nlines, j] = int.Parse(tok);
            }
            nlines++;
        }

        int totalWeight = 0;
        Edge[] edges = new Edge[40 * 40];
        int nedges = 0;
        for (int i = 0; i < nlines; i++)
        {
            for (int j = i + 1; j < nlines; j++)
            {
                if (adj[i, j] > 0)
                {
                    totalWeight += adj[i, j];
                    edges[nedges++] = new Edge { U = i, V = j, W = adj[i, j] };
                }
            }
        }

        // Sort only the used portion
        Edge[] used = new Edge[nedges];
        Array.Copy(edges, used, nedges);
        Array.Sort(used, (a, b) => a.W.CompareTo(b.W));

        for (int i = 0; i < nlines; i++) _parent[i] = i;

        int mstWeight = 0;
        for (int i = 0; i < nedges; i++)
        {
            if (Unite(used[i].U, used[i].V))
                mstWeight += used[i].W;
        }

        return totalWeight - mstWeight;
    }

    static void Main() => Bench.Run(107, Solve);
}
