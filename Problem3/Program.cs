// Problem3
//
// Largest prime factor
//
// The prime factors of 13195 are 5, 7, 13 and 29.
//
//     What is the largest prime factor of the number 600851475143 ?


namespace Problem3
{

    class Program
    {

        private const ulong OurNumber = 600851475143L;

        private static void Main()
        {
            var workingNumber = OurNumber;
            var timeTaken = new System.Diagnostics.Stopwatch();
            timeTaken.Start();

            // Generate a list of Prime numbers...
            var primes = new List<ulong>();

            // We're going to start generating Prime numbers
            for (ulong potentialPrime = 2L; potentialPrime < OurNumber; potentialPrime++)
            {
                // Assume it is Prime...
                var valid = true;
                foreach (var p in primes)
                {
                    // If potentialPrime is evenly divisible by a Prime, 
                    // then it's not Prime and we skip it.
                    if (potentialPrime % p == 0)
                    {
                        valid = false;
                        break;
                    }
                }
                if (valid)
                {
                    // Keep track of Primes we've seen.
                    primes.Add(potentialPrime);
                }

                // Now we start solving the real problem...

                // potentialPrime is Prime, is it a factor of the given number?
                while (workingNumber % potentialPrime == 0)
                {
                    workingNumber /= potentialPrime;
                    Console.WriteLine($"a prime factor found: {potentialPrime}, remaining value: {workingNumber}");
                }

                // Terminal state...
                if (workingNumber == 1)
                {
                    timeTaken.Stop();
                    Console.WriteLine($"Largest Prime Factor found in {timeTaken.ElapsedMilliseconds} ms.");
                    break;
                }
            }
        }
    }
}