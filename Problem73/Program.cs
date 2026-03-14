using System;

// Problem 73: Counting Fractions in a Range
// Answer: 7295372

using System.Diagnostics;

static long Solve()
{
    int limit = 12_000;
    long count = 0;

    for (int d = 2; d <= limit; d++)
    {
        int nMin = d / 3 + 1;
        int nMax = (d % 2 == 0) ? d / 2 - 1 : d / 2;

        for (int n = nMin; n <= nMax; n++)
        {
            if (Gcd(n, d) == 1)
                count++;
        }
    }

    return count;
}

static int Gcd(int a, int b)
{
    while (b != 0)
    {
        int t = b;
        b = a % b;
        a = t;
    }
    return a;
}

// Warmup
for (int i = 0; i < 10; i++)
    Solve();

// Benchmark
const int iterations = 10;
var sw = Stopwatch.StartNew();
long result = 0;
for (int i = 0; i < iterations; i++)
    result = Solve();
sw.Stop();

double nsPerOp = (double)sw.Elapsed.Ticks / Stopwatch.Frequency * 1_000_000_000 / iterations;
Console.WriteLine($"Result: {result} ({nsPerOp:F2} ns/op)");
