using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problem29
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<BigInteger> sequence = new SortedSet<BigInteger>();
            const int N = 100;
            for (int a = 2; a <= N; a++)
            {
                for (int b = 2; b <= N; b++)
                {
                    BigInteger x = 1;
                    for (int i = 0; i < b; i++)
                    {
                        x *= a;
                    }
                    sequence.Add(x);
                }
            }
            Console.WriteLine("{0} distinct terms", sequence.Count);
        }
    }
}
