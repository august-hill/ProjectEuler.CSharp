using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem27
{
    class Program
    {
        private static List<int> Primes = GeneratePrimes(1000000);


        static void Main(string[] args)
        {
#if false
            // print the lists together...

            //const int a = 1;
            //const int b = 41;
            //const int N = 40;
            const int a = -79;
            const int b = 1601;
            const int N = 80;

            for (int n = 0; n < N; n++)
            {
                int p = Quadratic(n, a, b);
                int i = Primes.FindIndex(x => x == p);
                Console.WriteLine("n = {0}, p = {1}, Primes[{2}]={3}", n, p, i, Primes[i]);
            }

            Console.WriteLine("product of coefficients = {0}", a * b);
#endif

            int max = 0;

            for (int a = -999; a < 1000; a++)
            {
                for (int b = -999; b < 1000; b++)
                {
                    int count = F(a, b);

                    if (count > max)
                    {
                        max = count;

                        Console.WriteLine("------------ {0}", count);

                        for (int n = 0; n < count; n++)
                        {
                            int p = Quadratic(n, a, b);
                            int i = Primes.FindIndex(x => x == p);
                            Console.WriteLine("  n = {0}, p = {1}, Primes[{2}]={3}", n, p, i, Primes[i]);
                        }

                        Console.WriteLine("  a = {0}, b = {1}, a * b = {2}", a, b, a * b);
                    }
                }
            }
        }


        private static int F(int a, int b)
        {
            int n = 0;

            while (true)
            {
                int p = Quadratic(n, a, b);
                if (p < 0 || Primes.BinarySearch(p) < 0)
                {
                    break;
                }
                n++;
            }

            return n;
        }

        private static int Quadratic(int n, int a, int b)
        {
            return (n * n) + (a * n) + b;
        }

        private static List<int> GeneratePrimes(int limit)
        {
            // Sieve implemented without storing even numbers...
            // Now prime p, is represented as p = 2 * i + 1, where i is seive[i].

            int sievebound = (limit - 1) / 2;   // last index of the sieve
            BitArray sieve = new BitArray(sievebound + 1, false);   // + 1 corrects for 0 based arrays
            // assume everything is prime (false)

            int crosslimit = (Convert.ToInt32(Math.Floor(Math.Sqrt(limit))) - 1) / 2;
            for (int i = 1; i <= crosslimit; i++)
            {
                if (!sieve[i])      // 2*i+1 is prime, mark multiples
                {
                    for (int j = 2 * i * (i + 1); j <= sievebound; j += 2 * i + 1)
                    {
                        sieve[j] = true;
                    }
                }
            }

            List<int> primes = new List<int>();

            for (int i = 1; i <= sievebound; i++)
            {
                if (!sieve[i])
                {
                    int p = 2 * i + 1;

                    // Save off this list
                    primes.Add(p);
                }
            }

            return primes;
        }
    }
}
