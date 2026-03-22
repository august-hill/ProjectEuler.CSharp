// Answer: 2906969179
using System;

namespace Problem125;

internal static class Program
{
    const long Limit = 100000000L;
    const int HashSize = 131072;
    const int HashMask = HashSize - 1;

    static bool IsPalindrome(long n)
    {
        if (n < 0) return false;
        long rev = 0, orig = n;
        while (n > 0) { rev = rev * 10 + n % 10; n /= 10; }
        return rev == orig;
    }

    static long Solve()
    {
        long[] hashTable = new long[HashSize];
        bool[] hashUsed = new bool[HashSize];

        long total = 0;

        for (long i = 1; i * i < Limit; i++)
        {
            long sum = i * i;
            for (long j = i + 1; sum + j * j < Limit; j++)
            {
                sum += j * j;
                if (IsPalindrome(sum))
                {
                    int h = (int)(sum & HashMask);
                    while (hashUsed[h])
                    {
                        if (hashTable[h] == sum) goto skip;
                        h = (h + 1) & HashMask;
                    }
                    hashTable[h] = sum;
                    hashUsed[h] = true;
                    total += sum;
                    skip:;
                }
            }
        }

        return total;
    }

    static void Main() => Bench.Run(125, Solve);
}
