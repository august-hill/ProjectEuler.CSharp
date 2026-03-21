// Answer: 1366
using System.Numerics;

namespace Problem16;

internal static class Program
{
    static long Solve()
    {
        BigInteger n = 2;
        for (int i = 1; i < 1000; i++)
        {
            n *= 2;
        }

        int sum = 0;
        BigInteger ten = 10;
        while (n != 0)
        {
            BigInteger digit = n % ten;
            sum += (int)digit;
            n /= ten;
        }

        return sum;
    }

    static void Main() => Bench.Run(16, Solve);
}
