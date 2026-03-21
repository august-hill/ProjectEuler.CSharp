// Answer: 518408346

namespace Problem94;

internal static class Program
{
    static long Solve()
    {
        long limit = 1_000_000_000L;
        long total = 0;
        {
            long aPrev = 1, aCurr = 5;
            while (true)
            {
                long perimeter = 3 * aCurr + 1;
                if (perimeter > limit) break;
                total += perimeter;
                long aNext = 14 * aCurr - aPrev - 4;
                aPrev = aCurr; aCurr = aNext;
            }
        }
        {
            long aPrev = 1, aCurr = 17;
            while (true)
            {
                long perimeter = 3 * aCurr - 1;
                if (perimeter > limit) break;
                total += perimeter;
                long aNext = 14 * aCurr - aPrev + 4;
                aPrev = aCurr; aCurr = aNext;
            }
        }
        return total;
    }

    static void Main() => Bench.Run(94, Solve);
}
