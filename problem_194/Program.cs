// Problem 194: Coloured Configurations
// Answer: 61190912
using System;

namespace Problem194;

internal static class Program
{
    const int MaxV = 50;
    static bool[,] adj = new bool[MaxV, MaxV];
    static int nVerts;

    static void ResetG()
    {
        Array.Clear(adj, 0, adj.Length);
        nVerts = 0;
    }

    static void AddEdge(int u, int v) { adj[u, v] = true; adj[v, u] = true; }
    static int NewV() { return nVerts++; }

    static long Chromatic(int t)
    {
        int nv = nVerts;
        long tot = 1;
        for (int i = 0; i < nv; i++) tot *= t;
        int[] col = new int[nv];
        long cnt = 0;
        for (long m = 0; m < tot; m++)
        {
            long x = m;
            for (int i = 0; i < nv; i++) { col[i] = (int)(x % t); x /= t; }
            bool ok = true;
            for (int u = 0; u < nv && ok; u++)
                for (int v = u + 1; v < nv && ok; v++)
                    if (adj[u, v] && col[u] == col[v]) ok = false;
            if (ok) cnt++;
        }
        return cnt;
    }

    static void BuildNew(int a, int b)
    {
        ResetG();
        int v0 = NewV(), v1 = NewV(), v2 = NewV();
        AddEdge(v0, v1); AddEdge(v1, v2); AddEdge(v0, v2);
        int nk0 = v1, nk1 = v2;
        for (int i = 0; i < a; i++)
        {
            int w1 = NewV(); AddEdge(w1, nk0); AddEdge(w1, nk1);
            int w2 = NewV(); AddEdge(w2, nk1); AddEdge(w2, w1);
            nk0 = w1; nk1 = w2;
        }
        for (int i = 0; i < b; i++)
        {
            int w1 = NewV(); AddEdge(w1, nk0); AddEdge(w1, nk1);
            int w2 = NewV(); AddEdge(w2, nk1); AddEdge(w2, w1);
            int w3 = NewV(); AddEdge(w3, w1); AddEdge(w3, w2);
            nk0 = w2; nk1 = w3;
        }
    }

    static long Solve()
    {
        BuildNew(1, 0); long p4_10 = Chromatic(4);
        BuildNew(0, 1); long p4_01 = Chromatic(4);
        BuildNew(1, 1); long p4_11 = Chromatic(4);
        BuildNew(2, 0); long p4_20 = Chromatic(4);
        return p4_10 * 10000000L + p4_01 * 1000000L + p4_11 * 1000L + p4_20;
    }

    static void Main() => Bench.Run(194, Solve);
}
