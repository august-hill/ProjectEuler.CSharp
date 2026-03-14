using System;

// Problem 85: Counting Rectangles
// Find the area of the grid with the nearest solution to containing two million rectangles.
// Answer: 2772

using System.Diagnostics;

static int Solve()
{
    long target = 2_000_000;
    int bestArea = 0;
    long bestDiff = target;

    for (int m = 1; m <= 2000; m++)
    {
        long cm = (long)m * (m + 1) / 2;
        if (cm > target) break;
        for (int n = m; n <= 2000; n++)
        {
            long count = cm * n * (n + 1) / 2;
            long diff = Math.Abs(count - target);
            if (diff < bestDiff)
            {
                bestDiff = diff;
                bestArea = m * n;
            }
            if (count > target) break;
        }
    }
    return bestArea;
}

for (int i = 0; i < 10; i++) Solve();

const int iterations = 10000;
var sw = Stopwatch.StartNew();
int result = 0;
for (int i = 0; i < iterations; i++) result = Solve();
sw.Stop();

double nsPerOp = (double)sw.Elapsed.Ticks / iterations * 100;
Console.WriteLine($"Result: {result} ({nsPerOp:F2} ns/op)");
