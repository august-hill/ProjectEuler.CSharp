// Answer: 443839

namespace Problem30;

internal static class Program
{
    private static readonly int[] Pow5 = { 0, 1, 32, 243, 1024, 3125, 7776, 16807, 32768, 59049 };

    private static int FifthPowerSum(int n)
    {
        int sum = 0;
        while (n > 0)
        {
            sum += Pow5[n % 10];
            n /= 10;
        }
        return sum;
    }

    static long Solve()
    {
        // Upper bound: 6 * 9^5 = 354294
        int sum = 0;
        for (int n = 2; n <= 354294; n++)
        {
            if (n == FifthPowerSum(n))
                sum += n;
        }
        return sum;
    }

    static void Main() => Bench.Run(30, Solve);
}
