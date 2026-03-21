// Answer: 443839

namespace Problem30;

internal static class Program
{
    private static int F(int i)
    {
        int sum = 0;
        const int power = 5;
        string digits = i.ToString();
        foreach (char ch in digits)
        {
            int x = 1;
            for (int n = 0; n < power; n++) x *= (int)(ch - '0');
            sum += x;
        }
        return sum;
    }

    static long Solve()
    {
        int sum = 0;
        for (int i = 2; i < 1000000; i++)
            if (i == F(i)) sum += i;
        return sum;
    }

    static void Main() => Bench.Run(30, Solve);
}
