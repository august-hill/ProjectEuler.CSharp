// Answer: 24702
using System.IO;

namespace Problem96;

internal static class Program
{
    private static string[]? _cachedLines;
    private static string[] LoadLines()
    {
        if (_cachedLines != null) return _cachedLines;
        _cachedLines = File.ReadAllLines("p096_sudoku.txt");
        return _cachedLines;
    }

    private static int GetPossible(int[,] board, int r, int c)
    {
        int used = 0;
        for (int j = 0; j < 9; j++) used |= 1 << board[r, j];
        for (int i = 0; i < 9; i++) used |= 1 << board[i, c];
        int br = (r / 3) * 3, bc = (c / 3) * 3;
        for (int i = br; i < br + 3; i++)
            for (int j = bc; j < bc + 3; j++)
                used |= 1 << board[i, j];
        return ~used & 0x3FE;
    }

    private static int PopCount(int x)
    {
        int count = 0;
        while (x != 0) { count++; x &= x - 1; }
        return count;
    }

    private static bool SolveSudoku(int[,] board)
    {
        int minOpts = 10, bestR = -1, bestC = -1;
        for (int r = 0; r < 9; r++)
        for (int c = 0; c < 9; c++)
        {
            if (board[r, c] == 0)
            {
                int opts = PopCount(GetPossible(board, r, c));
                if (opts < minOpts)
                {
                    minOpts = opts; bestR = r; bestC = c;
                    if (opts == 1) goto found;
                }
            }
        }
        found:
        if (bestR == -1) return true;
        if (minOpts == 0) return false;
        int possible = GetPossible(board, bestR, bestC);
        for (int d = 1; d <= 9; d++)
        {
            if ((possible & (1 << d)) != 0)
            {
                board[bestR, bestC] = d;
                if (SolveSudoku(board)) return true;
                board[bestR, bestC] = 0;
            }
        }
        return false;
    }

    static long Solve()
    {
        var lines = LoadLines();
        int total = 0;
        for (int puzzle = 0; puzzle < 50; puzzle++)
        {
            int baseLine = puzzle * 10 + 1;
            var board = new int[9, 9];
            for (int r = 0; r < 9; r++)
                for (int c = 0; c < 9; c++)
                    board[r, c] = lines[baseLine + r][c] - '0';
            SolveSudoku(board);
            total += board[0, 0] * 100 + board[0, 1] * 10 + board[0, 2];
        }
        return total;
    }

    static void Main() => Bench.Run(96, Solve);
}
