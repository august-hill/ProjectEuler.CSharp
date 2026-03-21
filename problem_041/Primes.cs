using System.Collections;

// Problem41
// Pandigital prime
// We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once. For example,
// 2143 is a 4-digit pandigital and is also prime.
//
// What is the largest n-digit pandigital prime that exists?

namespace Problem41
{
    class Primes
    {
        private readonly BitArray _sieve;
        public Primes(int limit)
        {
            // Sieve implemented without storing even numbers...
            // Now prime p, is represented as p = 2 * i + 1, where i is sieve[i].

            int sieveBound = (limit - 1) / 2;   // last index of the sieve
            _sieve = new BitArray(sieveBound + 1);
            int crossLimit = (Convert.ToInt32(Math.Floor(Math.Sqrt(Convert.ToDouble(limit)))) - 1) / 2;
            for (int i = 1; i <= crossLimit; i++)
            {
                if (!_sieve[i])
                {
                    for (int j = 2 * i * (i + 1); j <= sieveBound; j += 2 * i + 1)
                    {
                        _sieve[j] = true;
                    }
                }
            }
        }

        private bool IsPrime(int p)
        {
            // 1 is a unit, not composite or prime
            if (p < 2)
            {
                return false;
            }

            // 2 is a prime
            if (p == 2)
            {
                return true;
            }

            // even numbers are not prime
            if (p % 2 == 0)
            {
                return false;
            }

            return !_sieve[(p - 1) / 2];
        }

        public bool IsComposite(int c)
        {
            // 1 is a unit, not composite or prime
            if (c < 2)
            {
                return false;
            }

            return !IsPrime(c);
        }

        public List<int> GetPrimeList()
        {
            var primes = new List<int> {2};
            for (int i = 1; i < _sieve.Length - 1; i++)
            {
                if (!_sieve[i])
                {
                    primes.Add(i * 2 + 1);
                }
            }

            return primes;
        }
    }
}