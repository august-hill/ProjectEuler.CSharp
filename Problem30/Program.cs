using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem30
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            for (int i = 2; i < 1000000; i++)
            {
                if (i == F(i))
                {
                    Console.WriteLine("{0}", i);
                    sum += i;
                }
            }

            Console.WriteLine("sum is {0}", sum);
        }

        private static int F(int i)
        {
            int sum = 0;
            const int power = 5;

            string digits = i.ToString();
            foreach (char ch in digits)
            {
                int x = 1;
                for (int n = 0; n < power; n++)
                {
                    x *= (int)(ch - '0');
                }

                sum += x;
            }

            return sum;
        }
    }
}
