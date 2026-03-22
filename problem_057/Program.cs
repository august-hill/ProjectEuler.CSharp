// Answer: 153
using System.Numerics;

namespace Problem57;

internal static class Program
{
    private static int DigitCount(BigInteger n)
    {
        if (n.IsZero) return 1;
        // GetByteCount gives raw size; use log10 for digit count
        return (int)BigInteger.Log10(n) + 1;
    }

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

            if (DigitCount(n) > DigitCount(d))
                count++;
        }
        return count;
    }

    static void Main() => Bench.Run(57, Solve);
}
