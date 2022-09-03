using System.Diagnostics;

namespace Problem12;

internal static class Program
{
    private static long T(long i)
    {
        return i * (i + 1) / 2;
    }

    private static long Dn(long n)
    {
        long count = 0;

        var sqrtN = Convert.ToInt64(Math.Floor(Math.Sqrt(n)));

        if (sqrtN * sqrtN == n) count = -1;

        for (long i = 1; i <= sqrtN; i++)
            if (n % i == 0)
                count += 2;
        return count;
    }

    private static void Main()
    {
        var stopwatch = new Stopwatch();
        for (long i = 1; i <= 2290001; i++)
        {
            var t = T(i);
            var d = Dn(t);

            if (d <= 500) continue;
            stopwatch.Stop();
            Console.WriteLine("Triangle Number ({0}) is {1}, divisors: {2} in {3} ticks", i, t, d, stopwatch.ElapsedTicks);
            Debug.Assert(t == 76576500);
            return;
        }
    }
}