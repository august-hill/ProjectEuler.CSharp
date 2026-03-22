// Answer: 7295372

namespace Problem73;

internal static class Program
{
    const int Limit = 12_000;

    static long CountBetween(int a, int b, int c, int d)
    {
        int medNum = a + c;
        int medDen = b + d;
        if (medDen > Limit) return 0;
        return 1 + CountBetween(a, b, medNum, medDen)
                 + CountBetween(medNum, medDen, c, d);
    }

    static long Solve() => CountBetween(1, 3, 1, 2);

    static void Main() => Bench.Run(73, Solve);
}
