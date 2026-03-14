using System;

// Problem 66: Diophantine Equation
// Answer: 661

using System.Diagnostics;
using System.Numerics;

static int Solve()
{
    BigInteger bestX = 0;
    int bestD = 0;

    for (int d = 2; d <= 1000; d++)
    {
        int a0 = (int)Math.Sqrt(d);
        if (a0 * a0 == d) continue;

        long m = 0, dn = 1, a = a0;

        BigInteger hPrev2 = 1, hPrev1 = a0;
        BigInteger kPrev2 = 0, kPrev1 = 1;

        while (true)
        {
            m = dn * a - m;
            dn = (d - m * m) / dn;
            a = (a0 + m) / dn;

            BigInteger newH = a * hPrev1 + hPrev2;
            BigInteger newK = a * kPrev1 + kPrev2;

            // Check x^2 - D*y^2 == 1
            if (newH * newH - d * newK * newK == 1)
            {
                if (newH > bestX)
                {
                    bestX = newH;
                    bestD = d;
                }
                break;
            }

            hPrev2 = hPrev1;
            hPrev1 = newH;
            kPrev2 = kPrev1;
            kPrev1 = newK;
        }
    }

    return bestD;
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

double nsPerOp = (double)sw.Elapsed.Ticks / iterations * 100;
Console.WriteLine($"Result: {result} ({nsPerOp:F2} ns/op)");
