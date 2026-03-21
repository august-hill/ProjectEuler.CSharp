// Answer: 4782
using System.Numerics;
using System.Text;

namespace Problem25;

internal static class Program
{
    static long Solve()
    {
        StringBuilder number = new StringBuilder(1000);
        BigInteger F_Nminus1 = 1;
        BigInteger F_Nminus2 = 1;
        BigInteger F_N = F_Nminus2 + F_Nminus1;
        long term = 3;

        while (true)
        {
            F_Nminus1 = F_Nminus2;
            F_Nminus2 = F_N;
            F_N = F_Nminus2 + F_Nminus1;
            term++;
            number.Clear();
            number.Append(F_N.ToString());
            if (number.Length == 1000) return term;
        }
    }

    static void Main() => Bench.Run(25, Solve);
}
