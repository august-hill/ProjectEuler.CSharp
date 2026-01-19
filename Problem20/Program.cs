using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problem20
{
    class Program
    {

        static BigInteger Factorial(BigInteger n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }

        static BigInteger SumDigits(BigInteger n)
        {
            BigInteger result = 0;
            while (n != 0)
            {
                result += n % 10;
                n /= 10;
            }
            return result;
        }

        static void Main(string[] args)
        {
            BigInteger n = 100;
            BigInteger f = Factorial(n);
            BigInteger s = SumDigits(f);

            Console.WriteLine("{0} {1} {2}", n, f, s);

        }
    }
}
