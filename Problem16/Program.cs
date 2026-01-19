using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problem16
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger n = 2;
            for (int i = 1; i < 1000; i++)
            {
                n *= 2;
            }
            Console.WriteLine("2^1000 = {0}", n);

            int sum = 0;
            BigInteger ten = 10;
            while (n != 0)
            {
                BigInteger digit = n % ten;
                sum += (int)digit;
                n /= ten;
            }

            Console.WriteLine("sum of digits = {0}",sum);
        }
    }
}
