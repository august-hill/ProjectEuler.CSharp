// Answer: 4640261571849533
using System;

namespace Problem185;

internal static class Program
{
    const int N = 16;
    const int NClues = 22;

    static readonly int[,] ClueDigits = new int[NClues, N];
    static readonly int[] ClueCorrect = new int[NClues];
    static readonly int[] Secret = new int[N];
    static bool _found;
    static long _answer;
    static bool _initialized;

    static void InitClues()
    {
        string[] gs = {
            "5616185650518293","3847439647293047","5855462940810587",
            "9742855507068353","4296849643607543","3174248439465858",
            "4513559094146117","7890971548908067","8157356344118483",
            "2615250744386899","8690095851526254","6375711915077050",
            "6913859173121360","6442889055042768","2321386104303845",
            "2326509471271448","5251583379644322","1748270476758276",
            "4895722652190306","3041631117224635","1841236454324589",
            "2659862637316867"
        };
        int[] cc = {2,1,3,3,3,1,2,3,1,2,3,1,1,2,0,2,2,3,1,3,3,2};
        for (int i = 0; i < NClues; i++)
        {
            for (int j = 0; j < N; j++) ClueDigits[i, j] = gs[i][j] - '0';
            ClueCorrect[i] = cc[i];
        }
    }

    static bool CheckPartial(int pos)
    {
        for (int c = 0; c < NClues; c++)
        {
            int matches = 0;
            for (int i = 0; i < pos; i++)
                if (Secret[i] == ClueDigits[c, i]) matches++;
            int remaining = N - pos;
            if (matches > ClueCorrect[c]) return false;
            if (matches + remaining < ClueCorrect[c]) return false;
        }
        return true;
    }

    static void Backtrack(int pos)
    {
        if (_found) return;
        if (pos == N)
        {
            for (int c = 0; c < NClues; c++)
            {
                int matches = 0;
                for (int i = 0; i < N; i++)
                    if (Secret[i] == ClueDigits[c, i]) matches++;
                if (matches != ClueCorrect[c]) return;
            }
            _found = true;
            _answer = 0;
            for (int i = 0; i < N; i++) _answer = _answer * 10 + Secret[i];
            return;
        }

        for (int d = 0; d <= 9; d++)
        {
            bool valid = true;
            for (int c = 0; c < NClues; c++)
            {
                if (ClueCorrect[c] == 0 && ClueDigits[c, pos] == d) { valid = false; break; }
            }
            if (!valid) continue;

            Secret[pos] = d;
            if (CheckPartial(pos + 1)) Backtrack(pos + 1);
            if (_found) return;
        }
    }

    static long Solve()
    {
        if (!_initialized) { InitClues(); _initialized = true; }

        _found = false;
        _answer = 0;
        Array.Clear(Secret, 0, N);
        Backtrack(0);
        return _answer;
    }

    static void Main() => Bench.Run(185, Solve);
}
