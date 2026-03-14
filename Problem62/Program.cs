using System;
using System.Collections.Generic;

// Problem 62: Cubic Permutations
// Answer: 127035954683

using System.Diagnostics;

static long Solve()
{
    var groups = new Dictionary<string, (long firstCube, int count)>();

    for (long n = 1; n < 100000; n++)
    {
        long cube = n * n * n;
        char[] digits = cube.ToString().ToCharArray();
        Array.Sort(digits);
        string key = new string(digits);

        if (groups.TryGetValue(key, out var entry))
        {
            int newCount = entry.count + 1;
            groups[key] = (entry.firstCube, newCount);
            if (newCount == 5) return entry.firstCube;
        }
        else
        {
            groups[key] = (cube, 1);
        }
    }
    return 0;
}

// Warmup
for (int i = 0; i < 10; i++)
    Solve();

// Benchmark
const int iterations = 1000;
var sw = Stopwatch.StartNew();
long result = 0;
for (int i = 0; i < iterations; i++)
    result = Solve();
sw.Stop();

double nsPerOp = (double)sw.Elapsed.Ticks / iterations * 100;
Console.WriteLine($"Result: {result} ({nsPerOp:F2} ns/op)");
