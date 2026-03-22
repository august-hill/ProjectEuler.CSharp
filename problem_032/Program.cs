// Answer: 45228
using System.Collections.Generic;
using System.Linq;

namespace Problem32;

internal static class Program
{
    private static bool IsPandigital(int a, int b, int c)
    {
        int[] digits = new int[10];
        digits[0] = 1; // 0 not allowed
        int count = 0;

        foreach (int n in new[] { a, b, c })
        {
            int v = n;
            while (v > 0)
            {
                int d = v % 10;
                if (d == 0 || digits[d] != 0) return false;
                digits[d] = 1;
                count++;
                v /= 10;
            }
        }
        return count == 9;
    }

    static long Solve()
    {
        HashSet<int> products = new HashSet<int>();

        // For a * b = c to be 1-9 pandigital:
        // digits(a) + digits(b) + digits(c) = 9
        // If a is 1 digit, b must be 4 digits (c will be 4 digits)
        // If a is 2 digits, b must be 3 digits (c will be 4 digits)
        for (int a = 1; a < 100; a++)
        {
            int start = (a < 10) ? 1000 : 100;
            int end = (a < 10) ? 9999 : 999;

            for (int b = start; b <= end; b++)
            {
                int c = a * b;
                if (IsPandigital(a, b, c))
                    products.Add(c);
            }
        }

        return products.Sum();
    }

    static void Main() => Bench.Run(32, Solve);
}
