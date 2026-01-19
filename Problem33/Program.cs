using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem33
{
    class Program
    {
        static void Main(string[] args)
        {
            // 49/98 = 7x7 / 2x7x7 = 1/2
            // ab/cd, where
            // if a == c, then ab/cd == b/d
            // if a == d, then ab/cd == b/c
            // if b == c, then ab/cd == a/d
            // if b == d, then ab/cd == a/c

            //16/64 *
            //19/95 *
            //26/65 *
            //49/98 =          
            //
            // 1/100

            for (int a = 1; a <= 9; a++)
            {
                for (int b = 1; b <= 9; b++)
                {
                    for (int c = 1; c <= 9; c++)
                    {
                        for (int d = 1; d <= 9; d++)
                        {
                            double x = (double)((a * 10) + b) / (double)((c * 10) + d);
                            if (x < 1.0D)
                            {
                                if (a == c)
                                {
                                    double y = (double)b / (double)d;
                                    if (x == y)
                                    {
                                        Console.WriteLine("{0}{1}/{2}{3}", a, b, c, d);
                                    }
                                }
                                if (a == d)
                                {
                                    double y = (double)b / (double)c;
                                    if (x == y)
                                    {
                                        Console.WriteLine("{0}{1}/{2}{3}", a, b, c, d);
                                    }
                                }
                                if (b == c)
                                {
                                    double y = (double)a / (double)d;
                                    if (x == y)
                                    {
                                        Console.WriteLine("{0}{1}/{2}{3}", a, b, c, d);
                                    }
                                }
                                if (b == d)
                                {
                                    double y = (double)a / (double)c;
                                    if (x == y)
                                    {
                                        Console.WriteLine("{0}{1}/{2}{3}", a, b, c, d);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
