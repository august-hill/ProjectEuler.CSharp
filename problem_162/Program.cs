// Answer: 4390901987045498642 (decimal of hex 3D58725572C62302)
using System;

namespace Problem162;

internal static class Program
{
    static long Solve()
    {
        System.Int128 total = 0;
        System.Int128 pow16 = 1, pow15 = 1, pow14 = 1, pow13 = 1;

        for (int k = 1; k <= 16; k++)
        {
            pow16 *= 16;
            pow15 *= 15;
            pow14 *= 14;
            pow13 *= 13;

            System.Int128 t16km1 = pow16 / 16;
            System.Int128 t15km1 = pow15 / 15;
            System.Int128 t14km1 = pow14 / 14;

            System.Int128 fk = 15 * t16km1 - pow15 - 2 * 14 * t15km1 + 2 * pow14 + 13 * t14km1 - pow13;
            total += fk;
        }

        return (long)total;
    }

    static void Main() => Bench.Run(162, Solve);
}
