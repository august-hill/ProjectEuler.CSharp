using System;
using System.Collections.Generic;
using System.Linq;

// Problem 95: Amicable Chains
// Answer: 14316

using System.Diagnostics;

static int Solve()
{
    const int limit = 1_000_001;
    var sumDiv = new int[limit];
    for (int i = 0; i < limit; i++) sumDiv[i] = 1;
    sumDiv[0] = 0;
    sumDiv[1] = 0;

    for (int i = 2; i < limit; i++)
        for (int j = 2 * i; j < limit; j += i)
            sumDiv[j] += i;

    var visited = new bool[limit];
    int bestLen = 0;
    int bestMin = 0;

    for (int start = 2; start < limit; start++)
    {
        if (visited[start]) continue;

        var chain = new List<int>();
        var inChain = new HashSet<int>();
        int n = start;

        while (n > 0 && n < limit && !inChain.Contains(n))
        {
            inChain.Add(n);
            chain.Add(n);
            n = sumDiv[n];
        }

        if (n > 0 && n < limit && inChain.Contains(n))
        {
            int cycleStart = chain.IndexOf(n);
            int cycleLen = chain.Count - cycleStart;

            if (cycleLen > bestLen)
            {
                bestLen = cycleLen;
                bestMin = int.MaxValue;
                for (int i = cycleStart; i < chain.Count; i++)
                    if (chain[i] < bestMin) bestMin = chain[i];
            }
        }

        foreach (int v in chain)
            if (v < limit) visited[v] = true;
    }

    return bestMin;
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
