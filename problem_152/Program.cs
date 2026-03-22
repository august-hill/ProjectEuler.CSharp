// Answer: 301
using System;

namespace Problem152;

internal static class Program
{
    static readonly int[] CandList = {2,3,4,5,6,7,8,9,10,12,13,14,15,16,18,20,21,24,27,28,
                                      30,32,35,36,39,40,42,45,48,52,54,56,60,63,64,65,70,72,80};
    static int _candCount;
    static (System.Int128 num, System.Int128 den)[] _invSq = Array.Empty<(System.Int128, System.Int128)>();
    static (System.Int128 num, System.Int128 den)[] _suffixSum = Array.Empty<(System.Int128, System.Int128)>();
    static int _resultCount;

    static System.Int128 Gcd128(System.Int128 a, System.Int128 b)
    {
        if (a < 0) a = -a;
        if (b < 0) b = -b;
        while (b != 0) { var t = b; b = a % b; a = t; }
        return a;
    }

    static (System.Int128 num, System.Int128 den) FracSub((System.Int128 num, System.Int128 den) a, (System.Int128 num, System.Int128 den) b)
    {
        var n = a.num * b.den - b.num * a.den;
        var d = a.den * b.den;
        var g = Gcd128(n, d);
        if (g == 0) return (0, 1);
        return (n / g, d / g);
    }

    static (System.Int128 num, System.Int128 den) FracAdd((System.Int128 num, System.Int128 den) a, (System.Int128 num, System.Int128 den) b)
    {
        var n = a.num * b.den + b.num * a.den;
        var d = a.den * b.den;
        var g = Gcd128(n, d);
        if (g == 0) return (0, 1);
        return (n / g, d / g);
    }

    static void Dfs(int idx, (System.Int128 num, System.Int128 den) remaining)
    {
        if (remaining.num == 0) { _resultCount++; return; }
        if (remaining.num < 0) return;
        if (idx >= _candCount) return;

        System.Int128 lhs = remaining.num * _suffixSum[idx].den;
        System.Int128 rhs = _suffixSum[idx].num * remaining.den;
        if (lhs > rhs) return;

        var newRem = FracSub(remaining, _invSq[idx]);
        if (newRem.num >= 0) Dfs(idx + 1, newRem);
        Dfs(idx + 1, remaining);
    }

    static long Solve()
    {
        _candCount = CandList.Length;
        _invSq = new (System.Int128, System.Int128)[_candCount + 1];
        _suffixSum = new (System.Int128, System.Int128)[_candCount + 1];

        for (int i = 0; i < _candCount; i++)
        {
            System.Int128 k = CandList[i];
            _invSq[i] = (1, k * k);
        }

        _suffixSum[_candCount] = (0, 1);
        for (int i = _candCount - 1; i >= 0; i--)
            _suffixSum[i] = FracAdd(_suffixSum[i + 1], _invSq[i]);

        _resultCount = 0;
        Dfs(0, (1, 2));
        return _resultCount;
    }

    static void Main() => Bench.Run(152, Solve);
}
