using System;
using System.Diagnostics;

//  Multiples of 3 and 5
//  Problem 1
//
//  If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
//
//  Find the sum of all the multiples of 3 or 5 below 1000.


namespace Problem1;

internal static class Program
{
    private static void Main()
    {
        const int upperLimit = 1000;
        var timeTaken = new Stopwatch();

        // Approach 1: Brute-force loop O(n)
        timeTaken.Start();
        var sumBruteForce = 0;
        for (var i = 1; i < upperLimit; i++)
            if (i % 3 == 0 || i % 5 == 0)
                sumBruteForce += i;
        timeTaken.Stop();
        Console.WriteLine($"Brute-force: {sumBruteForce} in {timeTaken.ElapsedTicks} ticks");

        // Approach 2: Closed-form formula O(1)
        timeTaken.Restart();
        var sumFormula = CalculateSumFormula(upperLimit);
        timeTaken.Stop();
        Console.WriteLine($"Formula:     {sumFormula} in {timeTaken.ElapsedTicks} ticks");
    }

    /// <summary>
    /// O(1) solution using inclusion-exclusion principle.
    /// Sum of multiples of k below n = k * (n/k) * (n/k + 1) / 2
    /// </summary>
    private static long CalculateSumFormula(long upperLimit)
    {
        upperLimit--; // exclude the upper limit itself
        long sumOfThrees = 3 * (upperLimit / 3 * (upperLimit / 3 + 1)) / 2;
        long sumOfFives = 5 * (upperLimit / 5 * (upperLimit / 5 + 1)) / 2;
        long sumOfFifteens = 15 * (upperLimit / 15 * (upperLimit / 15 + 1)) / 2;

        return sumOfThrees + sumOfFives - sumOfFifteens;
    }
}
