// Answer: 129448
using System;
using System.IO;
using System.Linq;

namespace Problem59;

internal static class Program
{
    private static int[]? _cachedCipher;
    private static int[] LoadCipher()
    {
        if (_cachedCipher != null) return _cachedCipher;
        var text = File.ReadAllText("p059_cipher.txt").Trim();
        _cachedCipher = text.Split(',').Select(s => int.Parse(s.Trim())).ToArray();
        return _cachedCipher;
    }

    static long Solve()
    {
        var cipher = LoadCipher();
        int bestSum = 0;
        int bestSpaces = 0;

        for (int a = 'a'; a <= 'z'; a++)
        for (int b = 'a'; b <= 'z'; b++)
        for (int c = 'a'; c <= 'z'; c++)
        {
            int[] key = { a, b, c };
            int sum = 0;
            bool valid = true;
            int spaceCount = 0;

            for (int i = 0; i < cipher.Length; i++)
            {
                int dec = cipher[i] ^ key[i % 3];
                if (dec < 32 || dec > 126) { valid = false; break; }
                if (dec == ' ') spaceCount++;
                sum += dec;
            }

            if (valid && spaceCount > bestSpaces)
            {
                bestSpaces = spaceCount;
                bestSum = sum;
            }
        }
        return bestSum;
    }

    static void Main() => Bench.Run(59, Solve);
}
