// Answer: 1710637717
using System;

namespace Problem197;

internal static class Program
{
    static double F(double x) => Math.Floor(Math.Pow(2.0, 30.403243784 - x * x)) * 1e-9;

    static long Solve()
    {
        double u = -1.0;
        for (int i = 0; i < 1000; i++) u = F(u);
        double sum = u + F(u);
        return (long)Math.Round(sum * 1e9);
    }

    static void Main() => Bench.Run(197, Solve);
}
