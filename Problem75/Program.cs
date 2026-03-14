using System;

// Problem 75: Singular Integer Right Triangles
// Answer: 161667

using System.Diagnostics;

static int Solve()
{
    const int limit = 1_500_000;
    byte[] countArr = new byte[limit + 1];

    int mMax = (int)Math.Sqrt(limit / 2);

    for (int m = 2; m <= mMax; m++)
    {
        for (int n = 1; n < m; n++)
        {
            if ((m - n) % 2 == 0) continue;
            if (Gcd(m, n) != 1) continue;

            int perim = 2 * m * (m + n);
            if (perim > limit) break;

            for (int k = perim; k <= limit; k += perim)
            {
                if (countArr[k] < 2)
                    countArr[k]++;
            }
        }
    }

    int result = 0;
    for (int i = 1; i <= limit; i++)
    {
        if (countArr[i] == 1)
            result++;
    }
    return result;
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
const int iterations = 100;
var sw = Stopwatch.StartNew();
int result = 0;
for (int i = 0; i < iterations; i++)
    result = Solve();
sw.Stop();

double nsPerOp = (double)sw.Elapsed.Ticks / Stopwatch.Frequency * 1_000_000_000 / iterations;
Console.WriteLine($"Result: {result} ({nsPerOp:F2} ns/op)");
