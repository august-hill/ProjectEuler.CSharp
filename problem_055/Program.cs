// Answer: 249
using System.Numerics;

namespace Problem55;

internal static class Program
{
    private static BigInteger Reverse(BigInteger n)
    {
        BigInteger rev = 0;
        while (n > 0)
        {
            rev = rev * 10 + n % 10;
            n /= 10;
        }
        return rev;
    }

    private static bool IsPalindrome(BigInteger n)
    {
        return n == Reverse(n);
    }

    private static bool IsLychrel(int n)
    {
        BigInteger val = n;
        for (int i = 0; i < 50; i++)
        {
            val += Reverse(val);
            if (IsPalindrome(val)) return false;
        }
        return true;
    }

    static long Solve()
    {
        int count = 0;
        for (int n = 1; n < 10000; n++)
        {
            if (IsLychrel(n)) count++;
        }
        return count;
    }

    static void Main() => Bench.Run(55, Solve);
}
