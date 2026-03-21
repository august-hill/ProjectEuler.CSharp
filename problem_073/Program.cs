// Answer: 7295372

namespace Problem73;

internal static class Program
{
    private static int Gcd(int a, int b)
    {
        while (b != 0) { int t = b; b = a % b; a = t; }
        return a;
    }

    static long Solve()
    {
        int limit = 12_000;
        long count = 0;
        for (int d = 2; d <= limit; d++)
        {
            int nMin = d / 3 + 1;
            int nMax = (d % 2 == 0) ? d / 2 - 1 : d / 2;
            for (int n = nMin; n <= nMax; n++)
                if (Gcd(n, d) == 1) count++;
        }
        return count;
    }

    static void Main() => Bench.Run(73, Solve);
}
