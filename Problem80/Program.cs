using System;
using System.Collections.Generic;

// Problem 80: Square Root Digital Expansion
// For the first 100 natural numbers, find the total of the digital sums
// of the first 100 decimal digits of all irrational square roots.
// Answer: 40886

using System.Diagnostics;
using System.Numerics;

static bool IsPerfectSquare(int n)
{
    int s = (int)Math.Sqrt(n);
    return s * s == n;
}

static int SqrtDigitSum(int n)
{
    // Digit-by-digit square root method using BigInteger
    // Process pairs of digits, produce one result digit per pair
    var pairs = new List<int>();
    if (n < 100) pairs.Add(n);
    else { pairs.Add(n / 100); pairs.Add(n % 100); }
    while (pairs.Count < 110) pairs.Add(0);

    BigInteger p = 0; // accumulated result
    BigInteger rem = 0; // remainder

    int digitSum = 0;
    for (int i = 0; i < 100; i++)
    {
        rem = rem * 100 + pairs[i];
        BigInteger twentyP = p * 20;
        int x = 0;
        for (int d = 9; d >= 1; d--)
        {
            BigInteger trial = (twentyP + d) * d;
            if (trial <= rem)
            {
                x = d;
                rem -= trial;
                break;
            }
        }
        p = p * 10 + x;
        digitSum += x;
    }
    return digitSum;
}

static int Solve()
{
    int total = 0;
    for (int n = 1; n <= 100; n++)
    {
        if (!IsPerfectSquare(n))
            total += SqrtDigitSum(n);
    }
    return total;
}

// Warmup
for (int i = 0; i < 2; i++) Solve();

const int iterations = 10;
var sw = Stopwatch.StartNew();
int result = 0;
for (int i = 0; i < iterations; i++)
    result = Solve();
sw.Stop();

double nsPerOp = (double)sw.Elapsed.Ticks / iterations * 100;
Console.WriteLine($"Result: {result} ({nsPerOp:F2} ns/op)");
