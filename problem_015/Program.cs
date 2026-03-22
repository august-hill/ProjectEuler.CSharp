// Answer: 137846528640

namespace Problem15;

internal static class Program
{
    static long Solve()
    {
        // C(40, 20) computed without overflow by interleaving multiply/divide
        long result = 1;
        int n = 20;
        for (int i = 1; i <= n; i++)
        {
            result = result * (n + i) / i;
        }
        return result;
    }

    static void Main() => Bench.Run(15, Solve);
}
