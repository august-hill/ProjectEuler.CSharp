using System.Collections;
using System.Diagnostics;

namespace Problem41
{
    class Program
    {
        static bool IsPandigital(int i)
        {
            var flags = new BitArray(10)
            {
                [0] = true
            };

            int k = 1;
            while (i != 0)
            {
                int digit = i % 10;
                if (flags[digit])
                {
                    return false;
                }
                flags[digit] = true;
                i = i / 10;
                ++k;
            }

            for (int j = 1; j < k; ++j)
            {
                if (!flags[j])
                {
                    return false;
                }
            }

            return true;
        }

        private static void Main()
        {
            var timeTaken = Stopwatch.StartNew();
            // Note: Nine numbers cannot be done (1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 = 45 = > always dividable by 3)
            // Note: Eight numbers cannot be done (1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 = 36 = > always dividable by 3)

            const int pandigitalMax = 7654321;
            var p = new Primes(pandigitalMax);
            var primes = p.GetPrimeList();

            int result = 0;
            foreach(var prime in primes)
            {
                if (IsPandigital(prime) && prime > result)
                {
                    result = prime;
                }

            }


            timeTaken.Stop();
            Console.WriteLine($"largest pandigital is {result} in {timeTaken.ElapsedMilliseconds} ms.");
        }
    }
}