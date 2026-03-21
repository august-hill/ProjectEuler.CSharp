// Answer: 972
using System.Numerics;

namespace Problem56;

internal static class Program
{
    private static int DigitSum(BigInteger n)
    {
        int sum = 0;
        while (n > 0)
        {
            sum += (int)(n % 10);
            n /= 10;
        }
        return sum;
    }

    static long Solve()
    {
        int maxSum = 0;
        for (int a = 2; a < 100; a++)
        {
            BigInteger power = 1;
            for (int b = 1; b < 100; b++)
            {
                power *= a;
                int s = DigitSum(power);
                if (s > maxSum) maxSum = s;
            }
        }
        return maxSum;
    }

    static void Main() => Bench.Run(56, Solve);
}
