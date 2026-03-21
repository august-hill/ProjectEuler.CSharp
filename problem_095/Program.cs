// Answer: 14316

namespace Problem95;

internal static class Program
{
    private static int[]? _cachedSumDiv;

    private static void InitSieve()
    {
        const int limit = 1_000_001;
        _cachedSumDiv = new int[limit];
        for (int i = 0; i < limit; i++) _cachedSumDiv[i] = 1;
        _cachedSumDiv[0] = 0; _cachedSumDiv[1] = 0;
        for (int i = 2; i < limit; i++)
            for (int j = 2 * i; j < limit; j += i)
                _cachedSumDiv[j] += i;
    }

    static long Solve()
    {
        const int limit = 1_000_001;
        if (_cachedSumDiv == null) InitSieve();
        var sumDiv = _cachedSumDiv!;

        var visited = new bool[limit];
        var inChain = new bool[limit];
        var chain = new int[10000];
        int bestLen = 0;
        int bestMin = 0;

        for (int start = 2; start < limit; start++)
        {
            if (visited[start]) continue;
            int chainLen = 0;
            int n = start;
            while (n > 0 && n < limit && !inChain[n])
            {
                inChain[n] = true;
                chain[chainLen++] = n;
                n = sumDiv[n];
            }
            if (n > 0 && n < limit && inChain[n])
            {
                int cycleStart = 0;
                for (int i = 0; i < chainLen; i++)
                    if (chain[i] == n) { cycleStart = i; break; }
                int cycleLen = chainLen - cycleStart;
                if (cycleLen > bestLen)
                {
                    bestLen = cycleLen;
                    bestMin = int.MaxValue;
                    for (int i = cycleStart; i < chainLen; i++)
                        if (chain[i] < bestMin) bestMin = chain[i];
                }
            }
            for (int i = 0; i < chainLen; i++)
            {
                if (chain[i] < limit)
                {
                    visited[chain[i]] = true;
                    inChain[chain[i]] = false;
                }
            }
        }
        return bestMin;
    }

    static void Main() => Bench.Run(95, Solve);
}
