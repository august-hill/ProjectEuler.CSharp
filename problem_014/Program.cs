// Answer: 837799

namespace Problem14;

internal static class Program
{
    private static int C(long n)
    {
        if (n == 1) return 1;
        if (n % 2 == 0)
            return C(n / 2) + 1;
        return C(3 * n + 1) + 1;
    }

    static long Solve()
    {
        long best_i = 0;
        long best_c = 0;
        for (long i = 999999; i > 0; i--)
        {
            var c = C(i);
            if (c > best_c)
            {
                best_c = c;
                best_i = i;
            }
        }
        return best_i;
    }

    static void Main() => Bench.Run(14, Solve);
}
