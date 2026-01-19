using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// A number chain is created by continuously adding the square of the digits in a number to form
// a new number until it has been seen before.
//
// For example,
//
// 44 → 32 → 13 → 10 → 1 → 1
// 85 → 89 → 145 → 42 → 20 → 4 → 16 → 37 → 58 → 89
//
// Therefore any chain that arrives at 1 or 89 will become stuck in an endless loop.
// What is most amazing is that EVERY starting number will eventually arrive at 1 or 89.
//
// How many starting numbers below ten million will arrive at 89?
//

namespace Problem92
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();

            int count = 0;

            for (int i = 1; i < 10000000; i++)
            {
                if (NumberChain(i) == 89)
                {
                    count++;
                }
            }

            long ms = stopWatch.ElapsedMilliseconds;
            Console.WriteLine("Count of starting numbers is {0}", count);
            Console.WriteLine("RunTime: {0} ms.", ms);
        }

        private static int NumberChain(int i)
        {
            int n = i;
            while (n != 1 && n != 89)
            {
                n = SquareOfDigits(n);
            }
            return n;
        }

        private static int SquareOfDigits(int j)
        {
            int result = 0;

            foreach (var digit in j.ToString())
            {
                int value = digit - '0';
                result += value * value;
            }

            return result;
        }
    }
}
