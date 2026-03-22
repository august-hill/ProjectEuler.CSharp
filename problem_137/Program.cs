// Answer: 1120149658760
using System;

namespace Problem137;

internal static class Program
{
    static long Solve()
    {
        long[] fib = new long[65];
        fib[1] = 1; fib[2] = 1;
        for (int i = 3; i <= 62; i++)
            fib[i] = fib[i - 1] + fib[i - 2];
        return fib[30] * fib[31];
    }

    static void Main() => Bench.Run(137, Solve);
}
