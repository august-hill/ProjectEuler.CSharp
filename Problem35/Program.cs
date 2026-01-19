using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem35
{
    class Program
    {
        private static SortedSet<int> Primes = GeneratePrimes(1000000);


        static void Main(string[] args)
        {
            SortedSet<int> CircularPrimes = new SortedSet<int>();

            foreach (int p in Primes)
            {
                if (p < 9)
                {
                    CircularPrimes.Add(p);
                    continue;
                }

                SortedSet<int> rotations = Rotate(p);

                if (rotations.IsProperSubsetOf(Primes))
                {
                    CircularPrimes.Add(p);  // bad alg
                }
            }

        }

        private static SortedSet<int> Rotate(int p)
        {
            string s = p.ToString();
            int length = s.Length;
            SortedSet<int> result = new SortedSet<int>();

            for (int i = 0; i < length; i++)
            {
                string r = s.Substring(i, length - i) + s.Substring(0, i);
                result.Add(Convert.ToInt32(r));
            }

            return result;
        }

        private static SortedSet<int> GeneratePrimes(int limit)
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

            SortedSet<int> primes = new SortedSet<int>();
            primes.Add(2);  // 2 is prime

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
