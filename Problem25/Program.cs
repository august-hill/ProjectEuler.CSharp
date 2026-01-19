using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problem25
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder number = new StringBuilder(1000);

            BigInteger F_Nminus1 = 1;
            BigInteger F_Nminus2 = 1;
            BigInteger F_N = F_Nminus2 + F_Nminus1;

            long term = 3;

            bool done = false;
            while (!done)
            {
                F_Nminus1 = F_Nminus2;
                F_Nminus2 = F_N;
                F_N = F_Nminus2 + F_Nminus1;
                term++;
                number.Clear();
                number.Append(F_N.ToString());
                //Console.WriteLine("T:{0} L:{1} {2}", term, number.Length, F_N);

                if (number.Length == 1000)
                {
                    Console.WriteLine("T:{0} L:{1} {2}", term, number.Length, F_N);
                    done = true;
                }
            }

        }
    }
}
