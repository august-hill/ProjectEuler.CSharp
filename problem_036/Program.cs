// Answer: 872187

namespace Problem36;

internal static class Program
{
    private static bool IsPalindromic(string s)
    {
        int start = 0;
        int end = s.Length - 1;
        while (s[start] == s[end])
        {
            start++; end--;
            if (start >= end) return true;
        }
        return false;
    }

    private static string ToBinary(int n)
    {
        string s = "";
        do { s += (n % 2) == 0 ? "0" : "1"; n >>= 1; } while (n != 0);
        return s;
    }

    static long Solve()
    {
        int sum = 0;
        for (int n = 1; n < 1000000; n++)
        {
            if (IsPalindromic(n.ToString()) && IsPalindromic(ToBinary(n)))
                sum += n;
        }
        return sum;
    }

    static void Main() => Bench.Run(36, Solve);
}
