using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problem34
{
    class Program
    {
        static void Main(string[] args)
        {
            const int LIMIT = 100000;

            for (BigInteger n = 3; n < LIMIT; n++)
            {
                string digits = n.ToString();
                BigInteger sum = 0;
                foreach (char ch in digits)
                {
                    sum += factorial(ch - '0');
                }

                if (n == sum)
                {
                    Console.WriteLine("{0}", n);
                }

            }

        }

        private static BigInteger factorial(BigInteger n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * factorial(n - 1);
            }
        }
    }
}
