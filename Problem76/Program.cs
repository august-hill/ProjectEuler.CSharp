using System;

// Problem 76: Counting Summations
// Answer: 190569291

using System.Diagnostics;

static long Solve()
{
    int target = 100;
    long[] dp = new long[target + 1];
    dp[0] = 1;

    // Use parts 1 through 99 (at least two integers)
    for (int part = 1; part < target; part++)
    {
        for (int i = part; i <= target; i++)
        {
            dp[i] += dp[i - part];
        }
    }

    return dp[target];
}

// Warmup
for (int i = 0; i < 10; i++)
    Solve();

// Benchmark
const int iterations = 10000;
var sw = Stopwatch.StartNew();
long result = 0;
for (int i = 0; i < iterations; i++)
    result = Solve();
sw.Stop();

double nsPerOp = (double)sw.Elapsed.Ticks / Stopwatch.Frequency * 1_000_000_000 / iterations;
Console.WriteLine($"Result: {result} ({nsPerOp:F2} ns/op)");
