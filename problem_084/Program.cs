// Answer: 101524
using System;
using System.Linq;

namespace Problem84;

internal static class Program
{
    const int GO = 0, JAIL = 10, G2J = 30;
    const int CC1 = 2, CC2 = 17, CC3 = 33;
    const int CH1 = 7, CH2 = 22, CH3 = 36;
    const int C1 = 11, E3 = 24, H2 = 39, R1 = 5;

    private static void ApplyLanding(double[] freq, int square, double prob)
    {
        if (square == G2J) { freq[JAIL] += prob; }
        else if (square is CC1 or CC2 or CC3)
        {
            freq[GO] += prob / 16.0;
            freq[JAIL] += prob / 16.0;
            freq[square] += prob * 14.0 / 16.0;
        }
        else if (square is CH1 or CH2 or CH3)
        {
            int nextR = square switch { CH1 => 15, CH2 => 25, _ => 5 };
            int nextU = square switch { CH1 => 12, CH2 => 28, _ => 12 };
            int back3 = (square + 37) % 40;
            freq[GO] += prob / 16.0;
            freq[JAIL] += prob / 16.0;
            freq[C1] += prob / 16.0;
            freq[E3] += prob / 16.0;
            freq[H2] += prob / 16.0;
            freq[R1] += prob / 16.0;
            freq[nextR] += prob * 2.0 / 16.0;
            freq[nextU] += prob / 16.0;
            ApplyLanding(freq, back3, prob / 16.0);
            freq[square] += prob * 6.0 / 16.0;
        }
        else { freq[square] += prob; }
    }

    static long Solve()
    {
        var diceProb = new double[9];
        for (int d1 = 1; d1 <= 4; d1++)
            for (int d2 = 1; d2 <= 4; d2++)
                diceProb[d1 + d2] += 1.0 / 16.0;

        var freq = new double[40];
        freq[0] = 1.0;
        for (int iter = 0; iter < 200; iter++)
        {
            var newFreq = new double[40];
            for (int pos = 0; pos < 40; pos++)
            {
                if (freq[pos] == 0.0) continue;
                newFreq[JAIL] += freq[pos] * (1.0 / 64.0);
                double remaining = freq[pos] * (63.0 / 64.0);
                for (int sum = 2; sum <= 8; sum++)
                {
                    int next = (pos + sum) % 40;
                    ApplyLanding(newFreq, next, remaining * diceProb[sum]);
                }
            }
            freq = newFreq;
        }

        var indexed = Enumerable.Range(0, 40).OrderByDescending(i => freq[i]).ToArray();
        return indexed[0] * 10000 + indexed[1] * 100 + indexed[2];
    }

    static void Main() => Bench.Run(84, Solve);
}
