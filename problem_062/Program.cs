// Answer: 127035954683
using System;
using System.Collections.Generic;

namespace Problem62;

internal static class Program
{
    static long Solve()
    {
        var groups = new Dictionary<string, (long firstCube, int count)>();
        for (long n = 1; n < 100000; n++)
        {
            long cube = n * n * n;
            char[] digits = cube.ToString().ToCharArray();
            Array.Sort(digits);
            string key = new string(digits);
            if (groups.TryGetValue(key, out var entry))
            {
                int newCount = entry.count + 1;
                groups[key] = (entry.firstCube, newCount);
                if (newCount == 5) return entry.firstCube;
            }
            else
            {
                groups[key] = (cube, 1);
            }
        }
        return 0;
    }

    static void Main() => Bench.Run(62, Solve);
}
