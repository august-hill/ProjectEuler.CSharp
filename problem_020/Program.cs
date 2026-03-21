// Answer: 648
using System.Numerics;

namespace Problem20;

internal static class Program
{
    static BigInteger Factorial(BigInteger n)
    {
        if (n == 1) return 1;
        return n * Factorial(n - 1);
    }

    static BigInteger SumDigits(BigInteger n)
    {
        BigInteger result = 0;
        while (n != 0)
        {
            result += n % 10;
            n /= 10;
        }
        return result;
    }

    static long Solve()
    {
        BigInteger f = Factorial(100);
        return (long)SumDigits(f);
    }

    static void Main() => Bench.Run(20, Solve);
}
