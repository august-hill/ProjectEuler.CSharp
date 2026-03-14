using System;

// Problem 64: Odd Period Square Roots
// Answer: 1322

using System.Diagnostics;

static int Solve()
{
    int count = 0;

    for (int n = 2; n <= 10000; n++)
    {
        int a0 = (int)Math.Sqrt(n);
        if (a0 * a0 == n) continue;

        int m = 0, d = 1, a = a0;
        int period = 0;

        do
        {
            m = d * a - m;
            d = (n - m * m) / d;
            a = (a0 + m) / d;
            period++;
        } while (a != 2 * a0);

        if (period % 2 == 1) count++;
    }

    return count;
}

// Warmup
for (int i = 0; i < 10; i++)
    Solve();

// Benchmark
const int iterations = 10000;
var sw = Stopwatch.StartNew();
int result = 0;
for (int i = 0; i < iterations; i++)
    result = Solve();
sw.Stop();

double nsPerOp = (double)sw.Elapsed.Ticks / iterations * 100;
Console.WriteLine($"Result: {result} ({nsPerOp:F2} ns/op)");
