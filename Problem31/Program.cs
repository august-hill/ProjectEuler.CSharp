using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem31
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> coins = new List<int>() { 1, 2, 5, 10, 20, 50, 100, 200 };
            int count = 0;

            for (int p200 = 0; p200 <= 1; p200++)
            {
                for (int p100 = 0; p100 <= 2; p100++)
                {
                    for (int p50 = 0; p50 <= 4; p50++)
                    {
                        for (int p20 = 0; p20 <= 10; p20++)
                        {
                            for (int p10 = 0; p10 <= 20; p10++)
                            {
                                for (int p5 = 0; p5 <= 40; p5++)
                                {
                                    for (int p2 = 0; p2 <= 100; p2++)
                                    {
                                        for (int p1 = 0; p1 <= 200; p1++)
                                        {

                                            if (Valid(p1, p2, p5, p10, p20, p50, p100, p200))
                                            {
                                                Console.WriteLine("p:{0} 2p:{1} 5p:{2} 10p:{3} 20p:{4} 50p:{5} 100p:{6} 200p:{7}",
                                                    p1, p2, p5, p10, p20, p50, p100, p200);
                                                count++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("count is {0}", count);

        }

        private static bool Valid(int p1, int p2, int p5, int p10, int p20, int p50, int p100, int p200)
        {
            int x = p1 + (2 * p2) + (5 * p5) + (10 * p10) + (20 * p20) + (50 * p50) + (100 * p100) + (200 * p200);
            return x == 200;
        }
    }
}
