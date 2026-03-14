using System;

// Problem 91: Right Triangles in Quadrants
// Answer: 14234

using System.Diagnostics;

static int Solve()
{
    const int N = 50;
    int count = 0;

    for (int x1 = 0; x1 <= N; x1++)
    for (int y1 = 0; y1 <= N; y1++)
    {
        if (x1 == 0 && y1 == 0) continue;
        for (int x2 = 0; x2 <= N; x2++)
        for (int y2 = 0; y2 <= N; y2++)
        {
            if (x2 == 0 && y2 == 0) continue;
            if (x1 == x2 && y1 == y2) continue;
            if (x1 > x2 || (x1 == x2 && y1 > y2)) continue;

            int dotO = x1 * x2 + y1 * y2;
            int dotP = (-x1) * (x2 - x1) + (-y1) * (y2 - y1);
            int dotQ = (-x2) * (x1 - x2) + (-y2) * (y1 - y2);

            if (dotO == 0 || dotP == 0 || dotQ == 0)
                count++;
        }
    }

    return count;
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
