using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace Problem22
{
    class Program
    {
        static int Av(string name)
        {
            int sum = 0;
            foreach (int ch in name)
            {
                sum += ch - 'A' + 1;
            }
            return sum;
        }

        static void Main(string[] args)
        {
            SortedList<string, int> nameList = new SortedList<string, int>();

            string input;
            string pattern = @"""(\w+)"",?";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);

            using (StreamReader sr = new StreamReader(@"names.txt", true))
            {
                while (sr.Peek() >= 0)
                {
                    input = sr.ReadLine();
                    MatchCollection matches = rgx.Matches(input);
                    if (matches.Count > 0)
                    {
                        foreach (Match match in matches)
                        {
                            nameList.Add(match.Groups[1].Value, Av(match.Groups[1].Value));
                        }
                    }
                }
                sr.Close();
            }

            int position = 1;
            int total = 0;
            foreach (var name in nameList)
            {
                int score = position * name.Value;
                Console.WriteLine("K:{0} P:{1} V:{2} S:{3}", name.Key, position, name.Value, score);
                total += score;
                position++;
            }
            Console.WriteLine("total of all the name scores {0}", total);
        }
    }
}
