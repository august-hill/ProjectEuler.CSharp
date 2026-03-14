using System;

// Problem 65: Convergents of e
// Answer: 272

using System.Diagnostics;
using System.Numerics;

static int Solve()
{
    // e = [2; 1, 2, 1, 1, 4, 1, 1, 6, ...]
    static int CfCoeff(int k)
    {
        if (k == 0) return 2;
        int j = k - 1;
        if (j % 3 == 1) return 2 * (j / 3 + 1);
        return 1;
    }

    BigInteger hPrev2 = 1;  // h_{-1}
    BigInteger hPrev1 = 2;  // h_0

    for (int k = 1; k < 100; k++)
    {
        int a = CfCoeff(k);
        BigInteger newH = a * hPrev1 + hPrev2;
        hPrev2 = hPrev1;
        hPrev1 = newH;
    }

    int sum = 0;
    foreach (char c in hPrev1.ToString())
        sum += c - '0';
    return sum;
}

// Warmup
for (int i = 0; i < 10; i++)
    Solve();

// Benchmark
const int iterations = 10000;
var sw = Stopwatch.StartNew();
int result = 0;
for (int i = 0; i < iterations; i++)
    result = Solve();
sw.Stop();

double nsPerOp = (double)sw.Elapsed.Ticks / iterations * 100;
Console.WriteLine($"Result: {result} ({nsPerOp:F2} ns/op)");
