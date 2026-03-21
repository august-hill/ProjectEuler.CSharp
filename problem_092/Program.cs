// Answer: 8581146

namespace Problem92;

internal static class Program
{
    private static int SquareOfDigits(int j)
    {
        int result = 0;
        foreach (var digit in j.ToString())
        {
            int value = digit - '0';
            result += value * value;
        }
        return result;
    }

    private static int NumberChain(int i)
    {
        int n = i;
        while (n != 1 && n != 89) n = SquareOfDigits(n);
        return n;
    }

    static long Solve()
    {
        int count = 0;
        for (int i = 1; i < 10000000; i++)
            if (NumberChain(i) == 89) count++;
        return count;
    }

    static void Main() => Bench.Run(92, Solve);
}
