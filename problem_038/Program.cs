// Answer: 932718654
using System;

namespace Problem38;

internal static class Program
{
    private static long Pandigital(int p, int n)
    {
        string pandigital = "";
        for (int i = 1; i <= n; i++)
        {
            int a = p * i;
            pandigital += a.ToString();
        }
        if (pandigital.Length != 9) return -1;
        int[] digits = new int[10] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        for (int i = 0; i < pandigital.Length; i++)
            if (++digits[pandigital[i] - '0'] > 1) return -1;
        return Convert.ToInt64(pandigital);
    }

    static long Solve()
    {
        long largest = 0;
        for (int p = 1; p <= 999999999; p++)
        {
            for (int n = 1; n <= 10; n++)
            {
                long cp = Pandigital(p, n);
                if (cp > largest) largest = cp;
            }
        }
        return largest;
    }

    static void Main() => Bench.Run(38, Solve);
}
