// Answer: 142989277
using System;

namespace Problem171;

internal static class Program
{
    const long Mod = 1000000000L;
    const int MaxSS = 1621;

    static bool IsPerfectSquare(int n)
    {
        if (n < 0) return false;
        int s = (int)Math.Sqrt(n);
        while (s * s > n) s--;
        while ((s + 1) * (s + 1) <= n) s++;
        return s * s == n;
    }

    static long Solve()
    {
        long total = 0;

        for (int L = 1; L <= 20; L++)
        {
            long[] cntDp = new long[MaxSS];
            long[] valDp = new long[MaxSS];

            for (int d = 1; d <= 9; d++)
            {
                cntDp[d * d] = (cntDp[d * d] + 1) % Mod;
                valDp[d * d] = (valDp[d * d] + d) % Mod;
            }

            for (int pos = 1; pos < L; pos++)
            {
                long[] newCnt = new long[MaxSS];
                long[] newVal = new long[MaxSS];

                for (int ss = 0; ss < MaxSS; ss++)
                {
                    if (cntDp[ss] == 0) continue;
                    long c = cntDp[ss];
                    long v = valDp[ss];

                    for (int d = 0; d <= 9; d++)
                    {
                        int nss = ss + d * d;
                        if (nss >= MaxSS) continue;
                        newCnt[nss] = (newCnt[nss] + c) % Mod;
                        newVal[nss] = (newVal[nss] + v * 10 + c * d) % Mod;
                    }
                }

                cntDp = newCnt;
                valDp = newVal;
            }

            for (int ss = 0; ss < MaxSS; ss++)
            {
                if (cntDp[ss] > 0 && IsPerfectSquare(ss))
                    total = (total + valDp[ss]) % Mod;
            }
        }

        return total;
    }

    static void Main() => Bench.Run(171, Solve);
}
