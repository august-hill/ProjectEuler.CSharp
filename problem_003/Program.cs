// Answer: 6857

namespace Problem3;

internal static class Program
{
    static long Solve()
    {
        const ulong OurNumber = 600851475143L;
        var workingNumber = OurNumber;
        var primes = new List<ulong>();

        for (ulong potentialPrime = 2L; potentialPrime < OurNumber; potentialPrime++)
        {
            var valid = true;
            foreach (var p in primes)
            {
                if (potentialPrime % p == 0)
                {
                    valid = false;
                    break;
                }
            }
            if (valid)
            {
                primes.Add(potentialPrime);
            }

            while (workingNumber % potentialPrime == 0)
            {
                workingNumber /= potentialPrime;
            }

            if (workingNumber == 1)
            {
                return (long)potentialPrime;
            }
        }

        return 0;
    }

    static void Main() => Bench.Run(3, Solve);
}
