// Answer: 30758397
using System;
using System.Collections.Generic;

namespace Problem143;

internal static class Program
{
    const int Limit = 120000;

    static int Gcd(int a, int b)
    {
        while (b != 0) { int t = b; b = a % b; a = t; }
        return a;
    }

    static bool _initialized;
    // Adjacency: for each value v, the list of values u where (v,u) is a valid pair
    static List<int>[]? _adj;
    // Hash set of pairs for O(1) lookup
    static HashSet<long>? _pairSet;

    static void Init()
    {
        _adj = new List<int>[Limit + 1];
        for (int i = 0; i <= Limit; i++) _adj[i] = new List<int>();
        _pairSet = new HashSet<long>();

        for (int m = 2; m <= 500; m++)
        {
            for (int n = 1; n < m; n++)
            {
                if (Gcd(m, n) != 1) continue;
                if ((m - n) % 3 == 0) continue;

                int x = m * m - n * n;
                int y = 2 * m * n + n * n;

                for (int k = 1; ; k++)
                {
                    int kx = k * x, ky = k * y;
                    if (kx + ky > Limit) break;

                    long key1 = (long)kx * 131072 + ky;
                    long key2 = (long)ky * 131072 + kx;

                    if (_pairSet.Add(key1))
                    {
                        _adj[kx].Add(ky);
                    }
                    if (kx != ky && _pairSet.Add(key2))
                    {
                        _adj[ky].Add(kx);
                    }
                }
            }
        }
    }

    static long Solve()
    {
        if (!_initialized) { Init(); _initialized = true; }

        bool[] seen = new bool[Limit + 1];
        long total = 0;

        for (int p = 1; p <= Limit; p++)
        {
            if (_adj![p].Count == 0) continue;

            foreach (int q in _adj[p])
            {
                if (q <= p) continue;
                int maxR = Limit - p - q;
                if (maxR < 1) continue;

                foreach (int r in _adj[q])
                {
                    if (r > maxR) continue;
                    long key = (long)p * 131072 + r;
                    if (_pairSet!.Contains(key))
                    {
                        int s = p + q + r;
                        if (!seen[s])
                        {
                            seen[s] = true;
                            total += s;
                        }
                    }
                }
            }
        }

        return total;
    }

    static void Main() => Bench.Run(143, Solve);
}
