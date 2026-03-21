// Answer: 40886
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Problem80;

internal static class Program
{
    private static bool IsPerfectSquare(int n)
    {
        int s = (int)Math.Sqrt(n);
        return s * s == n;
    }

    private static int SqrtDigitSum(int n)
    {
        var pairs = new List<int>();
        if (n < 100) pairs.Add(n);
        else { pairs.Add(n / 100); pairs.Add(n % 100); }
        while (pairs.Count < 110) pairs.Add(0);

        BigInteger p = 0;
        BigInteger rem = 0;
        int digitSum = 0;
        for (int i = 0; i < 100; i++)
        {
            rem = rem * 100 + pairs[i];
            BigInteger twentyP = p * 20;
            int x = 0;
            for (int d = 9; d >= 1; d--)
            {
                BigInteger trial = (twentyP + d) * d;
                if (trial <= rem) { x = d; rem -= trial; break; }
            }
            p = p * 10 + x;
            digitSum += x;
        }
        return digitSum;
    }

    static long Solve()
    {
        int total = 0;
        for (int n = 1; n <= 100; n++)
            if (!IsPerfectSquare(n)) total += SqrtDigitSum(n);
        return total;
    }

    static void Main() => Bench.Run(80, Solve);
}
