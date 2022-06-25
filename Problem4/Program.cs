// Problem4
//
// Largest palindrome product
//
// A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
// Find the largest palindrome made from the product of two 3-digit numbers.

namespace Problem4
{
    class Program
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

        private static void Main()
        {
            var bigI = 0;
            var bigJ = 0;
            var bigPalindrome = 0;
            var timeTaken = new System.Diagnostics.Stopwatch();

            timeTaken.Start();
            for (int i = 999; i > 99; i--)
            {
                for (int j = 999; j > 99; j--)
                {
                    int p = i * j;
                    if (IsPalindromic(p))
                    {
                        if (p > bigPalindrome)
                        {
                            bigI = i;
                            bigJ = j;
                            bigPalindrome = p;
                        }
                    }
                }
            }
            timeTaken.Stop();

            Console.WriteLine($"{bigPalindrome} = {bigI} * {bigJ}, in {timeTaken.ElapsedMilliseconds} ms.");

        }
    }
}