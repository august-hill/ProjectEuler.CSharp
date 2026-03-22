// Answer: 20574308184277971
using System;

namespace Problem161;

internal static class Program
{
    const int R = 12;
    const int C = 9;
    const int NCells = R * C;
    const int Window = 2 * C + 1;

    static readonly int[,,] Shapes = {
        {{0,0},{0,1},{0,2}},
        {{0,0},{1,0},{2,0}},
        {{0,0},{0,1},{1,0}},
        {{0,0},{0,1},{1,1}},
        {{0,0},{1,0},{1,1}},
        {{0,0},{1,-1},{1,0}},
    };

    static long[]? _dpA;
    static long[]? _dpB;
    static bool _initialized;
    static long _answerCache;

    static long Solve()
    {
        if (_initialized) return _answerCache;
        _initialized = true;

        int states = 1 << Window;
        _dpA = new long[states];
        _dpB = new long[states];

        var curDp = _dpA;
        var nxtDp = _dpB;

        Array.Clear(curDp, 0, states);
        curDp[0] = 1;

        for (int pos = 0; pos < NCells; pos++)
        {
            int row = pos / C;
            int col = pos % C;

            Array.Clear(nxtDp, 0, states);

            for (int mask = 0; mask < states; mask++)
            {
                if (curDp[mask] == 0) continue;
                long ways = curDp[mask];

                if ((mask & 1) != 0)
                {
                    nxtDp[mask >> 1] += ways;
                    continue;
                }

                for (int s = 0; s < 6; s++)
                {
                    bool ok = true;
                    int[] offsets = new int[3];
                    for (int kk = 0; kk < 3; kk++)
                    {
                        int r2 = row + Shapes[s, kk, 0];
                        int c2 = col + Shapes[s, kk, 1];
                        if (r2 < 0 || r2 >= R || c2 < 0 || c2 >= C) { ok = false; break; }
                        int pos2 = r2 * C + c2;
                        int off = pos2 - pos;
                        if (off < 0 || off >= Window) { ok = false; break; }
                        offsets[kk] = off;
                    }
                    if (!ok) continue;

                    int newMask = mask;
                    bool conflict = false;
                    for (int kk = 0; kk < 3; kk++)
                    {
                        if ((newMask & (1 << offsets[kk])) != 0) { conflict = true; break; }
                        newMask |= (1 << offsets[kk]);
                    }
                    if (conflict) continue;

                    nxtDp[newMask >> 1] += ways;
                }
            }

            var tmp = curDp;
            curDp = nxtDp;
            nxtDp = tmp;
        }

        _answerCache = curDp[0];
        return _answerCache;
    }

    static void Main() => Bench.Run(161, Solve);
}
