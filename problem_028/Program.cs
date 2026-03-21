// Answer: 669171001
using System;
using System.Diagnostics;

namespace Problem28;

internal static class Program
{
    private enum Direction { Right, Down, Left, Up }

    private static void SetAcceleration(Direction myDirection, out int di, out int dj)
    {
        di = dj = 0;
        switch (myDirection)
        {
            case Direction.Right: dj = +1; break;
            case Direction.Down: di = +1; break;
            case Direction.Left: dj = -1; break;
            case Direction.Up: di = -1; break;
        }
    }

    private static bool IsEmpty(int n) => n == 0;

    private static Direction Clockwise(Direction myDirection) =>
        (Direction)(((int)myDirection + 1) % 4);

    private static void MakeSpiral(int[,] spiral)
    {
        int i = spiral.GetLength(0) / 2;
        int j = spiral.GetLength(1) / 2;
        int n = 1;
        spiral[i, j] = n++;
        Direction myDirection = Direction.Right;
        SetAcceleration(myDirection, out int di, out int dj);

        int MaxN = spiral.Length;
        while (n <= MaxN)
        {
            i += di; j += dj;
            spiral[i, j] = n++;
            switch (myDirection)
            {
                case Direction.Right:
                    if (IsEmpty(spiral[i + 1, j])) { myDirection = Clockwise(myDirection); SetAcceleration(myDirection, out di, out dj); }
                    break;
                case Direction.Down:
                    if (IsEmpty(spiral[i, j - 1])) { myDirection = Clockwise(myDirection); SetAcceleration(myDirection, out di, out dj); }
                    break;
                case Direction.Left:
                    if (IsEmpty(spiral[i - 1, j])) { myDirection = Clockwise(myDirection); SetAcceleration(myDirection, out di, out dj); }
                    break;
                case Direction.Up:
                    if (IsEmpty(spiral[i, j + 1])) { myDirection = Clockwise(myDirection); SetAcceleration(myDirection, out di, out dj); }
                    break;
            }
        }
    }

    static long Solve()
    {
        const int N = 1001;
        Debug.Assert(N % 2 == 1, "N must be odd.");
        int[,] spiral = new int[N, N];
        MakeSpiral(spiral);

        int sum = 0;
        for (int i = 0; i < spiral.GetLength(0); i++)
        {
            sum += spiral[i, i];
            sum += spiral[i, spiral.GetLength(0) - i - 1];
        }
        return sum - 1;
    }

    static void Main() => Bench.Run(28, Solve);
}
