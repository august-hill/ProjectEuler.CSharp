// Answer: 137846528640
using System.Numerics;

namespace Problem15;

internal static class Program
{
    private static BigInteger Factorial(BigInteger n)
    {
        if (n == 0) return 1;
        return n * Factorial(n - 1);
    }

    private static BigInteger Combination(BigInteger i, BigInteger j)
    {
        return Factorial(i) / (Factorial(j) * Factorial(j));
    }

    static long Solve()
    {
        BigInteger cubeSize = 20;
        var pathLength = cubeSize + cubeSize;
        var routes = Combination(pathLength, cubeSize);
        return (long)routes;
    }

    static void Main() => Bench.Run(15, Solve);
}
