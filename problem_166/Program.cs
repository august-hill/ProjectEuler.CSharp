// Answer: 7130034
using System;

namespace Problem166;

internal static class Program
{
    static long Solve()
    {
        long count = 0;

        for (int S = 0; S <= 36; S++)
        {
            for (int a = 0; a <= 9; a++)
            {
                for (int b = 0; b <= 9; b++)
                {
                    for (int c = 0; c <= 9; c++)
                    {
                        int d = S - a - b - c;
                        if (d < 0 || d > 9) continue;

                        for (int e = 0; e <= 9; e++)
                        {
                            for (int f = 0; f <= 9; f++)
                            {
                                for (int i = 0; i <= 9; i++)
                                {
                                    int mVal = S - a - e - i;
                                    if (mVal < 0 || mVal > 9) continue;

                                    for (int j = 0; j <= 9; j++)
                                    {
                                        int n = S - b - f - j;
                                        if (n < 0 || n > 9) continue;

                                        int g = 2 * a + b + c + e + i - j - S;
                                        if (g < 0 || g > 9) continue;

                                        int h = 2 * S - 2 * a - b - c - 2 * e - f - i + j;
                                        if (h < 0 || h > 9) continue;

                                        int o = f + j - c;
                                        if (o < 0 || o > 9) continue;

                                        int k = 2 * S - 2 * a - b - c - e - f - i;
                                        if (k < 0 || k > 9) continue;

                                        int l = -S + 2 * a + b + c + e + f - j;
                                        if (l < 0 || l > 9) continue;

                                        int p = a + b + c + e + i - S;
                                        if (p < 0 || p > 9) continue;

                                        count++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        return count;
    }

    static void Main() => Bench.Run(166, Solve);
}
