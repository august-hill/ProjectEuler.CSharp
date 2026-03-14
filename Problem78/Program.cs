using System;

// Problem 78: Coin Partitions
// Answer: 55374

using System.Diagnostics;

static int Solve()
{
    const int limit = 100_000;
    const int modulus = 1_000_000;
    int[] p = new int[limit];
    p[0] = 1;

    // Precompute generalized pentagonal numbers
    int[] pentagonals = new int[1000];
    int numPent = 0;
    for (int k = 1; k < 500; k++)
    {
        pentagonals[numPent++] = k * (3 * k - 1) / 2;
        pentagonals[numPent++] = k * (3 * k + 1) / 2;
    }

    for (int n = 1; n < limit; n++)
    {
        long sum = 0;
        for (int i = 0; i < numPent; i++)
        {
            if (pentagonals[i] > n) break;

            int sign = (i % 4 < 2) ? 1 : -1;
            sum = (sum + sign * (long)p[n - pentagonals[i]]) % modulus;
        }

        p[n] = (int)(((sum % modulus) + modulus) % modulus);

        if (p[n] == 0)
            return n;
    }

    return 0;
}

// Warmup
for (int i = 0; i < 10; i++)
    Solve();

// Benchmark
const int iterations = 100;
var sw = Stopwatch.StartNew();
int result = 0;
for (int i = 0; i < iterations; i++)
    result = Solve();
sw.Stop();

double nsPerOp = (double)sw.Elapsed.Ticks / Stopwatch.Frequency * 1_000_000_000 / iterations;
Console.WriteLine($"Result: {result} ({nsPerOp:F2} ns/op)");
