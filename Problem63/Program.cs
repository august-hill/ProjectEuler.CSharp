using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

// The 5-digit number, 16807=7^5, is also a fifth power.Similarly, the 9-digit number, 134217728=8^9, 
// is a ninth power.
//
// How many n-digit positive integers exist which are also an nth power?


namespace Problem63
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();

            long answer = 0;
            BigInteger MAX = long.MaxValue;


            for (int e = 1; e < 100; e++)
            {
                for (BigInteger b = 1; b < MAX; b++)
                {
                    BigInteger r = BigInteger.Pow(b, e);
                    int rLength = r.ToString().Length;

                    if (e == rLength)
                    {
                        Console.WriteLine("{0}: {1}={2}^{3}", ++answer, r, b, e);
                    }
                    else if (rLength > e)
                    {
                        break;
                    }
                }

            }

            long ms = stopWatch.ElapsedMilliseconds;
            Console.WriteLine("RunTime: {0} ms.", ms);
        }
    }
}
