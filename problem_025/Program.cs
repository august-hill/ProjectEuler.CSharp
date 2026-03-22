// Answer: 4782
using System.Numerics;

namespace Problem25;

internal static class Program
{
    static long Solve()
    {
        // Use BigInteger.Log10 to check digit count instead of converting to string
        BigInteger a = 1;
        BigInteger b = 1;
        long term = 2;

        while (true)
        {
            BigInteger next = a + b;
            a = b;
            b = next;
            term++;
            // A number has 1000 digits when log10 >= 999
            if (BigInteger.Log10(b) >= 999)
                return term;
        }
    }

    static void Main() => Bench.Run(25, Solve);
}
