// Answer: 49
using System.Numerics;

namespace Problem63;

internal static class Program
{
    static long Solve()
    {
        long answer = 0;
        for (int e = 1; e < 100; e++)
        {
            for (BigInteger b = 1; b < long.MaxValue; b++)
            {
                BigInteger r = BigInteger.Pow(b, e);
                int rLength = r.ToString().Length;
                if (e == rLength) answer++;
                else if (rLength > e) break;
            }
        }
        return answer;
    }

    static void Main() => Bench.Run(63, Solve);
}
