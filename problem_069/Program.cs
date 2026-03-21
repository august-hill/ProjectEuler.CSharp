// Answer: 510510

namespace Problem69;

internal static class Program
{
    static long Solve()
    {
        int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
        long limit = 1_000_000;
        long result = 1;
        foreach (int p in primes)
        {
            if (result * p > limit) break;
            result *= p;
        }
        return result;
    }

    static void Main() => Bench.Run(69, Solve);
}
