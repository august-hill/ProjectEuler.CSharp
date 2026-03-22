// Answer: 2868868
using System;
using System.Collections.Generic;

namespace Problem165;

internal static class Program
{
    struct IPoint : IEquatable<IPoint>
    {
        public long Px, Py, Pq;
        public bool Equals(IPoint other) => Px == other.Px && Py == other.Py && Pq == other.Pq;
        public override bool Equals(object? obj) => obj is IPoint ip && Equals(ip);
        public override int GetHashCode() => HashCode.Combine(Px, Py, Pq);
    }

    static long GcdLL(long a, long b)
    {
        if (a < 0) a = -a;
        if (b < 0) b = -b;
        while (b != 0) { long t = b; b = a % b; a = t; }
        return a;
    }

    static bool _initialized;
    static long _answerCache;

    static long Solve()
    {
        if (_initialized) return _answerCache;
        _initialized = true;

        const int NSeg = 5000;
        long[,] seg = new long[NSeg * 2, 2]; // seg[i*2+end, xy]

        long s = 290797;
        long[] t = new long[4 * NSeg];
        for (int i = 0; i < 4 * NSeg; i++)
        {
            s = (s * s) % 50515093L;
            t[i] = s % 500;
        }
        for (int i = 0; i < NSeg; i++)
        {
            seg[i * 2, 0] = t[4 * i];
            seg[i * 2, 1] = t[4 * i + 1];
            seg[i * 2 + 1, 0] = t[4 * i + 2];
            seg[i * 2 + 1, 1] = t[4 * i + 3];
        }

        var ipoints = new List<IPoint>(1 << 20);

        for (int i = 0; i < NSeg; i++)
        {
            long ax = seg[i * 2, 0], ay = seg[i * 2, 1];
            long bx = seg[i * 2 + 1, 0], by = seg[i * 2 + 1, 1];
            long dx = bx - ax, dy = by - ay;

            for (int j = i + 1; j < NSeg; j++)
            {
                long cx = seg[j * 2, 0], cy = seg[j * 2, 1];
                long ex = seg[j * 2 + 1, 0], ey = seg[j * 2 + 1, 1];
                long fx = ex - cx, fy = ey - cy;

                long denom = dx * fy - dy * fx;
                if (denom == 0) continue;

                long tNum = (cx - ax) * fy - (cy - ay) * fx;
                long uNum = (cx - ax) * dy - (cy - ay) * dx;

                if (denom > 0)
                {
                    if (tNum <= 0 || tNum >= denom) continue;
                    if (uNum <= 0 || uNum >= denom) continue;
                }
                else
                {
                    if (tNum >= 0 || tNum <= denom) continue;
                    if (uNum >= 0 || uNum <= denom) continue;
                }

                long px = ax * denom + tNum * dx;
                long py = ay * denom + tNum * dy;
                long pq = denom;

                if (pq < 0) { px = -px; py = -py; pq = -pq; }
                long g = GcdLL(GcdLL(px < 0 ? -px : px, py < 0 ? -py : py), pq);
                if (g > 0) { px /= g; py /= g; pq /= g; }

                ipoints.Add(new IPoint { Px = px, Py = py, Pq = pq });
            }
        }

        ipoints.Sort((a, b) =>
        {
            if (a.Pq != b.Pq) return a.Pq < b.Pq ? -1 : 1;
            if (a.Px != b.Px) return a.Px < b.Px ? -1 : 1;
            if (a.Py != b.Py) return a.Py < b.Py ? -1 : 1;
            return 0;
        });

        long count = 0;
        for (int i = 0; i < ipoints.Count;)
        {
            int j = i + 1;
            while (j < ipoints.Count && ipoints[i].Equals(ipoints[j])) j++;
            count++;
            i = j;
        }

        _answerCache = count;
        return _answerCache;
    }

    static void Main() => Bench.Run(165, Solve);
}
