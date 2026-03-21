// Answer: 2783915460
using System;
using System.Collections.Generic;

namespace Problem24;

internal static class Program
{
    private static string digits = "0123456789";
    private static List<string> permutation = new List<string>();

    private static void f(string digits, string prefix)
    {
        if (digits.Length == 2)
        {
            permutation.Add(prefix + digits);
            permutation.Add(prefix + digits[1] + digits[0]);
            return;
        }
        for (int i = 0; i < digits.Length; i++)
        {
            string temp_prefix = prefix + digits[i];
            string temp_digits = digits.Remove(i, 1);
            f(temp_digits, temp_prefix);
        }
    }

    static long Solve()
    {
        permutation.Clear();
        f(digits, "");
        return Convert.ToInt64(permutation[999999]);
    }

    static void Main() => Bench.Run(24, Solve);
}
