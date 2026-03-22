// Answer: 1582
using System;

namespace Problem122;

internal static class Program
{
    const int MAXN = 200;
    static int[] _best = new int[MAXN + 1];

    static void Dfs(int[] chain, int len, int maxDepth)
    {
        int cur = chain[len - 1];
        if (cur > MAXN) return;

        if (_best[cur] > len - 1)
            _best[cur] = len - 1;

        if (len - 1 >= maxDepth) return;

        for (int i = len - 1; i >= 0; i--)
        {
            int next = cur + chain[i];
            if (next > MAXN) continue;
            if (next <= cur) continue;
            chain[len] = next;
            Dfs(chain, len + 1, maxDepth);
        }
    }

    static long Solve()
    {
        for (int i = 0; i <= MAXN; i++) _best[i] = 100;
        _best[1] = 0;

        int[] chain = new int[20];
        chain[0] = 1;

        for (int depth = 1; depth <= 12; depth++)
            Dfs(chain, 1, depth);

        int total = 0;
        for (int i = 1; i <= MAXN; i++) total += _best[i];
        return total;
    }

    static void Main() => Bench.Run(122, Solve);
}
