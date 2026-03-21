// Answer: 40730
using System.Numerics;

namespace Problem34;

internal static class Program
{
    private static BigInteger factorial(BigInteger n)
    {
        if (n == 0) return 1;
        return n * factorial(n - 1);
    }

    static long Solve()
    {
        const int LIMIT = 100000;
        long sum = 0;
        for (BigInteger n = 3; n < LIMIT; n++)
        {
            string digits = n.ToString();
            BigInteger digitSum = 0;
            foreach (char ch in digits)
                digitSum += factorial(ch - '0');
            if (n == digitSum) sum += (long)n;
        }
        return sum;
    }

    static void Main() => Bench.Run(34, Solve);
}
