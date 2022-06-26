using System.Diagnostics;

// Problem6
// Sum square difference
// The sum of the squares of the first ten natural numbers is,
//
// The square of the sum of the first ten natural numbers is,
//
// Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is .
//
// Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.


namespace Problem6
{
    class Program
    {
        private static void Main()
        {
            var timeTaken = Stopwatch.StartNew();
            
            const int n = 100;
            const int sumOfSquares = n * (n + 1) * (2 * n + 1) / 6;
            const int squareOfSums = (n * (n + 1) / 2) * (n * (n + 1) / 2);

            timeTaken.Stop();
            Console.WriteLine("For the first {0} natural numbers...", n);
            Console.WriteLine("Sum of squares is: {0}", sumOfSquares);
            Console.WriteLine("Square of sums is: {0}", squareOfSums);
            Console.WriteLine("The difference is: {0}", Math.Abs(sumOfSquares - squareOfSums));
            Console.WriteLine($"Time spent: {timeTaken.ElapsedTicks} ticks.");
        }
    }
}