using System;

// Problem 69: Totient Maximum
// Find n <= 1,000,000 for which n/phi(n) is a maximum.
// Answer: 510510

// n/phi(n) is maximized when n is the product of consecutive primes.
// 2 * 3 * 5 * 7 * 11 * 13 * 17 = 510510

using System.Diagnostics;

static long Solve()
{
    int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
    long limit = 1_000_000;
    long result = 1;

    foreach (int p in primes)
    {
        if (result * p > limit) break;
        result *= p;
    }

    return result;
}

// Warmup
for (int i = 0; i < 10; i++) Solve();

var sw = Stopwatch.StartNew();
int iterations = 10000;
long result = 0;
for (int i = 0; i < iterations; i++) result = Solve();
sw.Stop();

double nsPerOp = sw.Elapsed.TotalNanoseconds / iterations;
Console.WriteLine("Problem 69: Totient Maximum");
Console.WriteLine("===========================");
Console.WriteLine($"Result: {result} ({nsPerOp:F2} ns/op)");
