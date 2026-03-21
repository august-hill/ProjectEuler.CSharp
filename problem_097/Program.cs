// Answer: 8739992577
using System.Numerics;

namespace Problem97;

internal static class Program
{
    static long Solve()
    {
        BigInteger answer = 28433 * BigInteger.Pow(2, 7830457) + 1;
        BigInteger result;
        BigInteger.DivRem(answer, 10000000000, out result);
        return (long)result;
    }

    static void Main() => Bench.Run(97, Solve);
}
