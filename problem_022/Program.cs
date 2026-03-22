// Answer: 871198282
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Problem22;

internal static class Program
{
    private static string[]? _cachedNames;
    private static string[] LoadNames()
    {
        if (_cachedNames != null) return _cachedNames;
        var nameList = new SortedList<string, int>();
        string pattern = @"""(\w+)"",?";
        Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
        using (StreamReader sr = new StreamReader(@"names.txt", true))
        {
            while (sr.Peek() >= 0)
            {
                string input = sr.ReadLine()!;
                MatchCollection matches = rgx.Matches(input);
                foreach (Match match in matches)
                    nameList.Add(match.Groups[1].Value, Av(match.Groups[1].Value));
            }
        }
        _cachedNames = nameList.Keys.ToArray();
        return _cachedNames;
    }

    static int Av(string name)
    {
        int sum = 0;
        foreach (int ch in name) sum += ch - 'A' + 1;
        return sum;
    }

    static long Solve()
    {
        var names = LoadNames();
        int total = 0;
        for (int i = 0; i < names.Length; i++)
            total += (i + 1) * Av(names[i]);
        return total;
    }

    static void Main() => Bench.Run(22, Solve);
}
