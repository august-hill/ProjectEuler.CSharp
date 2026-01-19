using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Problem28
{
    class Program
    {
        static void Main(string[] args)
        {
            const int N = 1001;
            Debug.Assert(N % 2 == 1, "N must be odd.");
            int[,] spiral = new int[N, N];

            //PrintArray(spiral);

            MakeSpiral(spiral);

            //PrintArray(spiral);

            SumDiagonals(spiral);
        }

        private static void SumDiagonals(int[,] spiral)
        {
            int sum = 0;
            for (int i = 0; i < spiral.GetLength(0); i++)
            {
                sum += spiral[i, i];
                sum += spiral[i, spiral.GetLength(0) - i - 1];
            }
            Console.WriteLine("sum of diagonals is {0}", sum - 1);
        }

        private static void PrintArray(int[,] spiral)
        {
            for (int i = 0; i < spiral.GetLength(0); i++)
            {
                for (int j = 0; j < spiral.GetLength(1); j++)
                {
                    Console.Write("{0:d2} ", spiral[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private enum Direction
        {
            Right,  // dj = +1, di = 0
            Down,   // dj = 0, di = +1
            Left,   // dj = -1, di = 0
            Up,     // dj = 0, di = -1
        }

        private static void SetAcceleration(Direction myDirection, out int di, out int dj)
        {
            di = dj = 0;
            switch (myDirection)
            {
                case Direction.Right:
                    dj = +1;
                    break;
                case Direction.Down:
                    di = +1;
                    break;
                case Direction.Left:
                    dj = -1;
                    break;
                case Direction.Up:
                    di = -1;
                    break;
            }
        }


        private static bool IsEmpty(int n)
        {
            return n == 0;
        }

        private static void MakeSpiral(int[,] spiral)
        {
            // Center of spiral...
            int i = spiral.GetLength(0) / 2;
            int j = spiral.GetLength(1) / 2;

            // Mark block...
            int n = 1;
            spiral[i, j] = n++;

            // Set initial direction...
            Direction myDirection = Direction.Right;

            // Accerate based on direction...
            int di = 0;
            int dj = 0;
            SetAcceleration(myDirection, out di, out dj);

            // Proceed to walk the spiral...
            int MaxN = spiral.Length;
            while (n <= MaxN)
            {
                // Accelerate in our direction...
                i += di;
                j += dj;

                // Mark the square...
                spiral[i, j] = n++;

                switch (myDirection)
                {
                    case Direction.Right:
                        if (IsEmpty(spiral[i + 1, j]))
                        {
                            myDirection = Clockwise(myDirection);
                            SetAcceleration(myDirection, out di, out dj);
                        }
                        break;
                    case Direction.Down:
                        if (IsEmpty(spiral[i, j - 1]))
                        {
                            myDirection = Clockwise(myDirection);
                            SetAcceleration(myDirection, out di, out dj);
                        }
                        break;
                    case Direction.Left:
                        if (IsEmpty(spiral[i - 1, j]))
                        {
                            myDirection = Clockwise(myDirection);
                            SetAcceleration(myDirection, out di, out dj);
                        }
                        break;
                    case Direction.Up:
                        if (IsEmpty(spiral[i, j + 1]))
                        {
                            myDirection = Clockwise(myDirection);
                            SetAcceleration(myDirection, out di, out dj);
                        }
                        break;
                }

            }
        }

        private static Direction Clockwise(Direction myDirection)
        {
            return (Direction)(((int)myDirection + 1) % 4);
        }

    }
}
