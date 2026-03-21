// Answer: 76576500
using System;

namespace Problem12;

internal static class Program
{
    private static long CountDivisors(long n)
    {
        long count = 0;
        var sqrtN = (long)Math.Sqrt(n);
        for (long i = 1; i <= sqrtN; i++)
        {
            if (n % i == 0)
            {
                if (i * i == n)
                    count++;
                else
                    count += 2;
            }
        }
        return count;
    }

    static long Solve()
    {
        long n = 1;
        while (true)
        {
            long triangle = n * (n + 1) / 2;
            if (CountDivisors(triangle) > 500)
                return triangle;
            n++;
        }
    }

    static void Main() => Bench.Run(12, Solve);
}
