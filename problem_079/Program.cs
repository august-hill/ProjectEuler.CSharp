// Answer: 73162890
using System.Collections.Generic;
using System.IO;

namespace Problem79;

internal static class Program
{
    private static string[]? _cachedLines;
    private static string[] LoadLines()
    {
        if (_cachedLines != null) return _cachedLines;
        _cachedLines = File.ReadAllLines("p079_keylog.txt");
        return _cachedLines;
    }

    static long Solve()
    {
        var lines = LoadLines();
        var digits = new HashSet<int>();
        var after = new bool[10, 10];
        foreach (var line in lines)
        {
            if (line.Trim().Length < 3) continue;
            int a = line[0] - '0', b = line[1] - '0', c = line[2] - '0';
            digits.Add(a); digits.Add(b); digits.Add(c);
            after[a, b] = true; after[a, c] = true; after[b, c] = true;
        }

        var result = new List<int>();
        var used = new bool[10];
        while (result.Count < digits.Count)
        {
            for (int d = 0; d < 10; d++)
            {
                if (!digits.Contains(d) || used[d]) continue;
                bool hasPred = false;
                for (int o = 0; o < 10; o++)
                {
                    if (o != d && digits.Contains(o) && !used[o] && after[o, d])
                    { hasPred = true; break; }
                }
                if (!hasPred) { result.Add(d); used[d] = true; break; }
            }
        }

        long val = 0;
        foreach (var d in result) val = val * 10 + d;
        return val;
    }

    static void Main() => Bench.Run(79, Solve);
}
