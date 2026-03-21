// Answer: 272
using System.Numerics;

namespace Problem65;

internal static class Program
{
    static long Solve()
    {
        static int CfCoeff(int k)
        {
            if (k == 0) return 2;
            int j = k - 1;
            if (j % 3 == 1) return 2 * (j / 3 + 1);
            return 1;
        }

        BigInteger hPrev2 = 1;
        BigInteger hPrev1 = 2;
        for (int k = 1; k < 100; k++)
        {
            int a = CfCoeff(k);
            BigInteger newH = a * hPrev1 + hPrev2;
            hPrev2 = hPrev1;
            hPrev1 = newH;
        }

        int sum = 0;
        foreach (char c in hPrev1.ToString())
            sum += c - '0';
        return sum;
    }

    static void Main() => Bench.Run(65, Solve);
}
