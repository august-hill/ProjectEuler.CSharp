// Answer: 83735848679360680
using System;

namespace Problem181;

internal static class Program
{
    const int B = 60;
    const int W = 40;

    static long Solve()
    {
        long[,] dp = new long[B + 1, W + 1];
        dp[B, W] = 1;

        for (int b = 0; b <= B; b++)
        {
            for (int w = 0; w <= W; w++)
            {
                if (b == 0 && w == 0) continue;

                long[,] ndp = new long[B + 1, W + 1];

                for (int rb = 0; rb <= B; rb++)
                {
                    for (int rw = 0; rw <= W; rw++)
                    {
                        if (dp[rb, rw] == 0) continue;
                        for (int k = 0; ; k++)
                        {
                            int nb = rb - k * b;
                            int nw = rw - k * w;
                            if (nb < 0 || nw < 0) break;
                            ndp[nb, nw] += dp[rb, rw];
                        }
                    }
                }

                Array.Copy(ndp, dp, dp.Length);
            }
        }

        return dp[0, 0];
    }

    static void Main() => Bench.Run(181, Solve);
}
