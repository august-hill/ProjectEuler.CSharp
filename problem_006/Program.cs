// Answer: 25164150
using System;

namespace Problem6;

internal static class Program
{
    static long Solve()
    {
        const int n = 100;
        const int sumOfSquares = n * (n + 1) * (2 * n + 1) / 6;
        const int squareOfSums = (n * (n + 1) / 2) * (n * (n + 1) / 2);
        return Math.Abs(sumOfSquares - squareOfSums);
    }

    static void Main() => Bench.Run(6, Solve);
}
