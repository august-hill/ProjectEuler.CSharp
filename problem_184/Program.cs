// Answer: 1725323624056
using System;
using System.Collections.Generic;

namespace Problem184;

internal static class Program
{
    const int R = 105;

    static int Quadrant(int x, int y)
    {
        if (y > 0) return (x >= 0) ? 0 : 1;
        if (y < 0) return (x <= 0) ? 2 : 3;
        return (x > 0) ? 0 : 2;
    }

    static long Solve()
    {
        long r2 = (long)R * R;

        var pts = new List<(int x, int y)>();
        for (int x = -(R - 1); x <= R - 1; x++)
            for (int y = -(R - 1); y <= R - 1; y++)
                if ((long)x * x + (long)y * y < r2 && (x != 0 || y != 0))
                    pts.Add((x, y));

        pts.Sort((a, b) =>
        {
            int qa = Quadrant(a.x, a.y), qb = Quadrant(b.x, b.y);
            if (qa != qb) return qa - qb;
            long cross = (long)a.x * b.y - (long)a.y * b.x;
            if (cross > 0) return -1;
            if (cross < 0) return 1;
            return 0;
        });

        int n = pts.Count;
        long bad = 0;
        int j = 1;
        for (int i = 0; i < n; i++)
        {
            if (j <= i) j = i + 1;
            while (j < i + n)
            {
                int jj = j % n;
                long cross = (long)pts[i].x * pts[jj].y - (long)pts[i].y * pts[jj].x;
                if (cross < 0) break;
                if (cross == 0)
                {
                    long dot = (long)pts[i].x * pts[jj].x + (long)pts[i].y * pts[jj].y;
                    if (dot <= 0) break;
                }
                j++;
            }
            long fi = j - i - 1;
            bad += fi * (fi - 1) / 2;
        }

        long totalTri = (long)n * (n - 1) * (n - 2) / 6;
        return totalTri - bad;
    }

    static void Main() => Bench.Run(184, Solve);
}
