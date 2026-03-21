// Answer: 31626
using System.Linq;
using System.Collections.Generic;

namespace Problem21;

internal static class Program
{
    static long Dp(long n)
    {
        long sum = 0;
        for (long i = 1; i < n; i++)
            if (n % i == 0) sum += i;
        return sum;
    }

    static long Solve()
    {
        SortedSet<long> amicable = new SortedSet<long>();
        for (long a = 1; a <= 10000; a++)
        {
            long b = Dp(a);
            if (Dp(b) == a && a != b)
            {
                amicable.Add(a);
                amicable.Add(b);
            }
        }
        return amicable.Sum();
    }

    static void Main() => Bench.Run(21, Solve);
}
