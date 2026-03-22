// Answer: 3857447
using System;
using System.Collections.Generic;

namespace Problem155;

internal static class Program
{
    const int MaxN = 19;

    static long GcdLL(long a, long b)
    {
        if (a < 0) a = -a;
        if (b < 0) b = -b;
        while (b != 0) { long t = b; b = a % b; a = t; }
        return a;
    }

    static (long p, long q) MakeFrac(long p, long q)
    {
        long g = GcdLL(p, q);
        return (p / g, q / g);
    }

    static bool _initialized;
    static long _result;

    static long Solve()
    {
        if (_initialized) return _result;
        _initialized = true;

        // Hash set for all distinct fractions
        var allFracs = new HashSet<(long, long)>();

        // Level fracs: new fractions added at each level
        var levelFracs = new List<(long p, long q)>[MaxN];
        for (int i = 1; i < MaxN; i++)
            levelFracs[i] = new List<(long, long)>();

        levelFracs[1].Add((1, 1));
        allFracs.Add((1, 1));

        for (int n = 2; n <= 18; n++)
        {
            for (int k = 1; k <= n / 2; k++)
            {
                int j = n - k;
                var lk = levelFracs[k];
                var lj = levelFracs[j];
                for (int a = 0; a < lk.Count; a++)
                {
                    var (ap, aq) = lk[a];
                    int bStart = (k == j) ? a : 0;
                    for (int b = bStart; b < lj.Count; b++)
                    {
                        var (bp, bq) = lj[b];

                        // Parallel: ap/aq + bp/bq
                        long pp = ap * bq + bp * aq;
                        long pq = aq * bq;
                        long g = GcdLL(pp, pq);
                        pp /= g; pq /= g;
                        if (allFracs.Add((pp, pq)))
                            levelFracs[n].Add((pp, pq));

                        // Series: (ap/aq * bp/bq) / (ap/aq + bp/bq) = ap*bp / (ap*bq + bp*aq)
                        long sp = ap * bp;
                        long sq = ap * bq + bp * aq;
                        g = GcdLL(sp, sq);
                        sp /= g; sq /= g;
                        if (allFracs.Add((sp, sq)))
                            levelFracs[n].Add((sp, sq));
                    }
                }
            }
        }

        _result = allFracs.Count;
        return _result;
    }

    static void Main() => Bench.Run(155, Solve);
}
