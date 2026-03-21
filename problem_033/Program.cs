// Answer: 100

namespace Problem33;

internal static class Program
{
    static long Solve()
    {
        int numProduct = 1;
        int denProduct = 1;

        for (int a = 1; a <= 9; a++)
        for (int b = 1; b <= 9; b++)
        for (int c = 1; c <= 9; c++)
        for (int d = 1; d <= 9; d++)
        {
            double x = (double)((a * 10) + b) / (double)((c * 10) + d);
            if (x >= 1.0D) continue;

            bool found = false;
            if (b == c && (double)a / d == x) found = true;
            if (a == d && (double)b / c == x) found = true;
            if (a == c && (double)b / d == x) found = true;
            if (b == d && (double)a / c == x) found = true;

            if (found)
            {
                numProduct *= (a * 10 + b);
                denProduct *= (c * 10 + d);
            }
        }

        // Simplify fraction
        int gcd = Gcd(denProduct, numProduct);
        return denProduct / gcd;
    }

    static int Gcd(int a, int b)
    {
        while (b != 0) { int t = b; b = a % b; a = t; }
        return a;
    }

    static void Main() => Bench.Run(33, Solve);
}
