using System;

// Problem 72: Counting Fractions
// How many reduced proper fractions with d <= 1,000,000?
// Answer: 303963552391

// The count of reduced proper fractions with denominator d is phi(d).
// Total = sum of phi(d) for d = 2 to 1,000,000.

using System.Diagnostics;

static long Solve()
{
    const int limit = 1_000_001;
    var phi = new int[limit];
    for (int i = 0; i < limit; i++) phi[i] = i;

    for (int i = 2; i < limit; i++)
    {
        if (phi[i] == i) // i is prime
        {
            for (int j = i; j < limit; j += i)
            {
                phi[j] -= phi[j] / i;
            }
        }
    }

    long total = 0;
    for (int i = 2; i < limit; i++)
    {
        total += phi[i];
    }
    return total;
}

// Warmup
for (int i = 0; i < 10; i++) Solve();

var sw = Stopwatch.StartNew();
int iterations = 10;
long result = 0;
for (int i = 0; i < iterations; i++) result = Solve();
sw.Stop();

double nsPerOp = sw.Elapsed.TotalNanoseconds / iterations;
Console.WriteLine("Problem 72: Counting Fractions");
Console.WriteLine("==============================");
Console.WriteLine($"Result: {result} ({nsPerOp:F2} ns/op)");
