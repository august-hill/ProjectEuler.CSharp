using System;

// Problem 94: Almost Equilateral Triangles
// Answer: 518408346

using System.Diagnostics;

static long Solve()
{
    long limit = 1_000_000_000L;
    long total = 0;

    // Case 1: sides a, a, a+1. Perimeter = 3a+1.
    {
        long aPrev = 1, aCurr = 5;
        while (true)
        {
            long perimeter = 3 * aCurr + 1;
            if (perimeter > limit) break;
            total += perimeter;
            long aNext = 14 * aCurr - aPrev - 4;
            aPrev = aCurr;
            aCurr = aNext;
        }
    }

    // Case 2: sides a, a, a-1. Perimeter = 3a-1.
    {
        long aPrev = 1, aCurr = 17;
        while (true)
        {
            long perimeter = 3 * aCurr - 1;
            if (perimeter > limit) break;
            total += perimeter;
            long aNext = 14 * aCurr - aPrev + 4;
            aPrev = aCurr;
            aCurr = aNext;
        }
    }

    return total;
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
