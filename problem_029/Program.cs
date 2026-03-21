// Answer: 9183
using System.Collections.Generic;
using System.Numerics;

namespace Problem29;

internal static class Program
{
    static long Solve()
    {
        SortedSet<BigInteger> sequence = new SortedSet<BigInteger>();
        const int N = 100;
        for (int a = 2; a <= N; a++)
        {
            for (int b = 2; b <= N; b++)
            {
                BigInteger x = 1;
                for (int i = 0; i < b; i++) x *= a;
                sequence.Add(x);
            }
        }
        return sequence.Count;
    }

    static void Main() => Bench.Run(29, Solve);
}
