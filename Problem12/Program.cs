using System.Diagnostics;

namespace Problem12;

internal static class Program
{
    private static long CountDivisors(long n)
    {
        long count = 0;
        var sqrtN = (long)Math.Sqrt(n);

        for (long i = 1; i <= sqrtN; i++)
        {
            if (n % i == 0)
            {
                if (i * i == n)
                    count++;
                else
                    count += 2;
            }
        }
        return count;
    }

    private static long Solve()
    {
        long n = 1;
        while (true)
        {
            long triangle = n * (n + 1) / 2;
            if (CountDivisors(triangle) > 500)
                return triangle;
            n++;
        }
    }

    private static void Main()
    {
        const int iterations = 10;

        Console.WriteLine("Problem 12: Highly Divisible Triangular Number");
        Console.WriteLine("===============================================");
        Console.WriteLine($"Iterations: {iterations}\n");

        // Warmup
        for (int i = 0; i < 10; i++)
            Solve();

        var stopwatch = Stopwatch.StartNew();
        long result = 0;
        for (int i = 0; i < iterations; i++)
            result = Solve();
        stopwatch.Stop();

        double msPerOp = stopwatch.Elapsed.TotalMilliseconds / iterations;
        Console.WriteLine($"Result: {result} ({msPerOp:F2} ms/op)");
    }
}
