// Answer: 303963552391

namespace Problem72;

internal static class Program
{
    static long Solve()
    {
        const int limit = 1_000_001;
        var phi = new int[limit];
        for (int i = 0; i < limit; i++) phi[i] = i;
        for (int i = 2; i < limit; i++)
        {
            if (phi[i] == i)
                for (int j = i; j < limit; j += i)
                    phi[j] -= phi[j] / i;
        }
        long total = 0;
        for (int i = 2; i < limit; i++) total += phi[i];
        return total;
    }

    static void Main() => Bench.Run(72, Solve);
}
