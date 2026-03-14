using System;
using System.Collections.Generic;

// Problem 61: Cyclical Figurate Numbers
// Answer: 28684

using System.Diagnostics;

static int Solve()
{
    // by_prefix[type][prefix] = list of values
    var byPrefix = new List<int>[6][];
    for (int s = 3; s <= 8; s++)
    {
        int idx = s - 3;
        byPrefix[idx] = new List<int>[100];
        for (int p = 0; p < 100; p++) byPrefix[idx][p] = new List<int>();

        for (int n = 1; ; n++)
        {
            int val = n * ((s - 2) * n - (s - 4)) / 2;
            if (val >= 10000) break;
            if (val >= 1000)
            {
                int prefix = val / 100;
                byPrefix[idx][prefix].Add(val);
            }
        }
    }

    int[] chain = new int[6];
    bool[] usedType = new bool[6];

    int Search(int depth)
    {
        if (depth == 6)
        {
            if (chain[5] % 100 == chain[0] / 100)
            {
                int sum = 0;
                for (int i = 0; i < 6; i++) sum += chain[i];
                return sum;
            }
            return 0;
        }

        for (int t = 0; t < 6; t++)
        {
            if (usedType[t]) continue;
            usedType[t] = true;

            if (depth == 0)
            {
                for (int prefix = 10; prefix < 100; prefix++)
                {
                    foreach (int val in byPrefix[t][prefix])
                    {
                        if (val % 100 < 10) continue;
                        chain[0] = val;
                        int result = Search(1);
                        if (result > 0) return result;
                    }
                }
            }
            else
            {
                int needed = chain[depth - 1] % 100;
                if (needed < 10) { usedType[t] = false; continue; }
                foreach (int val in byPrefix[t][needed])
                {
                    if (val % 100 < 10 && depth < 5) continue;
                    chain[depth] = val;
                    int result = Search(depth + 1);
                    if (result > 0) return result;
                }
            }

            usedType[t] = false;
        }
        return 0;
    }

    return Search(0);
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
