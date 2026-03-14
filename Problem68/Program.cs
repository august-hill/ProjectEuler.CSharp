using System;
using System.Collections.Generic;
using System.Linq;

// Problem 68: Magic 5-gon Ring
// Find the maximum 16-digit string for a "magic" 5-gon ring.
// Answer: 6531031914842725

using System.Diagnostics;

static bool NextPermutation(int[] arr)
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
        // outer = perm[0..4], inner = perm[5..9]
        int target = perm[0] + perm[5] + perm[6];
        bool valid = true;
        for (int i = 1; i < 5; i++)
        {
            if (perm[i] + perm[5 + i] + perm[5 + (i + 1) % 5] != target)
            {
                valid = false;
                break;
            }
        }

        if (valid)
        {
            // Find line with smallest outer node
            int minIdx = 0;
            for (int i = 1; i < 5; i++)
            {
                if (perm[i] < perm[minIdx]) minIdx = i;
            }

            // Build digit sequence
            var digits = new List<int>(15);
            for (int k = 0; k < 5; k++)
            {
                int idx = (minIdx + k) % 5;
                digits.Add(perm[idx]);
                digits.Add(perm[5 + idx]);
                digits.Add(perm[5 + (idx + 1) % 5]);
            }

            // Count total digit characters
            int totalDigits = digits.Sum(d => d >= 10 ? 2 : 1);
            if (totalDigits == 16)
            {
                long num = 0;
                foreach (int d in digits)
                {
                    if (d >= 10)
                        num = num * 100 + d;
                    else
                        num = num * 10 + d;
                }
                if (num > best) best = num;
            }
        }
    } while (NextPermutation(perm));

    return best;
}

// Warmup
for (int i = 0; i < 10; i++) Solve();

var sw = Stopwatch.StartNew();
int iterations = 10;
long result = 0;
for (int i = 0; i < iterations; i++) result = Solve();
sw.Stop();

double nsPerOp = sw.Elapsed.TotalNanoseconds / iterations;
Console.WriteLine("Problem 68: Magic 5-gon Ring");
Console.WriteLine("============================");
Console.WriteLine($"Result: {result} ({nsPerOp:F2} ns/op)");
