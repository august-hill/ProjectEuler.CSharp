using System.Diagnostics;

// Problem9
// Special Pythagorean triplet
// A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
//
// a^2 + b^2 = c^2
// For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.
//
//     There exists exactly one Pythagorean triplet for which a + b + c = 1000.
//     Find the product abc.

namespace Problem9
{
    internal static class Program
    {
        private static void Main()
        {
            var timeTaken = Stopwatch.StartNew();

            for (int a = 1; a < 998; a++)
            {
                for (int b = a + 1; b < 999; b++)
                {
                    int c = 1000 - a - b;

                    if (c <= 0 || a * a + b * b != c * c) continue;
                    Console.WriteLine($"a={a}, b={b}, c={c}, a+b+c={a+b+c}, abc={a * b * c}, in {timeTaken.ElapsedTicks} ticks.");
                    return;
                }
            }
        }
    }
}