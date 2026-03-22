// Answer: 59206
using System;

namespace Problem168;

internal static class Program
{
    static long Solve()
    {
        const long Mod = 100000L;
        long total = 0;

        for (int k = 1; k <= 9; k++)
        {
            int D = 10 * k - 1;
            for (int a0 = k; a0 <= 9; a0++)
            {
                int g = D, tmpG = a0;
                while (tmpG != 0) { int tt = tmpG; tmpG = g % tmpG; g = tt; }
                int Dp = D / g;

                int ord = 0;
                {
                    long pw = 1;
                    for (int e = 1; e <= 10000; e++)
                    {
                        pw = pw * 10 % Dp;
                        if (pw == 1 % Dp || Dp == 1) { ord = e; break; }
                    }
                    if (ord == 0) ord = Dp;
                }

                long bigMod = (long)D * Mod;
                long p10 = 10 % (Dp == 0 ? 1 : Dp);
                long p10Full = 10 % bigMod;

                for (int d = 1; d <= 100; d++)
                {
                    if (d >= 2)
                    {
                        if (Dp == 1 || p10 == 1 % Dp)
                        {
                            long pdMinus1 = (p10Full - 1 + bigMod) % bigMod;
                            long num = ((long)a0 * pdMinus1) % bigMod;
                            long nMod = (num / D) % Mod;
                            total = (total + nMod) % Mod;
                        }
                    }
                    p10 = Dp <= 1 ? 0 : p10 * 10 % Dp;
                    p10Full = p10Full * 10 % bigMod;
                }
            }
        }
        return total;
    }

    static void Main() => Bench.Run(168, Solve);
}
