using System;
using System.Collections.Generic;

// Problem 88: Product-sum Numbers
// Answer: 7587457

using System.Diagnostics;

const int K_MAX = 12000;
const int LIMIT = 2 * K_MAX;

static void Factorize(int product, int sum, int count, int minFactor, int[] minPs)
{
    int k = product - sum + count;
    if (k <= K_MAX)
    {
        if (product < minPs[k])
            minPs[k] = product;
    }

    for (int f = minFactor; f <= LIMIT; f++)
    {
        long newProduct = (long)product * f;
        if (newProduct > LIMIT) break;
        Factorize((int)newProduct, sum + f, count + 1, f, minPs);
    }
}

static long Solve()
{
    var minPs = new int[K_MAX + 1];
    Array.Fill(minPs, LIMIT + 1);

    for (int f = 2; f <= LIMIT; f++)
        Factorize(f, f, 1, f, minPs);

    var seen = new HashSet<int>();
    long total = 0;
    for (int k = 2; k <= K_MAX; k++)
    {
        if (seen.Add(minPs[k]))
            total += minPs[k];
    }
    return total;
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

double nsPerOp = (double)sw.Elapsed.Ticks / iterations * 100;
Console.WriteLine($"Result: {result} ({nsPerOp:F2} ns/op)");
