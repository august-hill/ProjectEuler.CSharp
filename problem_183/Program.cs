// Answer: 48861552
using System;

namespace Problem183;

internal static class Program
{
    static long Gcd(long a, long b)
    {
        while (b != 0) { long t = b; b = a % b; a = t; }
        return a;
    }

    static bool IsTerminating(long num, long den)
    {
        long g = Gcd(num, den);
        den /= g;
        while (den % 2 == 0) den /= 2;
        while (den % 5 == 0) den /= 5;
        return den == 1;
    }

    static long Solve()
    {
        double e = Math.Exp(1.0);
        long total = 0;

        for (int N = 5; N <= 10000; N++)
        {
            int kf = (int)Math.Floor(N / e);
            int kc = kf + 1;
            if (kf < 2) kf = 2;

            double vf = kf * Math.Log((double)N / kf);
            double vc = kc * Math.Log((double)N / kc);
            int k = (vf >= vc) ? kf : kc;

            if (IsTerminating(N, k)) total -= N;
            else total += N;
        }

        return total;
    }

    static void Main() => Bench.Run(183, Solve);
}
