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
        var timeTaken = new Stopwatch();
        const int upperLimit = 1000;
        var sum = 0;

        timeTaken.Start();
        for (var i = 1; i < upperLimit; i++)
            if (i % 3 == 0 || i % 5 == 0)
                sum += i;
        timeTaken.Stop();

        Console.WriteLine($"The sum is {sum}, in {timeTaken.ElapsedTicks} ticks.");
    }
}