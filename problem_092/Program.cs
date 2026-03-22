// Answer: 8581146

namespace Problem92;

internal static class Program
{
    private static int SquareDigitSum(int n)
    {
        int sum = 0;
        while (n > 0)
        {
            int digit = n % 10;
            sum += digit * digit;
            n /= 10;
        }
        return sum;
    }

    static long Solve()
    {
        // Cache for small numbers (max square digit sum for 7 digits: 7 * 81 = 567)
        byte[] cache = new byte[568];

        int count = 0;
        for (int n = 1; n < 10000000; n++)
        {
            int chain = n;
            while (true)
            {
                if (chain == 1) break;
                if (chain == 89) { count++; break; }
                if (chain < 568 && cache[chain] != 0)
                {
                    if (cache[chain] == 89) count++;
                    break;
                }
                chain = SquareDigitSum(chain);
            }

            if (n < 568)
            {
                if (chain == 1 || (chain < 568 && cache[chain] == 1))
                    cache[n] = 1;
                else
                    cache[n] = 89;
            }
        }
        return count;
    }

    static void Main() => Bench.Run(92, Solve);
}
