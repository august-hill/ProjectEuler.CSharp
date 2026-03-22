// Answer: 3916160068885
using System;

namespace Problem167;

internal static class Program
{
    const long Target = 100000000000L;

    static long UlamNth(int b, long n)
    {
        int maxTerms = b >= 15 ? 1000000 : 500000;
        long[] seq = new long[maxTerms];
        long[] diffs = new long[maxTerms];
        seq[0] = 2; seq[1] = b;
        int count = 2;

        long maxVal = (long)maxTerms * (b + 2);
        if (maxVal < 500000) maxVal = 500000;
        long arrBytes = maxVal / 4 + 2;
        byte[] cnt = new byte[arrBytes];

        // Mark sum of first two: 2+b
        CntInc(cnt, 2 + b);

        int ndiffs = 0;
        int period = -1;
        int periodDstart = -1;

        while (count < maxTerms)
        {
            long prev = seq[count - 1];

            if (prev * 2 + b + 1000 >= maxVal)
            {
                long nmax = maxVal + (long)maxTerms * b + 1000000;
                long narr = nmax / 4 + 2;
                var nc = new byte[narr];
                Array.Copy(cnt, nc, (int)Math.Min(arrBytes, narr));
                cnt = nc;
                arrBytes = narr;
                maxVal = nmax;
            }

            long nextVal = -1;
            for (long v = prev + 1; v <= maxVal; v++)
                if (CntGet(cnt, v) == 1) { nextVal = v; break; }
            if (nextVal == -1) break;

            seq[count] = nextVal;
            diffs[ndiffs++] = nextVal - prev;

            for (int i = 0; i < count; i++)
            {
                long sum = seq[i] + nextVal;
                if (sum < maxVal) CntInc(cnt, sum);
            }
            count++;

            if (period == -1 && ndiffs >= 2000 && ndiffs % 1000 == 0)
            {
                for (int P = 1; P <= ndiffs / 25; P++)
                {
                    if (25 * P > ndiffs) break;
                    bool match = true;
                    for (int kk = 0; kk < 20 * P; kk++)
                    {
                        if (diffs[ndiffs - 1 - kk] != diffs[ndiffs - 1 - kk - P]) { match = false; break; }
                    }
                    if (match)
                    {
                        period = P;
                        periodDstart = 0;
                        for (int i = ndiffs - 2 * P - 1; i >= 1; i--)
                        {
                            if (diffs[i] != diffs[i + P]) { periodDstart = i + 1; break; }
                        }
                        goto Found;
                    }
                }
            }
        }
        Found:

        if (period == -1)
            return (n <= (long)count) ? seq[n - 1] : -1;

        long ps = 0;
        for (int i = 0; i < period; i++) ps += diffs[periodDstart + i];
        long s01 = (long)periodDstart + 2;
        long s0v = seq[periodDstart + 1];

        if (n < s01) return seq[n - 1];

        long off = n - s01;
        long fp = off / period;
        long rem = off % period;
        long bv = s0v;
        for (long kk = 0; kk < rem; kk++) bv += diffs[periodDstart + kk];
        return bv + fp * ps;
    }

    static int CntGet(byte[] a, long i) => (a[i >> 2] >> (int)((i & 3) << 1)) & 3;

    static void CntInc(byte[] a, long i)
    {
        int shift = (int)((i & 3) << 1);
        int v = (a[i >> 2] >> shift) & 3;
        if (v < 2) a[i >> 2] = (byte)((a[i >> 2] & ~(3 << shift)) | ((v + 1) << shift));
    }

    static bool _initialized;
    static long _answerCache;

    static long Solve()
    {
        if (_initialized) return _answerCache;
        _initialized = true;

        long total = 0;
        for (int k = 5; k <= 21; k += 2)
            total += UlamNth(k, Target);

        _answerCache = total;
        return _answerCache;
    }

    static void Main() => Bench.Run(167, Solve);
}
