// Answer: 210
using System;
using System.Text;

namespace Problem40;

internal static class Program
{
    static long Solve()
    {
        StringBuilder sb = new StringBuilder(1000000);
        sb.Append('x');
        for (int i = 1; i < 200000; i++)
            sb.Append(i.ToString());

        int d1 = Convert.ToInt32(sb[1] - '0');
        int d10 = Convert.ToInt32(sb[10] - '0');
        int d100 = Convert.ToInt32(sb[100] - '0');
        int d1000 = Convert.ToInt32(sb[1000] - '0');
        int d10000 = Convert.ToInt32(sb[10000] - '0');
        int d100000 = Convert.ToInt32(sb[100000] - '0');
        int d1000000 = Convert.ToInt32(sb[1000000] - '0');

        return d1 * d10 * d100 * d1000 * d10000 * d100000 * d1000000;
    }

    static void Main() => Bench.Run(40, Solve);
}
