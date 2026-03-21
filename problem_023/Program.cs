// Answer: 4179871
using System.Collections.Generic;

namespace Problem23;

internal static class Program
{
    static long SumProperDivisors(long n)
    {
        long sum = 0;
        for (long i = 1; i < n; i++)
            if (n % i == 0) sum += i;
        return sum;
    }

    static bool IsAbundant(long n) => SumProperDivisors(n) > n;

    const int MAX_ABUNDANT = 28123;

    static long Solve()
    {
        SortedSet<int> NL = new SortedSet<int>();
        List<int> ABL = new List<int>();

        for (int i = 1; i <= MAX_ABUNDANT; i++)
        {
            NL.Add(i);
            if (IsAbundant(i)) ABL.Add(i);
        }

        for (int i = 0; i < ABL.Count; i++)
            for (int j = 0; j < ABL.Count; j++)
                NL.Remove(ABL[i] + ABL[j]);

        long sum = 0;
        foreach (int item in NL) sum += item;
        return sum;
    }

    static void Main() => Bench.Run(23, Solve);
}
