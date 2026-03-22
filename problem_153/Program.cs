// Answer: 17971254122360635
using System;

namespace Problem153;

internal static class Program
{
    const long N = 100000000L;

    static long SDiv(long m)
    {
        if (m <= 0) return 0;
        long result = 0;
        long k = 1;
        while (k <= m)
        {
            long q = m / k;
            long kMax = m / q;
            long sumK = (kMax - k + 1) * (k + kMax) / 2;
            result += q * sumK;
            k = kMax + 1;
        }
        return result;
    }

    static long GcdLL(long a, long b)
    {
        while (b != 0) { long t = b; b = a % b; a = t; }
        return a;
    }

    static long Solve()
    {
        long realSum = SDiv(N);
        long gaussSum = 0;
        for (long a = 1; a * a + 1 <= N; a++)
        {
            for (long b = 1; a * a + b * b <= N; b++)
            {
                if (GcdLL(a, b) != 1) continue;
                long p = a * a + b * b;
                long m = N / p;
                gaussSum += 2L * a * SDiv(m);
            }
        }
        return realSum + gaussSum;
    }

    static void Main() => Bench.Run(153, Solve);
}
