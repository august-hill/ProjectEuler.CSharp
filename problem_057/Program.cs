// Answer: 153
using System.Numerics;

namespace Problem57;

internal static class Program
{
    static long Solve()
    {
        int count = 0;
        BigInteger n = 1; // numerator
        BigInteger d = 1; // denominator

        for (int i = 0; i < 1000; i++)
        {
            // Next expansion: n' = n + 2d, d' = n + d
            BigInteger newN = n + 2 * d;
            BigInteger newD = n + d;
            n = newN;
            d = newD;

            if (n.ToString().Length > d.ToString().Length)
                count++;
        }
        return count;
    }

    static void Main() => Bench.Run(57, Solve);
}
