using System;

// Problem 71: Ordered Fractions
// Find the numerator of the fraction immediately to the left of 3/7
// in the Farey sequence with d <= 1,000,000.
// Answer: 428570

using System.Diagnostics;

static long Solve()
{
    long limit = 1_000_000;
    long bestN = 0, bestD = 1;

    for (long d = 2; d <= limit; d++)
    {
        long n = (3 * d - 1) / 7;
        // n/d > bestN/bestD ?
        if (n * bestD > bestN * d)
        {
            bestN = n;
            bestD = d;
        }
    }

    return bestN;
}

// Warmup
for (int i = 0; i < 10; i++) Solve();

var sw = Stopwatch.StartNew();
int iterations = 100;
long result = 0;
for (int i = 0; i < iterations; i++) result = Solve();
sw.Stop();

double nsPerOp = sw.Elapsed.TotalNanoseconds / iterations;
Console.WriteLine("Problem 71: Ordered Fractions");
Console.WriteLine("=============================");
Console.WriteLine($"Result: {result} ({nsPerOp:F2} ns/op)");
