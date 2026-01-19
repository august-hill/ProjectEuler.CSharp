using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Problem32
{
    class Program
    {
        private static bool IsPandigital(string s)
        {
            bool[] flags = new bool[10] { true, false, false, false, false, false, false, false, false, false };

            foreach (char ch in s)
            {
                if (flags[(int)ch - '0'])
                {
                    return false;
                }
                flags[(int)ch - '0'] = true;
            }

            return true;
        }
        static void Main(string[] args)
        {
            Debug.Assert(IsPandigital("15234"), "base case doesn't work.");
            Debug.Assert(!IsPandigital("152342"), "Duplicate 2 should fail.");

            SortedSet<int> products = new SortedSet<int>();

            for (int i = 1; i < 9999; i++)
            {
                for (int j = i + 1; j < 9999; j++)
                {
                    int k = i * j;
                    string product = i.ToString() + j.ToString() + k.ToString();
                    if (product.Length == 9)
                    {
                        if (IsPandigital(product))
                        {
                            Console.WriteLine("{0} * {1} = {2}", i, j, k);
                            products.Add(k);
                        }
                    }
                }
            }

            Console.WriteLine("sum of products is {0}", products.Sum());
        }
    }
}
