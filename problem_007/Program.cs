// Answer: 104743

namespace Problem7;

internal static class Program
{
    private static ulong Prime(int n)
    {
        var primes = new List<ulong> {2};
        for (ulong i = 3L; primes.Count < n; i += 2L)
        {
            bool valid = true;
            foreach (ulong p in primes)
            {
                if (i % p == 0)
                {
                    valid = false;
                    break;
                }
            }
            if (valid)
            {
                primes.Add(i);
            }
        }
        return primes[^1];
    }

    static long Solve()
    {
        return (long)Prime(10001);
    }

    static void Main() => Bench.Run(7, Solve);
}
