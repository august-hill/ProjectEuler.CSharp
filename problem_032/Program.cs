// Answer: 45228
using System.Collections.Generic;
using System.Linq;

namespace Problem32;

internal static class Program
{
    private static bool IsPandigital(string s)
    {
        bool[] flags = new bool[10] { true, false, false, false, false, false, false, false, false, false };
        foreach (char ch in s)
        {
            if (flags[(int)ch - '0']) return false;
            flags[(int)ch - '0'] = true;
        }
        return true;
    }

    static long Solve()
    {
        SortedSet<int> products = new SortedSet<int>();
        for (int i = 1; i < 9999; i++)
        {
            for (int j = i + 1; j < 9999; j++)
            {
                int k = i * j;
                string product = i.ToString() + j.ToString() + k.ToString();
                if (product.Length == 9 && IsPandigital(product))
                    products.Add(k);
            }
        }
        return products.Sum();
    }

    static void Main() => Bench.Run(32, Solve);
}
