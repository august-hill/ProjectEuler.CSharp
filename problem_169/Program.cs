// Answer: 178653872807
using System;

namespace Problem169;

internal static class Program
{
    static long Solve()
    {
        System.UInt128 n = 1;
        for (int i = 0; i < 25; i++) n *= 10;

        int[] bits = new int[100];
        int nbits = 0;
        System.UInt128 temp = n;
        while (temp > 0)
        {
            bits[nbits++] = (int)(temp & 1);
            temp >>= 1;
        }
        // Reverse to get MSB first
        for (int i = 0; i < nbits / 2; i++)
        {
            int t = bits[i]; bits[i] = bits[nbits - 1 - i]; bits[nbits - 1 - i] = t;
        }

        long fa = 1; // f(n_partial)
        long fb = 1; // f(n_partial - 1)

        for (int i = 1; i < nbits; i++)
        {
            if (bits[i] == 0)
            {
                long newFa = fa + fb;
                long newFb = fb;
                fa = newFa;
                fb = newFb;
            }
            else
            {
                long newFa = fa;
                long newFb = fa + fb;
                fa = newFa;
                fb = newFb;
            }
        }

        return fa;
    }

    static void Main() => Bench.Run(169, Solve);
}
