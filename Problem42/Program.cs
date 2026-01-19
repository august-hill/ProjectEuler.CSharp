using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem42
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the list of words in memory...
            List<string> Words = ReadWords(@"words.txt");

            // Generate enough triangle numbers so that there isn't a word value greater
            SortedSet<int> TriangleNumbers = GenerateTriangleNumbers(20);

            int count = 0;
            foreach (string word in Words)
            {
                int wordValue = WordValue(word);
                if (TriangleNumbers.Contains(wordValue))
                {
                    Console.WriteLine("{0}\t{1}", word, wordValue);
                    count++;
                }
            }

            Console.WriteLine("Total Triangle Words: {0}", count);
        }

        private static SortedSet<int> GenerateTriangleNumbers(int p)
        {
            SortedSet<int> tn = new SortedSet<int>();

            for (int n = 0; n < p; n++)
            {
                tn.Add((n * (n + 1)) / 2);
            }

            return tn;
        }

        private static int WordValue(string word)
        {
            int value = 0;
            foreach (char ch in word)
            {
                value += ch - 'A' + 1;   
            }
            return value;
        }

        private static List<string> ReadWords(string p)
        {
            List<string> words = new List<string>();
            string input;
            string pattern = @"""(\w+)"",?";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);

            using (StreamReader sr = new StreamReader(p, true))
            {
                while (sr.Peek() >= 0)
                {
                    input = sr.ReadLine();
                    MatchCollection matches = rgx.Matches(input);
                    if (matches.Count > 0)
                    {
                        foreach (Match match in matches)
                        {
                            words.Add(match.Groups[1].Value);
                        }
                    }
                }
                sr.Close();
            }

            return words;
        }
    }
}
