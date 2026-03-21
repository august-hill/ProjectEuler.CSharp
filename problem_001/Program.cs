// Answer: 233168
using System;

namespace Problem1;

internal static class Program
{
    private static long CalculateSumFormula(long upperLimit)
    {
        upperLimit--;
        long sumOfThrees = 3 * (upperLimit / 3 * (upperLimit / 3 + 1)) / 2;
        long sumOfFives = 5 * (upperLimit / 5 * (upperLimit / 5 + 1)) / 2;
        long sumOfFifteens = 15 * (upperLimit / 15 * (upperLimit / 15 + 1)) / 2;
        return sumOfThrees + sumOfFives - sumOfFifteens;
    }

    static long Solve()
    {
        return CalculateSumFormula(1000);
    }

    static void Main() => Bench.Run(1, Solve);
}
