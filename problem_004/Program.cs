// Answer: 906609
using System;

namespace Problem4;

internal static class Program
{
    static long Solve()
    {
        // Generate 6-digit palindromes in descending order
        for (int a = 9; a >= 1; a--)
        {
            for (int b = 9; b >= 0; b--)
            {
                for (int c = 9; c >= 0; c--)
                {
                    int palindrome = 100001 * a + 10010 * b + 1100 * c;

                    for (int i = 999; i >= 100; i--)
                    {
                        if (i * i < palindrome) break;
                        if (palindrome % i == 0)
                        {
                            int j = palindrome / i;
                            if (j >= 100 && j <= 999) return palindrome;
                        }
                    }
                }
            }
        }
        return 0;
    }

    static void Main() => Bench.Run(4, Solve);
}
