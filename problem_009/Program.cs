// Answer: 31875000

namespace Problem9;

internal static class Program
{
    static long Solve()
    {
        for (int a = 1; a < 998; a++)
        {
            for (int b = a + 1; b < 999; b++)
            {
                int c = 1000 - a - b;
                if (c <= 0 || a * a + b * b != c * c) continue;
                return a * b * c;
            }
        }
        return 0;
    }

    static void Main() => Bench.Run(9, Solve);
}
