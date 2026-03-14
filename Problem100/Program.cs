using System;

// Problem 100: Arranged Probability
// Answer: 756872327473

using System.Diagnostics;

static long Solve()
{
    long limit = 1_000_000_000_000L;
    long b = 15, n = 21;

    while (n <= limit)
    {
        long newB = 3 * b + 2 * n - 2;
        long newN = 4 * b + 3 * n - 3;
        b = newB;
        n = newN;
    }
    return b;
}

// Warmup
for (int i = 0; i < 10; i++) Solve();

const int iterations = 10000;
var sw = Stopwatch.StartNew();
long result = 0;
for (int i = 0; i < iterations; i++)
    result = Solve();
sw.Stop();

double nsPerOp = (double)sw.Elapsed.Ticks / iterations * 100;
Console.WriteLine($"Result: {result} ({nsPerOp:F2} ns/op)");
