using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Numerics;

namespace Problem26
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger numerator = 1;
            // Let's put lots of digits in the numerator
            const int DIGITS = 5000;
            for (int i = 0; i < DIGITS; i++)
            {
                numerator *= 10;
            }

            string pattern = @"^((?<dig>\d+?)(\k<dig>)+\d+?)|((?<pfx>\d+?)(?<dig>\d+?)(\k<dig>)+\d+?)$";
            //string pattern = @"^(?<pfx>\d+?)(?<dig>\d+?)(\k<dig>)+\d+?$";
            Regex rgx = new Regex(pattern, RegexOptions.Compiled);

            int maxLength = 0;

            for (int d = 2; d < 1000; d++)
            {
                BigInteger y = numerator / d;
                string answer = y.ToString().TrimEnd('0');

                // leading zeros!
                //if (d > 100)
                //{
                //    answer = "00" + answer;
                //}
                //else if (d > 10)
                //{
                //    answer = "0" + answer;
                //}
                
                MatchCollection matches = rgx.Matches(answer);
                if (matches.Count > 0)
                {
                    int length = matches[0].Groups["dig"].Value.Length;
                    Console.WriteLine("1/{0:D4} = 0.{1}({2}) L:{3}",
                        d,
                        matches[0].Groups["pfx"].Value,
                        matches[0].Groups["dig"].Value,
                        length);

                    if (length > maxLength)
                    {
                        maxLength = length;
                    }
                }
                else
                {
                    Console.WriteLine("1/{0:D4} = 0.{1}", d, answer);
                }
            }

            Console.WriteLine("max length is: {0}", maxLength);
        }
    }
}
