// Answer: 983
using System.Numerics;
using System.Text.RegularExpressions;

namespace Problem26;

internal static class Program
{
    static long Solve()
    {
        BigInteger numerator = 1;
        const int DIGITS = 5000;
        for (int i = 0; i < DIGITS; i++) numerator *= 10;

        string pattern = @"^((?<dig>\d+?)(\k<dig>)+\d+?)|((?<pfx>\d+?)(?<dig>\d+?)(\k<dig>)+\d+?)$";
        Regex rgx = new Regex(pattern, RegexOptions.Compiled);

        int maxLength = 0;
        int maxD = 0;

        for (int d = 2; d < 1000; d++)
        {
            BigInteger y = numerator / d;
            string answer = y.ToString().TrimEnd('0');
            MatchCollection matches = rgx.Matches(answer);
            if (matches.Count > 0)
            {
                int length = matches[0].Groups["dig"].Value.Length;
                if (length > maxLength)
                {
                    maxLength = length;
                    maxD = d;
                }
            }
        }
        return maxD;
    }

    static void Main() => Bench.Run(26, Solve);
}
