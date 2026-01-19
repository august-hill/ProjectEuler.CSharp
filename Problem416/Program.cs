using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem416
{
    class Program
    {
        static int F(long m, long n)
        {
            Console.WriteLine("{0}",n);
            return 0;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("F({0},{1})={2}", 1, 3, F(1, 3));
            Console.WriteLine("F({0},{1})={2}", 1, 4, F(1, 4));
            Console.WriteLine("F({0},{1})={2}", 1, 5, F(1, 5));
            Console.WriteLine("F({0},{1})={2}", 2, 3, F(2, 3));
            Console.WriteLine("F({0},{1})={2}", 2, 100, F(1, 100));
            Console.WriteLine("F({0},{1})={2}", 10, 1000000000000, F(10, 1000000000000));
        }
    }
}
