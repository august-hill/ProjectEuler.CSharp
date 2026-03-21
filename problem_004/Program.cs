// Answer: 906609

namespace Problem4;

internal static class Program
{
    private static bool IsPalindromic(int n)
    {
        var s = $"{n}";
        var start = 0;
        var end = s.Length - 1;
        while (s[start] == s[end])
        {
            start++;
            end--;
            if (start >= end)
            {
                return true;
            }
        }
        return false;
    }

    static long Solve()
    {
        var bigPalindrome = 0;

        for (int i = 999; i > 99; i--)
        {
            for (int j = 999; j > 99; j--)
            {
                int p = i * j;
                if (IsPalindromic(p))
                {
                    if (p > bigPalindrome)
                    {
                        bigPalindrome = p;
                    }
                }
            }
        }

        return bigPalindrome;
    }

    static void Main() => Bench.Run(4, Solve);
}
