// Answer: 756872327473

namespace Problem100;

internal static class Program
{
    static long Solve()
    {
        long limit = 1_000_000_000_000L;
        long b = 15, n = 21;
        while (n <= limit)
        {
            long newB = 3 * b + 2 * n - 2;
            long newN = 4 * b + 3 * n - 3;
            b = newB; n = newN;
        }
        return b;
    }

    static void Main() => Bench.Run(100, Solve);
}
