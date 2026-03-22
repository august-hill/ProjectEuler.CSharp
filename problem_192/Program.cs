// Answer: 57060635927998347
using System;

namespace Problem192;

internal static class Program
{
    const long Bound = 1000000000000L;

    static bool IsPerfectSquare(int n)
    {
        int s = (int)Math.Sqrt(n);
        while ((long)s * s > n) s--;
        while ((long)(s + 1) * (s + 1) <= n) s++;
        return (long)s * s == n;
    }

    // Is p1/q1 closer to sqrt(n) than p2/q2?
    static bool CloserToSqrt(long p1, long q1, long p2, long q2, int n)
    {
        double sq = Math.Sqrt(n);
        double e1 = Math.Abs((double)p1 / q1 - sq);
        double e2 = Math.Abs((double)p2 / q2 - sq);
        if (e1 < e2 * (1.0 - 1e-15)) return true;
        if (e2 < e1 * (1.0 - 1e-15)) return false;
        // Exact: use Int128
        System.Int128 e1i = (System.Int128)p1 * p1 - (System.Int128)n * q1 * q1;
        if (e1i < 0) e1i = -e1i;
        System.Int128 e2i = (System.Int128)p2 * p2 - (System.Int128)n * q2 * q2;
        if (e2i < 0) e2i = -e2i;
        System.Int128 A = e1i * (System.Int128)q2 * p2 - e2i * (System.Int128)q1 * p1;
        System.Int128 B = e2i * (System.Int128)q1 * q1 - e1i * (System.Int128)q2 * q2;
        if (B > 0)
        {
            if (A <= 0) return true;
            return A * A < B * B * n;
        }
        else if (B < 0)
        {
            if (A >= 0) return false;
            System.Int128 negA = -A, negB = -B;
            return negA * negA > negB * negB * n;
        }
        return A < 0;
    }

    static long BestDenom(int n)
    {
        int a0 = (int)Math.Sqrt(n);
        while ((long)(a0 + 1) * (a0 + 1) <= n) a0++;
        while ((long)a0 * a0 > n) a0--;

        long pp = 1, pq = 0;
        long cp = a0, cq = 1;
        long m = 0, d = 1, a = a0;

        for (;;)
        {
            m = d * a - m;
            d = (n - m * m) / d;
            if (d == 0) break;
            a = (a0 + m) / d;

            long np = a * cp + pp;
            long nq = a * cq + pq;

            if (nq > Bound)
            {
                long jMax = (pq >= 0 && cq > 0) ? (Bound - pq) / cq : 0;
                if (jMax >= 1)
                {
                    long sq = jMax * cq + pq;
                    long sp = jMax * cp + pp;
                    if (CloserToSqrt(sp, sq, cp, cq, n)) return sq;
                }
                return cq;
            }

            pp = cp; pq = cq;
            cp = np; cq = nq;
        }

        return cq;
    }

    static bool _initialized;
    static long _answerCache;

    static long Solve()
    {
        if (_initialized) return _answerCache;
        _initialized = true;

        long total = 0;
        for (int n = 2; n <= 100000; n++)
        {
            if (IsPerfectSquare(n)) continue;
            total += BestDenom(n);
        }
        _answerCache = total;
        return _answerCache;
    }

    static void Main() => Bench.Run(192, Solve);
}
