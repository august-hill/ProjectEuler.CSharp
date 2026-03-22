// Answer: 96818198400000
using System;

namespace Problem176;

internal static class Program
{
    static readonly int[] SmallPrimes = {3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43};

    static double _bestLog;
    static int[] _bestExps = Array.Empty<int>();
    static int _bestNexp;
    static int _bestA;

    static double ComputeLog(int a, int[] exps, int ne)
    {
        double v = a * Math.Log(2.0);
        for (int i = 0; i < ne; i++)
            v += exps[i] * Math.Log(SmallPrimes[i]);
        return v;
    }

    static void FindFactorizations(int n, int minVal, int[] factors, int nf, int a)
    {
        if (n >= minVal && n % 2 == 1)
        {
            factors[nf] = n;
            int total = nf + 1;
            int[] exps = new int[total];
            for (int i = 0; i < total; i++) exps[i] = (factors[i] - 1) / 2;
            Array.Sort(exps, (x, y) => y - x); // descending
            double v = ComputeLog(a, exps, total);
            if (v < _bestLog)
            {
                _bestLog = v;
                _bestA = a;
                _bestNexp = total;
                _bestExps = (int[])exps.Clone();
            }
        }

        for (int f = minVal; (long)f * f <= n; f++)
        {
            if (f % 2 == 0) continue;
            if (n % f == 0)
            {
                factors[nf] = f;
                FindFactorizations(n / f, f, factors, nf + 1, a);
            }
        }
    }

    static long Solve()
    {
        _bestLog = 1e30;
        int[] factors = new int[20];

        FindFactorizations(95095, 3, factors, 0, 0);

        int[] divs = new int[100];
        int nd = 0;
        for (int d = 1; (long)d * d <= 95095; d++)
        {
            if (95095 % d == 0)
            {
                divs[nd++] = d;
                if (d != 95095 / d) divs[nd++] = 95095 / d;
            }
        }

        for (int i = 0; i < nd; i++)
        {
            int d = divs[i];
            if (d % 2 == 0) continue;
            int a = (d + 1) / 2;
            if (a < 1) continue;
            int remaining = 95095 / d;
            if (remaining == 1)
            {
                double v = a * Math.Log(2.0);
                if (v < _bestLog) { _bestLog = v; _bestA = a; _bestNexp = 0; _bestExps = Array.Empty<int>(); }
            }
            else
            {
                FindFactorizations(remaining, 3, factors, 0, a);
            }
        }

        long result = 1;
        for (int i = 0; i < _bestA; i++) result *= 2;
        for (int i = 0; i < _bestNexp; i++)
        {
            long bbase = SmallPrimes[i];
            for (int j = 0; j < _bestExps[i]; j++) result *= bbase;
        }
        return result;
    }

    static void Main() => Bench.Run(176, Solve);
}
