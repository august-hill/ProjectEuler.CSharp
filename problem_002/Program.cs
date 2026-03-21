// Answer: 4613732

namespace Problem2;

internal static class Program
{
    static long Solve()
    {
        const int upperBound = 4_000_000;
        var priorFibonacci = 0;
        var currentFibonacci = 1;
        var sum = 0;

        while (true)
        {
            var nextFibonacci = priorFibonacci + currentFibonacci;
            if (nextFibonacci > upperBound) break;
            if (nextFibonacci % 2 == 0) sum += nextFibonacci;
            priorFibonacci = currentFibonacci;
            currentFibonacci = nextFibonacci;
        }

        return sum;
    }

    static void Main() => Bench.Run(2, Solve);
}
