// Answer: 428570

namespace Problem71;

internal static class Program
{
    static long Solve()
    {
        long limit = 1_000_000;
        long bestN = 0, bestD = 1;
        for (long d = 2; d <= limit; d++)
        {
            long n = (3 * d - 1) / 7;
            if (n * bestD > bestN * d)
            { bestN = n; bestD = d; }
        }
        return bestN;
    }

    static void Main() => Bench.Run(71, Solve);
}
