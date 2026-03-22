// Answer: 37076114526
using System;

namespace Problem101;

internal static class Program
{
    static long U(int n)
    {
        long val = 0, power = 1;
        for (int i = 0; i <= 10; i++)
        {
            if (i % 2 == 0) val += power;
            else val -= power;
            power *= n;
        }
        return val;
    }

    static long LagrangeEval(long[] y, int k, int x)
    {
        double result = 0.0;
        for (int i = 0; i < k; i++)
        {
            double li = 1.0;
            for (int j = 0; j < k; j++)
            {
                if (j != i)
                    li *= (double)(x - (j + 1)) / (double)((i + 1) - (j + 1));
            }
            result += y[i] * li;
        }
        return (long)(result + (result > 0 ? 0.5 : -0.5));
    }

    static long Solve()
    {
        long[] y = new long[11];
        for (int i = 0; i < 11; i++)
            y[i] = U(i + 1);

        long total = 0;
        for (int k = 1; k <= 10; k++)
        {
            long predicted = LagrangeEval(y, k, k + 1);
            long actual = U(k + 1);
            if (predicted != actual)
                total += predicted;
        }
        return total;
    }

    static void Main() => Bench.Run(101, Solve);
}
