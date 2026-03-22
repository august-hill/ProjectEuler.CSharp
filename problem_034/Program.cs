// Answer: 40730

namespace Problem34;

internal static class Program
{
    private static readonly int[] Factorials = { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880 };

    private static int DigitFactorialSum(int n)
    {
        int sum = 0;
        while (n > 0)
        {
            sum += Factorials[n % 10];
            n /= 10;
        }
        return sum;
    }

    static long Solve()
    {
        // Upper bound: 7 * 9! = 2540160
        long sum = 0;
        for (int n = 3; n <= 2540160; n++)
        {
            if (n == DigitFactorialSum(n))
                sum += n;
        }
        return sum;
    }

    static void Main() => Bench.Run(34, Solve);
}
