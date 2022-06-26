using System.Diagnostics;

// Problem9
// Special Pythagorean triplet
// A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
//
// a2 + b2 = c2
// For example, 32 + 42 = 9 + 16 = 25 = 52.
//
//     There exists exactly one Pythagorean triplet for which a + b + c = 1000.
//     Find the product abc.

namespace Problem9
{
    class Program
    {
        private static void Main()
        {
            var timeTaken = Stopwatch.StartNew();
            // a < b < c
            // a^2 + b^2 = c^2
            // a + b + c = 1000

            for (int a = 1; a < 998; a++)
            {
                for (int b = a + 1; b < 999; b++)
                {
                    for (int c = b + 1; c < 1000; c++)
                    {
                        if (a + b + c == 1000)
                        {
                            if (a * a + b * b == c * c)
                            {
                                Console.WriteLine($"a={a}, b={b}, c={c}, a+b+c={a+b+c}, abc={a * b * c}, in {timeTaken.ElapsedMilliseconds} ms.");
                                return;
                            }
                        }
                    }
                }
            }

        }
    }
}