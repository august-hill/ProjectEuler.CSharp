// Answer: 162
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Problem42;

internal static class Program
{
    private static List<string>? _cachedWords;
    private static List<string> LoadWords()
    {
        if (_cachedWords != null) return _cachedWords;
        _cachedWords = new List<string>();
        string pattern = @"""(\w+)"",?";
        Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
        using (StreamReader sr = new StreamReader(@"words.txt", true))
        {
            while (sr.Peek() >= 0)
            {
                string input = sr.ReadLine()!;
                MatchCollection matches = rgx.Matches(input);
                foreach (Match match in matches)
                    _cachedWords.Add(match.Groups[1].Value);
            }
        }
        return _cachedWords;
    }

    private static SortedSet<int> GenerateTriangleNumbers(int p)
    {
        SortedSet<int> tn = new SortedSet<int>();
        for (int n = 0; n < p; n++) tn.Add((n * (n + 1)) / 2);
        return tn;
    }

    private static int WordValue(string word)
    {
        int value = 0;
        foreach (char ch in word) value += ch - 'A' + 1;
        return value;
    }

    static long Solve()
    {
        List<string> Words = LoadWords();
        SortedSet<int> TriangleNumbers = GenerateTriangleNumbers(20);

        int count = 0;
        foreach (string word in Words)
        {
            if (TriangleNumbers.Contains(WordValue(word)))
                count++;
        }
        return count;
    }

    static void Main() => Bench.Run(42, Solve);
}
