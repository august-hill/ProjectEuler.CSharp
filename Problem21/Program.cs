using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem21
{
    class Program
    {
        /// <summary>
        /// Divisors (proper)
        /// </summary>
        /// <param name="n"></param>
        /// <returns>Sum of Proper Divisors</returns>
        static long Dp(long n)
        {
            long sum = 0;

            for (long i = 1; i < n; i++)
            {
                if (n % i == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }

        static void Main(string[] args)
        {
            SortedSet<long> amicable = new SortedSet<long>();

            for (long a = 1; a <= 10000; a++)
            {
                long b = Dp(a);
                if (Dp(b) == a)
                {
                    if (a != b)
                    {
                        Console.WriteLine("{0} {1}", a, b);
                        amicable.Add(a);
                        amicable.Add(b);
                    }
                }
            }

            Console.WriteLine("sum of all the amicable numbers under 10000: {0}",amicable.Sum());
        }
    }
}
