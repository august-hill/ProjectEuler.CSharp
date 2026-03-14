using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Problem 98: Anagramic Squares
// Answer: 18769

using System.Diagnostics;

var fileData = File.ReadAllText("p098_words.txt");

static long Solve(string data)
{
    var words = data.Split(',').Select(w => w.Trim('"').Trim()).Where(w => w.Length > 0).ToArray();

    var anagramGroups = new Dictionary<string, List<string>>();
    foreach (var word in words)
    {
        var key = new string(word.OrderBy(c => c).ToArray());
        if (!anagramGroups.ContainsKey(key)) anagramGroups[key] = new List<string>();
        anagramGroups[key].Add(word);
    }

    long best = 0;

    foreach (var group in anagramGroups.Values)
    {
        if (group.Count < 2) continue;
        int wlen = group[0].Length;

        long loSq = 1;
        for (int k = 1; k < wlen; k++) loSq *= 10;
        long hiSq = loSq * 10 - 1;
        long lo = (long)Math.Ceiling(Math.Sqrt(loSq));
        long hi = (long)Math.Floor(Math.Sqrt(hiSq));

        var squares = new List<long>();
        for (long s = lo; s <= hi; s++) squares.Add(s * s);

        for (int i = 0; i < group.Count; i++)
        for (int j = i + 1; j < group.Count; j++)
        {
            var w1 = group[i];
            var w2 = group[j];

            foreach (long sq in squares)
            {
                var letterToDigit = new int[26];
                var digitToLetter = new int[10];
                Array.Fill(letterToDigit, -1);
                Array.Fill(digitToLetter, -1);

                var digits = sq.ToString().Select(c => c - '0').ToArray();
                if (digits.Length != wlen) continue;

                bool valid = true;
                for (int k = 0; k < wlen; k++)
                {
                    int li = w1[k] - 'A';
                    int di = digits[k];
                    if (letterToDigit[li] == -1 && digitToLetter[di] == -1)
                    {
                        letterToDigit[li] = di;
                        digitToLetter[di] = li;
                    }
                    else if (letterToDigit[li] != di || digitToLetter[di] != li)
                    {
                        valid = false; break;
                    }
                }
                if (!valid) continue;

                long num2 = 0;
                for (int k = 0; k < wlen; k++)
                {
                    int li = w2[k] - 'A';
                    if (letterToDigit[li] == -1) { valid = false; break; }
                    num2 = num2 * 10 + letterToDigit[li];
                }
                if (!valid) continue;
                if (letterToDigit[w2[0] - 'A'] == 0) continue;

                long root = (long)Math.Round(Math.Sqrt(num2));
                if (root * root == num2)
                {
                    long mx = Math.Max(sq, num2);
                    if (mx > best) best = mx;
                }
            }
        }
    }

    return best;
}

// Warmup
for (int i = 0; i < 10; i++) Solve(fileData);

const int iterations = 10;
var sw = Stopwatch.StartNew();
long result = 0;
for (int i = 0; i < iterations; i++)
    result = Solve(fileData);
sw.Stop();

double nsPerOp = (double)sw.Elapsed.Ticks / iterations * 100;
Console.WriteLine($"Result: {result} ({nsPerOp:F2} ns/op)");
