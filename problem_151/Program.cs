// Answer: 464399
using System;

namespace Problem151;

internal static class Program
{
    static double[,,,]? _memo;
    static bool[,,,]? _visited;
    static bool _initialized;

    static void Init()
    {
        _memo = new double[2, 4, 8, 16];
        _visited = new bool[2, 4, 8, 16];
    }

    static double Expected(int a2, int a3, int a4, int a5)
    {
        int total = a2 + a3 + a4 + a5;
        if (total == 0) return 0.0;
        if (a2 == 0 && a3 == 0 && a4 == 0 && a5 == 1) return 0.0;

        if (_visited![a2, a3, a4, a5]) return _memo![a2, a3, a4, a5];
        _visited[a2, a3, a4, a5] = true;

        double single = (total == 1) ? 1.0 : 0.0;
        double result = single;

        if (a5 > 0) result += (double)a5 / total * Expected(a2, a3, a4, a5 - 1);
        if (a4 > 0) result += (double)a4 / total * Expected(a2, a3, a4 - 1, a5 + 1);
        if (a3 > 0) result += (double)a3 / total * Expected(a2, a3 - 1, a4 + 1, a5 + 1);
        if (a2 > 0) result += (double)a2 / total * Expected(a2 - 1, a3 + 1, a4 + 1, a5 + 1);

        _memo![a2, a3, a4, a5] = result;
        return result;
    }

    static long Solve()
    {
        if (!_initialized) { Init(); _initialized = true; }
        double result = Expected(1, 1, 1, 1);
        return (long)(result * 1000000 + 0.5);
    }

    static void Main() => Bench.Run(151, Solve);
}
