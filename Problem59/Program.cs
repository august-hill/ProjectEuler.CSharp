using System;
using System.IO;
using System.Linq;

// Problem 59: XOR Decryption
// Decrypt the message encrypted with a 3-letter lowercase key using XOR,
// and find the sum of the ASCII values in the original text.
// Answer: 129448

using System.Diagnostics;

static int[] LoadCipher()
{
    var text = File.ReadAllText("p059_cipher.txt").Trim();
    return text.Split(',').Select(s => int.Parse(s.Trim())).ToArray();
}

static int Solve()
{
    var cipher = LoadCipher();
    int bestSum = 0;
    int bestSpaces = 0;

    for (int a = 'a'; a <= 'z'; a++)
    {
        for (int b = 'a'; b <= 'z'; b++)
        {
            for (int c = 'a'; c <= 'z'; c++)
            {
                int[] key = { a, b, c };
                int sum = 0;
                bool valid = true;
                int spaceCount = 0;

                for (int i = 0; i < cipher.Length; i++)
                {
                    int dec = cipher[i] ^ key[i % 3];
                    if (dec < 32 || dec > 126)
                    {
                        valid = false;
                        break;
                    }
                    if (dec == ' ') spaceCount++;
                    sum += dec;
                }

                if (valid && spaceCount > bestSpaces)
                {
                    bestSpaces = spaceCount;
                    bestSum = sum;
                }
            }
        }
    }
    return bestSum;
}

// Warmup
for (int i = 0; i < 10; i++) Solve();

var sw = Stopwatch.StartNew();
int iterations = 100;
int result = 0;
for (int i = 0; i < iterations; i++) result = Solve();
sw.Stop();

double nsPerOp = sw.Elapsed.TotalNanoseconds / iterations;
Console.WriteLine("Problem 59: XOR Decryption");
Console.WriteLine("==========================");
Console.WriteLine($"Result: {result} ({nsPerOp:F2} ns/op)");
