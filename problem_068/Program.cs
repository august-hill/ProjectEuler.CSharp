// Answer: 6531031914842725
using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem68;

internal static class Program
{
    private static bool NextPermutation(int[] arr)
    {
        int n = arr.Length;
        int i = n - 1;
        while (i > 0 && arr[i - 1] >= arr[i]) i--;
        if (i == 0) return false;
        int j = n - 1;
        while (arr[j] <= arr[i - 1]) j--;
        (arr[i - 1], arr[j]) = (arr[j], arr[i - 1]);
        Array.Reverse(arr, i, n - i);
        return true;
    }

    static long Solve()
    {
        int[] perm = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        long best = 0;
        do
        {
            int target = perm[0] + perm[5] + perm[6];
            bool valid = true;
            for (int i = 1; i < 5; i++)
            {
                if (perm[i] + perm[5 + i] + perm[5 + (i + 1) % 5] != target)
                { valid = false; break; }
            }
            if (valid)
            {
                int minIdx = 0;
                for (int i = 1; i < 5; i++)
                    if (perm[i] < perm[minIdx]) minIdx = i;
                var digits = new List<int>(15);
                for (int k = 0; k < 5; k++)
                {
                    int idx = (minIdx + k) % 5;
                    digits.Add(perm[idx]);
                    digits.Add(perm[5 + idx]);
                    digits.Add(perm[5 + (idx + 1) % 5]);
                }
                int totalDigits = digits.Sum(d => d >= 10 ? 2 : 1);
                if (totalDigits == 16)
                {
                    long num = 0;
                    foreach (int d in digits)
                    {
                        if (d >= 10) num = num * 100 + d;
                        else num = num * 10 + d;
                    }
                    if (num > best) best = num;
                }
            }
        } while (NextPermutation(perm));
        return best;
    }

    static void Main() => Bench.Run(68, Solve);
}
