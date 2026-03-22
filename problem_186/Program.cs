// Answer: 2325629
using System;

namespace Problem186;

internal static class Program
{
    const int Users = 1000000;
    static int[] _parent = new int[Users];
    static int[] _sz = new int[Users];

    static void UfInit()
    {
        for (int i = 0; i < Users; i++) { _parent[i] = i; _sz[i] = 1; }
    }

    static int UfFind(int x)
    {
        while (_parent[x] != x) { _parent[x] = _parent[_parent[x]]; x = _parent[x]; }
        return x;
    }

    static void UfUnion(int a, int b)
    {
        a = UfFind(a); b = UfFind(b);
        if (a == b) return;
        if (_sz[a] < _sz[b]) { int t = a; a = b; b = t; }
        _parent[b] = a;
        _sz[a] += _sz[b];
    }

    static long Solve()
    {
        long[] rb = new long[55];
        for (int k = 1; k <= 55; k++)
        {
            long val = (100003L - 200003L * k + 300007L * (long)k * k * k) % 1000000;
            if (val < 0) val += 1000000;
            rb[k - 1] = val;
        }

        UfInit();
        int PM = 524287;
        int target = 990000;
        int consumed = 0;
        int rp = 0;
        int calls = 0;

        long NextVal()
        {
            long v;
            if (consumed < 55)
            {
                v = rb[consumed++];
            }
            else
            {
                int i24 = (rp + 55 - 24) % 55;
                int i55 = rp;
                v = (rb[i24] + rb[i55]) % 1000000;
                rb[rp] = v;
                rp = (rp + 1) % 55;
                consumed++;
            }
            return v;
        }

        while (true)
        {
            int caller = (int)NextVal();
            int called = (int)NextVal();
            if (caller == called) continue;

            calls++;
            UfUnion(caller, called);

            if (_sz[UfFind(PM)] >= target) return calls;
        }
    }

    static void Main() => Bench.Run(186, Solve);
}
