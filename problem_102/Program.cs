// Answer: 228
using System;
using System.IO;

namespace Problem102;

internal static class Program
{
    private static string[]? _cachedLines;

    static string[] LoadLines()
    {
        if (_cachedLines != null) return _cachedLines;
        _cachedLines = File.ReadAllLines("p102_triangles.txt");
        return _cachedLines;
    }

    static bool ContainsOrigin(int x1, int y1, int x2, int y2, int x3, int y3)
    {
        long d1 = (long)(-x1) * (y2 - y1) - (long)(-y1) * (x2 - x1);
        long d2 = (long)(-x2) * (y3 - y2) - (long)(-y2) * (x3 - x2);
        long d3 = (long)(-x3) * (y1 - y3) - (long)(-y3) * (x1 - x3);

        bool hasNeg = d1 < 0 || d2 < 0 || d3 < 0;
        bool hasPos = d1 > 0 || d2 > 0 || d3 > 0;

        return !(hasNeg && hasPos);
    }

    static long Solve()
    {
        var lines = LoadLines();
        int count = 0;
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            var parts = line.Split(',');
            if (parts.Length != 6) continue;
            int x1 = int.Parse(parts[0]);
            int y1 = int.Parse(parts[1]);
            int x2 = int.Parse(parts[2]);
            int y2 = int.Parse(parts[3]);
            int x3 = int.Parse(parts[4]);
            int y3 = int.Parse(parts[5]);
            if (ContainsOrigin(x1, y1, x2, y2, x3, y3))
                count++;
        }
        return count;
    }

    static void Main() => Bench.Run(102, Solve);
}
