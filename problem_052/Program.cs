// Answer: 142857
using System;

namespace Problem52;

internal static class Program
{
    private static string DigitSignature(int n)
    {
        char[] chars = n.ToString().ToCharArray();
        Array.Sort(chars);
        return new string(chars);
    }

    static long Solve()
    {
        for (int x = 1; ; x++)
        {
            string sig = DigitSignature(x);
            bool matches = true;
            for (int m = 2; m <= 6; m++)
            {
                if (DigitSignature(x * m) != sig)
                {
                    matches = false;
                    break;
                }
            }
            if (matches) return x;
        }
    }

    static void Main() => Bench.Run(52, Solve);
}
