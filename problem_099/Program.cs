// Answer: 709
using System;
using System.IO;

namespace Problem99;

internal static class Program
{
    private static string[]? _cachedLines;
    private static string[] LoadLines()
    {
        if (_cachedLines != null) return _cachedLines;
        _cachedLines = File.ReadAllLines("p099_base_exp.txt");
        return _cachedLines;
    }

    static long Solve()
    {
        var lines = LoadLines();
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
            if (val > bestVal) { bestVal = val; bestLine = i + 1; }
        }
        return bestLine;
    }

    static void Main() => Bench.Run(99, Solve);
}
