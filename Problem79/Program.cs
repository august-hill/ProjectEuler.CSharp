using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Problem 79: Passcode Derivation
// Given login attempts, find the shortest possible secret passcode.
// Answer: 73162890

using System.Diagnostics;

var lines = File.ReadAllLines("p079_keylog.txt");

static long Solve(string[] lines)
{
    var digits = new HashSet<int>();
    var after = new bool[10, 10]; // after[a,b] = a must come before b

    foreach (var line in lines)
    {
        if (line.Trim().Length < 3) continue;
        int a = line[0] - '0', b = line[1] - '0', c = line[2] - '0';
        digits.Add(a); digits.Add(b); digits.Add(c);
        after[a, b] = true; after[a, c] = true; after[b, c] = true;
    }

    // Topological sort
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
            if (!hasPred)
            {
                result.Add(d);
                used[d] = true;
                break;
            }
        }
    }

    long val = 0;
    foreach (var d in result) val = val * 10 + d;
    return val;
}

// Warmup
for (int i = 0; i < 10; i++) Solve(lines);

const int iterations = 10000;
var sw = Stopwatch.StartNew();
long answer = 0;
for (int i = 0; i < iterations; i++)
    answer = Solve(lines);
sw.Stop();

double nsPerOp = (double)sw.Elapsed.Ticks / iterations * 100;
Console.WriteLine($"Result: {answer} ({nsPerOp:F2} ns/op)");
