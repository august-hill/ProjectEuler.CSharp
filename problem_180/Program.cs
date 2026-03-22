// Answer: 285196020571078987
using System;
using System.Collections.Generic;

namespace Problem180;

internal static class Program
{
    const int K = 35;

    static long GcdLL(long a, long b)
    {
        if (a < 0) a = -a;
        if (b < 0) b = -b;
        while (b != 0) { long t = b; b = a % b; a = t; }
        return a;
    }

    static (long n, long d) MkRat(long n, long d)
    {
        if (d < 0) { n = -n; d = -d; }
        if (n == 0) return (0, 1);
        long g = GcdLL(n < 0 ? -n : n, d);
        return (n / g, d / g);
    }

    static (long n, long d) Radd((long n, long d) a, (long n, long d) b)
        => MkRat(a.n * b.d + b.n * a.d, a.d * b.d);

    static bool RValid((long n, long d) r) => r.n > 0 && r.d > 0 && r.n < r.d && r.d <= K;

    static long Solve()
    {
        var ht = new HashSet<(long, long)>();

        var rats = new List<(long n, long d)>();
        for (int q = 2; q <= K; q++)
            for (int p = 1; p < q; p++)
                if (GcdLL(p, q) == 1)
                    rats.Add(MkRat(p, q));

        (long n, long d) total = (0, 1);

        void TryAdd((long n, long d) z, (long n, long d) x, (long n, long d) y)
        {
            if (!RValid(z)) return;
            var s = Radd(Radd(x, y), z);
            if (ht.Add((s.n, s.d))) total = Radd(total, s);
        }

        for (int i = 0; i < rats.Count; i++)
        {
            for (int j = i; j < rats.Count; j++)
            {
                var x = rats[i]; var y = rats[j];

                // n=1: z = x+y
                TryAdd(Radd(x, y), x, y);

                // n=-1: z = xy/(x+y)
                {
                    long zn = x.n * y.n;
                    long zd = x.n * y.d + y.n * x.d;
                    if (zd > 0 && zn > 0) TryAdd(MkRat(zn, zd), x, y);
                }

                // n=2: z = sqrt(x^2+y^2)
                {
                    long num2 = x.n * x.n * y.d * y.d + y.n * y.n * x.d * x.d;
                    long den1 = x.d * y.d;
                    long sq = (long)Math.Sqrt(num2);
                    while (sq * sq < num2) sq++;
                    while (sq * sq > num2) sq--;
                    if (sq > 0 && sq * sq == num2) TryAdd(MkRat(sq, den1), x, y);
                }

                // n=-2: z = xy/sqrt(x^2+y^2)
                {
                    long num2 = x.n * x.n * y.d * y.d + y.n * y.n * x.d * x.d;
                    long sq = (long)Math.Sqrt(num2);
                    while (sq * sq < num2) sq++;
                    while (sq * sq > num2) sq--;
                    if (sq > 0 && sq * sq == num2) TryAdd(MkRat(x.n * y.n, sq), x, y);
                }

                if (i != j)
                {
                    for (int ord = 0; ord < 2; ord++)
                    {
                        var big = (ord == 0) ? y : x;
                        var small = (ord == 0) ? x : y;
                        if (big.n * small.d <= small.n * big.d) continue;

                        // n=1 diff
                        TryAdd(MkRat(big.n * small.d - small.n * big.d, big.d * small.d), big, small);

                        // n=2 diff
                        {
                            long num2 = big.n * big.n * small.d * small.d - small.n * small.n * big.d * big.d;
                            if (num2 > 0)
                            {
                                long den1 = big.d * small.d;
                                long sq = (long)Math.Sqrt(num2);
                                while (sq * sq < num2) sq++;
                                while (sq * sq > num2) sq--;
                                if (sq > 0 && sq * sq == num2) TryAdd(MkRat(sq, den1), big, small);
                            }
                        }

                        // n=-1 diff
                        {
                            long zn = big.n * small.n;
                            long zd = big.n * small.d - small.n * big.d;
                            if (zd > 0 && zn > 0) TryAdd(MkRat(zn, zd), big, small);
                        }

                        // n=-2 diff
                        {
                            long num2 = big.n * big.n * small.d * small.d - small.n * small.n * big.d * big.d;
                            if (num2 > 0)
                            {
                                long sq = (long)Math.Sqrt(num2);
                                while (sq * sq < num2) sq++;
                                while (sq * sq > num2) sq--;
                                if (sq > 0 && sq * sq == num2) TryAdd(MkRat(big.n * small.n, sq), big, small);
                            }
                        }
                    }
                }
            }
        }

        return total.n + total.d;
    }

    static void Main() => Bench.Run(180, Solve);
}
