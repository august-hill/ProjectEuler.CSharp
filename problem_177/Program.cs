// Answer: 129325
using System;

namespace Problem177;

internal static class Program
{
    static double[] _sinval = new double[181];
    static bool _initialized;

    static long Solve()
    {
        if (!_initialized)
        {
            for (int i = 0; i <= 180; i++)
                _sinval[i] = Math.Sin(i * Math.PI / 180.0);
            _initialized = true;
        }

        int count = 0;

        for (int P = 1; P <= 179; P++)
        {
            int S = 180 - P;
            for (int a2 = 1; a2 < S; a2++)
            {
                int b1 = S - a2;
                for (int b2 = 1; b2 < P; b2++)
                {
                    int c1 = P - b2;
                    for (int c2 = 1; c2 < S; c2++)
                    {
                        int d1 = S - c2;

                        double lhsPartial = _sinval[a2] * _sinval[b2] * _sinval[c2];
                        double rhsPartial = _sinval[b1] * _sinval[c1] * _sinval[d1];

                        for (int a1 = 1; a1 < P; a1++)
                        {
                            int d2 = P - a1;
                            if (a1 + a2 >= 180) continue;
                            if (b1 + b2 >= 180) continue;
                            if (c1 + c2 >= 180) continue;
                            if (d1 + d2 >= 180) continue;

                            double lhs = lhsPartial * _sinval[d2];
                            double rhs = rhsPartial * _sinval[a1];

                            if (Math.Abs(lhs - rhs) < 1e-8 * (lhs + rhs + 1e-15))
                            {
                                int[,] reps = {
                                    {a1,a2,b1,b2,c1,c2,d1,d2},
                                    {b1,b2,c1,c2,d1,d2,a1,a2},
                                    {c1,c2,d1,d2,a1,a2,b1,b2},
                                    {d1,d2,a1,a2,b1,b2,c1,c2},
                                    {a2,a1,d2,d1,c2,c1,b2,b1},
                                    {d2,d1,c2,c1,b2,b1,a2,a1},
                                    {c2,c1,b2,b1,a2,a1,d2,d1},
                                    {b2,b1,a2,a1,d2,d1,c2,c1}
                                };

                                int minIdx = 0;
                                for (int r = 1; r < 8; r++)
                                {
                                    for (int j = 0; j < 8; j++)
                                    {
                                        if (reps[r, j] < reps[minIdx, j]) { minIdx = r; break; }
                                        if (reps[r, j] > reps[minIdx, j]) break;
                                    }
                                }

                                if (minIdx == 0) count++;
                            }
                        }
                    }
                }
            }
        }

        return count;
    }

    static void Main() => Bench.Run(177, Solve);
}
