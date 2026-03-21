// Answer: 232792560

namespace Problem5;

internal static class Program
{
    private const int TopOfRange = 20;

    private static List<ulong> GeneratePrimes(ulong n)
    {
        var primes = new List<ulong> {2};
        for (ulong i = 3; i <= n; i += 2)
        {
            var valid = true;
            foreach (var p in primes)
                if (i % p == 0)
                {
                    valid = false;
                    break;
                }
            if (valid)
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
        throw new InvalidOperationException();
    }

    static long Solve()
    {
        var primes = GeneratePrimes(TopOfRange);

        var factorList = new List<List<ulong>>();
        for (ulong i = 2; i < TopOfRange; i++) factorList.Add(PrimeFactors(primes, i));

        var factors = new List<ulong>();
        foreach (var fList in factorList)
        {
            var workingList = new List<ulong>(factors);
            foreach (var fItem in fList)
            {
                if (workingList.Contains(fItem))
                    workingList.Remove(fItem);
                else
                    factors.Add(fItem);
            }
        }

        ulong result = 1;
        foreach (var fItem in factors) result *= fItem;

        return (long)result;
    }

    static void Main() => Bench.Run(5, Solve);
}
