// Answer: 14234

namespace Problem91;

internal static class Program
{
    static long Solve()
    {
        const int N = 50;
        int count = 0;
        for (int x1 = 0; x1 <= N; x1++)
        for (int y1 = 0; y1 <= N; y1++)
        {
            if (x1 == 0 && y1 == 0) continue;
            for (int x2 = 0; x2 <= N; x2++)
            for (int y2 = 0; y2 <= N; y2++)
            {
                if (x2 == 0 && y2 == 0) continue;
                if (x1 == x2 && y1 == y2) continue;
                if (x1 > x2 || (x1 == x2 && y1 > y2)) continue;
                int dotO = x1 * x2 + y1 * y2;
                int dotP = (-x1) * (x2 - x1) + (-y1) * (y2 - y1);
                int dotQ = (-x2) * (x1 - x2) + (-y2) * (y1 - y2);
                if (dotO == 0 || dotP == 0 || dotQ == 0) count++;
            }
        }
        return count;
    }

    static void Main() => Bench.Run(91, Solve);
}
