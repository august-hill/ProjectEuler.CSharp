using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem36
{
    class Program
    {
        private static bool IsPalindromic(string s)
        {
            int start = 0;
            int end = s.Length - 1;
            while (s[start] == s[end])
            {
                start++;
                end--;
                if (start >= end)
                {
                    return true;
                }
            }

            return false;
        }

        private static string ToBinary(int n)
        {
            string s = "";

            do {
                s += (n % 2) == 0 ? "0" : "1";
                n >>= 1;
            } while (n != 0);

            return s;
        }

        static void Main(string[] args)
        {
            int sum = 0;

            for (int n = 1; n < 1000000; n++)
            {
                string d = n.ToString();
                string b = ToBinary(n);
                bool x = IsPalindromic(d);
                bool y = IsPalindromic(b);
                if (x && y)
                {
                    sum += n;
                    Console.WriteLine("{0}", n);
                }
            }

            Console.WriteLine("sum {0}", sum);
        }
    }
}
