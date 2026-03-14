using System;
using System.Collections.Generic;
using System.Linq;

// Problem 93: Arithmetic Expressions
// Answer: 1258

using System.Diagnostics;

static double[] EvalAll(double a, double b)
{
    var results = new List<double> { a + b, a - b, b - a, a * b };
    if (Math.Abs(b) > 1e-12) results.Add(a / b);
    if (Math.Abs(a) > 1e-12) results.Add(b / a);
    return results.ToArray();
}

static int Solve()
{
    int bestDigits = 0;
    int bestCount = 0;

    for (int a = 1; a <= 9; a++)
    for (int b = a + 1; b <= 9; b++)
    for (int c = b + 1; c <= 9; c++)
    for (int d = c + 1; d <= 9; d++)
    {
        double[] digits = { a, b, c, d };
        var seen = new HashSet<int>();

        // All 24 permutations
        var perms = new List<int[]>();
        for (int i = 0; i < 4; i++)
        for (int j = 0; j < 4; j++)
        {
            if (j == i) continue;
            for (int k = 0; k < 4; k++)
            {
                if (k == i || k == j) continue;
                int l = 6 - i - j - k;
                perms.Add(new[] { i, j, k, l });
            }
        }

        foreach (var p in perms)
        {
            double w = digits[p[0]], x = digits[p[1]], y = digits[p[2]], z = digits[p[3]];

            // ((w op x) op y) op z
            foreach (double wx in EvalAll(w, x))
            foreach (double wxy in EvalAll(wx, y))
            foreach (double wxyz in EvalAll(wxy, z))
            {
                if (wxyz > 0.5 && Math.Abs(wxyz - Math.Round(wxyz)) < 1e-9)
                    seen.Add((int)Math.Round(wxyz));
            }

            // (w op x) op (y op z)
            foreach (double wx in EvalAll(w, x))
            foreach (double yz in EvalAll(y, z))
            foreach (double r in EvalAll(wx, yz))
            {
                if (r > 0.5 && Math.Abs(r - Math.Round(r)) < 1e-9)
                    seen.Add((int)Math.Round(r));
            }
        }

        int count = 0;
        for (int n = 1; ; n++)
        {
            if (seen.Contains(n)) count = n;
            else break;
        }
        if (count > bestCount)
        {
            bestCount = count;
            bestDigits = a * 1000 + b * 100 + c * 10 + d;
        }
    }
    return bestDigits;
}

// Warmup
for (int i = 0; i < 10; i++) Solve();

const int iterations = 10;
var sw = Stopwatch.StartNew();
int result = 0;
for (int i = 0; i < iterations; i++)
    result = Solve();
sw.Stop();

double nsPerOp = (double)sw.Elapsed.Ticks / iterations * 100;
Console.WriteLine($"Result: {result} ({nsPerOp:F2} ns/op)");
