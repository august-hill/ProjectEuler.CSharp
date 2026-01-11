using System.Diagnostics;
using System.Numerics;

namespace Problem15;

internal static class Program
{
    private static BigInteger Factorial(BigInteger n)
    {
        if (n == 0)
            return 1;
        return n * Factorial(n - 1);
    }

    private static BigInteger Combination(BigInteger i, BigInteger j)
    {
        return Factorial(i) / (Factorial(j) * Factorial(j));
    }

    private static void Main()
    {
        // 2 x 2 cube
        // 4 length  = 2 + 2
        // 4 c 2

        // 3 x 3 cube
        // 6 length  = 3 + 3
        // 6 c 3

        // 20 x 20 cube
        // 40 length  = 20 + 20
        // 40 c 20

        var stopwatch = Stopwatch.StartNew();

        for (BigInteger cubeSize = 2; cubeSize <= 20; cubeSize++)
        {
            var pathLength = cubeSize + cubeSize;
            var routes = Combination(pathLength, cubeSize);
            Console.WriteLine("cube = {0}x{0}, routes = {1}", cubeSize, routes);
            Debug.Assert(cubeSize < 20 || (cubeSize == 20 && routes == 137846528820));
        }
        
        Console.WriteLine($"{stopwatch.ElapsedTicks} ticks.");
    }
}