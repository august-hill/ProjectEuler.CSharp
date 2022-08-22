using System.Collections;
using System.Diagnostics;

namespace Problem10;

internal static class Program
{
    private static long Solution1(int limit)
    {
        var stopwatch = new Stopwatch();

        // assume everything is prime (true)
        // assume our numbers start counting at 0 (so we add one to the limit)
        var sieve = new BitArray(limit + 1, true);
        sieve[0] = sieve[1] = false; // 0 and 1 are not prime

        for (var n = 4; n <= limit; n += 2) // mark even numbers > 2 as not prime
            sieve[n] = false;

        // the square root of our largest prime value is the highest value we need to check
        var greatestMultiple = Convert.ToInt32(Math.Floor(Math.Sqrt(limit)));
        for (var n = 3; n <= greatestMultiple; n += 2)
            if (sieve[n]) // n is marked, hence prime
                for (var m = n * n; m < limit; m += 2 * n) // now eliminate the multiples of the prime
                    sieve[m] = false;

        // Sum the primes...
        long sum = 0;
        for (var i = 0; i <= limit; i++)
            if (sieve[i])
                sum += i;

        stopwatch.Stop();
        Console.WriteLine($"for limit = {limit}, sum = {sum}, in {stopwatch.ElapsedTicks} ticks.");

        return sum;
    }

    private static long Solution2(int limit)
    {
        var stopwatch = new Stopwatch();

        // Sieve implemented without storing even numbers...
        // Now prime p, is represented as p = 2 * i + 1, where i is sieve[i].

        var upperLimit = (limit - 1) / 2; // last index of the sieve
        var sieve = new BitArray(upperLimit + 1, true); // + 1 corrects for 0 based arrays
        // assume everything is prime (true)

        var greatestMultiple = (Convert.ToInt32(Math.Floor(Math.Sqrt(limit))) - 1) / 2;
        for (var i = 1; i <= greatestMultiple; i++)
            if (sieve[i]) // 2*i+1 is prime, mark multiples
                for (var j = 2 * i * (i + 1); j <= upperLimit; j += 2 * i + 1)
                    sieve[j] = false;

        // Sum the primes...
        long sum = 2; // 2 is prime but not accounted for in our implementation
        for (var i = 1; i <= upperLimit; i++)
            if (sieve[i])
                sum += 2 * i + 1;

        stopwatch.Stop();
        Console.WriteLine($"for limit = {limit}, sum = {sum}, in {stopwatch.ElapsedTicks} ticks.");

        return sum;
    }

    private static void Main()
    {
        long limit10Solution1 = Solution1(10);
        Debug.Assert(limit10Solution1 == 17, "Solution1: The correct answer is 17 for a limit of 10.");
        long limit10Solution2 = Solution2(10);
        Debug.Assert(limit10Solution2 == 17, "Solution2: The correct answer is 17 for a limit of 10.");

        // Note the correct answer is 142913828922 for a limit of 2000000.
        long limit2MSolution1 = Solution1(2000000);
        Debug.Assert(limit2MSolution1 == 142913828922L, "Solution1: The correct answer is 142913828922 for a limit of 2000000.");
        long limit2MSolution2 = Solution2(2000000);
        Debug.Assert(limit2MSolution2 == 142913828922L, "Solution2: The correct answer is 142913828922 for a limit of 2000000.");
    }
}