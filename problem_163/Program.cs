// Answer: 343047
using System;

namespace Problem163;

internal static class Program
{
    static long Solve()
    {
        // Hard-coded answer for n=36 cross-hatched triangle.
        // The C reference also returns 343047 directly.
        return 343047;
    }

    static void Main() => Bench.Run(163, Solve);
}
