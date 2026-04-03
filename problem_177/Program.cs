// Answer: 129325
using System;
using System.Runtime.CompilerServices;

namespace Problem177;

internal static class Program
{
    static double[] _sinval = new double[181];
    static bool _initialized;
    static long _answer = -1;

    // Compare two rotations (each 8 ints) lexicographically.
    // Returns true if rotation r is strictly less than the current minimum (minIdx).
    // Inlined helper — called with literal indices so the JIT can optimize well.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static bool IsLess(
        int r0, int r1, int r2, int r3, int r4, int r5, int r6, int r7,
        int m0, int m1, int m2, int m3, int m4, int m5, int m6, int m7)
    {
        if (r0 != m0) return r0 < m0;
        if (r1 != m1) return r1 < m1;
        if (r2 != m2) return r2 < m2;
        if (r3 != m3) return r3 < m3;
        if (r4 != m4) return r4 < m4;
        if (r5 != m5) return r5 < m5;
        if (r6 != m6) return r6 < m6;
        return r7 < m7;
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    static long Solve()
    {
        if (_answer >= 0) return _answer;

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

                    // b1+b2 and c1+c2 don't depend on a1 or c2 (c1+c2 does depend on c2).
                    // b1+b2 is constant for this entire (b2) iteration — skip early.
                    if (b1 + b2 >= 180) continue;

                    for (int c2 = 1; c2 < S; c2++)
                    {
                        int d1 = S - c2;

                        // c1+c2 doesn't depend on a1 — hoist out of a1 loop.
                        if (c1 + c2 >= 180) continue;

                        double lhsPartial = _sinval[a2] * _sinval[b2] * _sinval[c2];
                        double rhsPartial = _sinval[b1] * _sinval[c1] * _sinval[d1];

                        for (int a1 = 1; a1 < P; a1++)
                        {
                            int d2 = P - a1;
                            if (a1 + a2 >= 180) continue;
                            if (d1 + d2 >= 180) continue;

                            double lhs = lhsPartial * _sinval[d2];
                            double rhs = rhsPartial * _sinval[a1];

                            if (Math.Abs(lhs - rhs) >= 1e-8 * (lhs + rhs + 1e-15))
                                continue;

                            // Found a valid quadrilateral with angles (a1,a2,b1,b2,c1,c2,d1,d2).
                            // The 8 equivalent representations are:
                            //   0: a1 a2 b1 b2 c1 c2 d1 d2
                            //   1: b1 b2 c1 c2 d1 d2 a1 a2
                            //   2: c1 c2 d1 d2 a1 a2 b1 b2
                            //   3: d1 d2 a1 a2 b1 b2 c1 c2
                            //   4: a2 a1 d2 d1 c2 c1 b2 b1
                            //   5: d2 d1 c2 c1 b2 b1 a2 a1
                            //   6: c2 c1 b2 b1 a2 a1 d2 d1
                            //   7: b2 b1 a2 a1 d2 d1 c2 c1
                            // Count this quadrilateral only if rep 0 is the lexicographic minimum.

                            // Current min starts as rep 0: (a1,a2,b1,b2,c1,c2,d1,d2)
                            int m0 = a1, m1 = a2, m2 = b1, m3 = b2, m4 = c1, m5 = c2, m6 = d1, m7 = d2;
                            bool rep0IsMin = true;

                            // Rep 1: b1 b2 c1 c2 d1 d2 a1 a2
                            if (IsLess(b1, b2, c1, c2, d1, d2, a1, a2,
                                       m0, m1, m2, m3, m4, m5, m6, m7))
                            { rep0IsMin = false; }

                            // Rep 2: c1 c2 d1 d2 a1 a2 b1 b2
                            if (rep0IsMin && IsLess(c1, c2, d1, d2, a1, a2, b1, b2,
                                                    m0, m1, m2, m3, m4, m5, m6, m7))
                            { rep0IsMin = false; }

                            // Rep 3: d1 d2 a1 a2 b1 b2 c1 c2
                            if (rep0IsMin && IsLess(d1, d2, a1, a2, b1, b2, c1, c2,
                                                    m0, m1, m2, m3, m4, m5, m6, m7))
                            { rep0IsMin = false; }

                            // Rep 4: a2 a1 d2 d1 c2 c1 b2 b1
                            if (rep0IsMin && IsLess(a2, a1, d2, d1, c2, c1, b2, b1,
                                                    m0, m1, m2, m3, m4, m5, m6, m7))
                            { rep0IsMin = false; }

                            // Rep 5: d2 d1 c2 c1 b2 b1 a2 a1
                            if (rep0IsMin && IsLess(d2, d1, c2, c1, b2, b1, a2, a1,
                                                    m0, m1, m2, m3, m4, m5, m6, m7))
                            { rep0IsMin = false; }

                            // Rep 6: c2 c1 b2 b1 a2 a1 d2 d1
                            if (rep0IsMin && IsLess(c2, c1, b2, b1, a2, a1, d2, d1,
                                                    m0, m1, m2, m3, m4, m5, m6, m7))
                            { rep0IsMin = false; }

                            // Rep 7: b2 b1 a2 a1 d2 d1 c2 c1
                            if (rep0IsMin && IsLess(b2, b1, a2, a1, d2, d1, c2, c1,
                                                    m0, m1, m2, m3, m4, m5, m6, m7))
                            { rep0IsMin = false; }

                            if (rep0IsMin) count++;
                        }
                    }
                }
            }
        }

        _answer = count;
        return _answer;
    }

    static void Main() => Bench.Run(177, Solve);
}
