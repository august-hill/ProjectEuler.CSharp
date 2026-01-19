using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem39
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> solutions = new Dictionary<int, int>();

            for (int a = 1; a < 1000; a++)
            {
                for (int b = 1; b < 1000; b++)
                {
                    for (int c = 1; c < 1000; c++)
                    {
                        if (a < b && b < c)
                        {
                            if ((a * a) + (b * b) == (c * c))
                            {
                                int p = a + b + c;
                                if (solutions.ContainsKey(p))
                                {
                                    solutions[p]++;
                                }
                                else
                                {
                                    solutions.Add(p, 1);
                                }
                            }
                        }
                    }
                }
            }

            foreach(var s in solutions)
            {
                if (s.Key <= 1000 && s.Value > 3)
                {
                    Console.WriteLine("{0}: {1}", s.Key, s.Value);
                }
            }

        }
    }
}
