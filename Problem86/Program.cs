using System;

// Problem 86: Cuboid Route
// Answer: 1818

using System.Diagnostics;

static int Solve()
{
    int count = 0;
    int m = 1;

    while (true)
    {
        for (int s = 2; s <= 2 * m; s++)
        {
            int sq = m * m + s * s;
            int root = (int)Math.Sqrt(sq);
            if (root * root == sq)
            {
                int cMin = (s > m) ? s - m : 1;
                int cMax = s / 2;
                if (cMax >= cMin)
                    count += cMax - cMin + 1;
            }
        }

        if (count > 1_000_000)
            return m;
        m++;
    }
}

// Warmup
for (int i = 0; i < 10; i++)
    Solve();

// Benchmark
const int iterations = 10;
var sw = Stopwatch.StartNew();
int result = 0;
for (int i = 0; i < iterations; i++)
    result = Solve();
sw.Stop();

double nsPerOp = (double)sw.Elapsed.Ticks / iterations * 100;
Console.WriteLine($"Result: {result} ({nsPerOp:F2} ns/op)");
