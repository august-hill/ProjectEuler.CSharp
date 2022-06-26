using System.Diagnostics;

// Problem7
// 10001st prime
// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
//
// What is the 10,001st prime number?


namespace Problem7
{
    class Program
    {
        private static ulong Prime(int n)
        {
            // Generate a list of Prime numbers...
            var primes = new List<ulong> {2};   // Special case 2, so we can increment by 2 below

            // We're going to start generating Prime numbers
            for (ulong i = 3L; primes.Count < n; i += 2L)
            {
                // Assume it is Prime...
                bool valid = true;
                foreach (ulong p in primes)
                {
                    // If i is evenly divisible by a Prime, 
                    // then it's not Prime and we skip it.
                    if (i % p == 0)
                    {
                        valid = false;
                        break;
                    }
                }
                if (valid)
                {
                    // Keep track of Primes we've seen.
                    primes.Add(i);
                }
            }

            return primes[^1];  // new syntax
        }

        private static void Main()
        {
            var timeTaken = Stopwatch.StartNew();
            const int nthPrime = 10001;
            var prime = Prime(nthPrime);
            timeTaken.Stop();
            Console.WriteLine("The {0} Prime is {1} in {2} ms.", nthPrime, prime, timeTaken.ElapsedMilliseconds);
        }
    }
}