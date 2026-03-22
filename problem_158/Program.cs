// Answer: 409511334375
using System;

namespace Problem158;

internal static class Program
{
    static long Solve()
    {
        long best = 0;
        long comb = 1;
        for (int n = 1; n <= 26; n++)
        {
            comb = comb * (26 - n + 1) / n;
            long pow2 = 1L << n;
            long euler = pow2 - n - 1;
            long pn = comb * euler;
            if (pn > best) best = pn;
        }
        return best;
    }

    static void Main() => Bench.Run(158, Solve);
}
