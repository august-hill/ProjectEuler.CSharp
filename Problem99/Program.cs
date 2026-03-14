using System;
using System.IO;

// Problem 99: Largest Exponential
// Answer: 709

using System.Diagnostics;

var fileLines = File.ReadAllLines("p099_base_exp.txt");

static int Solve(string[] lines)
{
    int bestLine = 0;
    double bestVal = 0.0;

    for (int i = 0; i < lines.Length; i++)
    {
        var line = lines[i].Trim();
        if (string.IsNullOrEmpty(line)) continue;
        var parts = line.Split(',');
        double b = double.Parse(parts[0]);
        double e = double.Parse(parts[1]);
        double val = e * Math.Log(b);
        if (val > bestVal)
        {
            bestVal = val;
            bestLine = i + 1;
        }
    }
    return bestLine;
}

// Warmup
for (int i = 0; i < 10; i++) Solve(fileLines);

const int iterations = 10000;
var sw = Stopwatch.StartNew();
int result = 0;
for (int i = 0; i < iterations; i++)
    result = Solve(fileLines);
sw.Stop();

double nsPerOp = (double)sw.Elapsed.Ticks / iterations * 100;
Console.WriteLine($"Result: {result} ({nsPerOp:F2} ns/op)");
