using System.Diagnostics;

// Problem5
//
// Smallest multiple
//
// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
//
// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?


namespace Problem5;

internal class Program
{
    private const int TopOfRange = 20;

    private static List<ulong> GeneratePrimes(ulong n)
    {
        // Generate a list of Prime numbers <= to n...
        var primes = new List<ulong> {2};   // special case for 2

        // We're going to start generating Prime numbers
        for (ulong i = 3; i <= n; i += 2)
        {
            // Assume it is Prime...
            var valid = true;
            foreach (var p in primes)
                // If i is evenly divisible by a Prime, 
                // then it's not Prime and we skip it.
                if (i % p == 0)
                {
                    valid = false;
                    break;
                }

            if (valid)
                // Keep track of Primes we've seen.
                primes.Add(i);
        }

        return primes;
    }

    private static List<ulong> PrimeFactors(List<ulong> primes, ulong number)
    {
        var result = new List<ulong>();

        foreach (var prime in primes)
            while (number % prime == 0)
            {
                result.Add(prime);
                number /= prime;
                if (number == 1) return result;
            }

        // If we get here, there is a logic error above
        throw new InvalidOperationException();
    }

    private static void Main()
    {
        var timeTaken = Stopwatch.StartNew();

        // Generate only the prime numbers we need
        var primes = GeneratePrimes(TopOfRange);

        // Create a list of lists that has all the prime factors for each number
        var factorList = new List<List<ulong>>();
        for (ulong i = 2; i < TopOfRange; i++) factorList.Add(PrimeFactors(primes, i));

        // The real logic of combining only the needed prime factors to calculate the minimum number
        var factors = new List<ulong>();
        foreach (var fList in factorList)
        {
            var workingList = new List<ulong>(factors);
            foreach (var fItem in fList)
            {
                Console.Write($"{fItem} ");
                if (workingList.Contains(fItem))
                    workingList.Remove(fItem);
                else
                    factors.Add(fItem);
            }

            Console.WriteLine();
        }

        // And now do the math to get the answer
        ulong result = 1;
        foreach (var fItem in factors) result *= fItem;

        timeTaken.Stop();
        Console.WriteLine($"Our number is {result}, in {timeTaken.ElapsedMilliseconds} ms.");
    }
}