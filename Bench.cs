// Bench.cs - Shared benchmark utility for Project Euler C# solutions.
// Usage:
//   static long Solve() { /* return answer */ }
//   static void Main() => Bench.Run(60, Solve);
//
// Add to .csproj: <Compile Include="../Bench.cs" />

using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

public static class Bench
{
    // Optimization fence (volatile not supported on long in C#)
    private static long _sink;
    private static void Sink(long value) => Interlocked.Exchange(ref _sink, value);

    public static void Run(int problem, Func<long> solveFn)
    {
        // Cold start: first run, no warmup, no JIT
        var coldSw = Stopwatch.StartNew();
        Sink(solveFn());
        coldSw.Stop();
        long coldNs = coldSw.ElapsedTicks * 1_000_000_000L / Stopwatch.Frequency;
        Console.WriteLine($"COLDSTART|time_ns={coldNs}");

        // Warmup: 2 more runs
        for (int i = 0; i < 2; i++)
            Sink(solveFn());

        // Calibrate: time one run
        var sw = Stopwatch.StartNew();
        Sink(solveFn());
        sw.Stop();
        long calNs = sw.ElapsedTicks * 1_000_000_000L / Stopwatch.Frequency;

        int iters;
        if      (calNs < 1_000_000L)     iters = 1000;
        else if (calNs < 100_000_000L)   iters = 100;
        else if (calNs < 1_000_000_000L) iters = 10;
        else                             iters = 3;

        // Timed runs
        long[] times = new long[iters];
        long answer = 0;
        for (int i = 0; i < iters; i++)
        {
            sw.Restart();
            answer = solveFn();
            sw.Stop();
            times[i] = sw.ElapsedTicks * 1_000_000_000L / Stopwatch.Frequency;
        }

        // Median
        Array.Sort(times);
        long medianNs = times[iters / 2];

        Console.WriteLine(
            $"BENCHMARK|problem={problem:D3}|answer={answer}|time_ns={medianNs}|iterations={iters}");
    }
}
