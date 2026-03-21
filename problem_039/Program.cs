// Answer: 840
using System.Collections.Generic;
using System.Linq;

namespace Problem39;

internal static class Program
{
    static long Solve()
    {
        Dictionary<int, int> solutions = new Dictionary<int, int>();
        for (int a = 1; a < 1000; a++)
        for (int b = 1; b < 1000; b++)
        for (int c = 1; c < 1000; c++)
        {
            if (a < b && b < c && (a * a) + (b * b) == (c * c))
            {
                int p = a + b + c;
                if (solutions.ContainsKey(p)) solutions[p]++;
                else solutions.Add(p, 1);
            }
        }

        return solutions.Where(s => s.Key <= 1000).OrderByDescending(s => s.Value).First().Key;
    }

    static void Main() => Bench.Run(39, Solve);
}
