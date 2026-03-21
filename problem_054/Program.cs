// Answer: 376
using System.IO;
using System.Collections.Generic;

namespace Problem54;

internal static class Program
{
    private static string[]? _cachedLines;

    private static string[] LoadLines()
    {
        if (_cachedLines != null) return _cachedLines;
        _cachedLines = File.ReadAllLines("poker.txt");
        return _cachedLines;
    }

    private static int ParseValue(char c) => c switch
    {
        >= '2' and <= '9' => c - '0',
        'T' => 10, 'J' => 11, 'Q' => 12, 'K' => 13, 'A' => 14,
        _ => 0
    };

    private static (int rank, int[] values) EvaluateHand(string[] cards)
    {
        int[] vals = new int[5];
        char[] suits = new char[5];
        for (int i = 0; i < 5; i++)
        {
            vals[i] = ParseValue(cards[i][0]);
            suits[i] = cards[i][1];
        }
        Array.Sort(vals);
        Array.Reverse(vals); // descending

        int[] freq = new int[15];
        foreach (int v in vals) freq[v]++;

        bool isFlush = suits[0] == suits[1] && suits[1] == suits[2] &&
                       suits[2] == suits[3] && suits[3] == suits[4];
        bool isStraight = vals[0] - vals[4] == 4 &&
                          vals[0] != vals[1] && vals[1] != vals[2] &&
                          vals[2] != vals[3] && vals[3] != vals[4];

        var fours = new List<int>();
        var trips = new List<int>();
        var pairs = new List<int>();
        var singles = new List<int>();

        for (int v = 14; v >= 2; v--)
        {
            switch (freq[v])
            {
                case 4: fours.Add(v); break;
                case 3: trips.Add(v); break;
                case 2: pairs.Add(v); break;
                case 1: singles.Add(v); break;
            }
        }

        var rankValues = new List<int>();
        int rank;

        if (isStraight && isFlush)
        {
            rank = vals[0] == 14 ? 10 : 9; // Royal or straight flush
            rankValues.Add(vals[0]);
        }
        else if (fours.Count == 1)
        {
            rank = 8;
            rankValues.Add(fours[0]);
            rankValues.AddRange(singles);
        }
        else if (trips.Count == 1 && pairs.Count == 1)
        {
            rank = 7;
            rankValues.Add(trips[0]);
            rankValues.Add(pairs[0]);
        }
        else if (isFlush)
        {
            rank = 6;
            rankValues.AddRange(vals);
        }
        else if (isStraight)
        {
            rank = 5;
            rankValues.Add(vals[0]);
        }
        else if (trips.Count == 1)
        {
            rank = 4;
            rankValues.Add(trips[0]);
            rankValues.AddRange(singles);
        }
        else if (pairs.Count == 2)
        {
            rank = 3;
            rankValues.AddRange(pairs);
            rankValues.AddRange(singles);
        }
        else if (pairs.Count == 1)
        {
            rank = 2;
            rankValues.Add(pairs[0]);
            rankValues.AddRange(singles);
        }
        else
        {
            rank = 1;
            rankValues.AddRange(singles);
        }

        return (rank, rankValues.ToArray());
    }

    private static bool Hand1Wins(string[] cards1, string[] cards2)
    {
        var (rank1, vals1) = EvaluateHand(cards1);
        var (rank2, vals2) = EvaluateHand(cards2);
        if (rank1 != rank2) return rank1 > rank2;
        int len = Math.Min(vals1.Length, vals2.Length);
        for (int i = 0; i < len; i++)
        {
            if (vals1[i] != vals2[i]) return vals1[i] > vals2[i];
        }
        return false;
    }

    static long Solve()
    {
        var lines = LoadLines();
        int wins = 0;
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] hand1 = parts[0..5];
            string[] hand2 = parts[5..10];
            if (Hand1Wins(hand1, hand2)) wins++;
        }
        return wins;
    }

    static void Main() => Bench.Run(54, Solve);
}
