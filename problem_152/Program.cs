// Answer: 301
using System;

namespace Problem152;

internal static class Program
{
    static readonly int[] CandList = {2,3,4,5,6,7,8,9,10,12,13,14,15,16,18,20,21,24,27,28,
                                      30,32,35,36,39,40,42,45,48,52,54,56,60,63,64,65,70,72,80};
    const int CandCount = 39;

    // LCM of all k^2 = 2^12 * 3^6 * 5^4 * 7^2 * 13^2
    const long Lcm = 2985984L * 625 * 49 * 169;

    static readonly long[] InvSqNum = new long[CandCount];
    static readonly long[] SuffixSum = new long[CandCount + 1];
    static int _resultCount;

    static void Dfs(int idx, long remaining)
    {
        if (remaining == 0) { _resultCount++; return; }
        if (remaining < 0) return;
        if (idx >= CandCount) return;
        if (remaining > SuffixSum[idx]) return;

        long newRem = remaining - InvSqNum[idx];
        if (newRem >= 0) Dfs(idx + 1, newRem);
        Dfs(idx + 1, remaining);
    }

    static long Solve()
    {
        for (int i = 0; i < CandCount; i++)
        {
            long k = CandList[i];
            InvSqNum[i] = Lcm / (k * k);
        }
        SuffixSum[CandCount] = 0;
        for (int i = CandCount - 1; i >= 0; i--)
            SuffixSum[i] = SuffixSum[i + 1] + InvSqNum[i];

        _resultCount = 0;
        Dfs(0, Lcm / 2);
        return _resultCount;
    }

    static void Main() => Bench.Run(152, Solve);
}
