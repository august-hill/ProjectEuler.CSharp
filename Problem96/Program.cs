using System;
using System.IO;

// Problem 96: Su Doku
// Answer: 24702

using System.Diagnostics;

static int GetPossible(int[,] board, int r, int c)
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

static int PopCount(int x)
{
    int count = 0;
    while (x != 0) { count++; x &= x - 1; }
    return count;
}

static bool SolveSudoku(int[,] board)
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

var fileLines = File.ReadAllLines("p096_sudoku.txt");

static int Solve(string[] lines)
{
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

// Warmup
for (int i = 0; i < 10; i++) Solve(fileLines);

const int iterations = 100;
var sw = Stopwatch.StartNew();
int result = 0;
for (int i = 0; i < iterations; i++)
    result = Solve(fileLines);
sw.Stop();

double nsPerOp = (double)sw.Elapsed.Ticks / iterations * 100;
Console.WriteLine($"Result: {result} ({nsPerOp:F2} ns/op)");
