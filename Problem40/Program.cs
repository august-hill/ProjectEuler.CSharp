using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem40
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder(1000000);
            sb.Append('x'); // pad
            for (int i = 1; i < 200000; i++)
            {
                sb.Append(i.ToString());
            }

            Console.WriteLine("{0}",sb.Length);

            int d1 = Convert.ToInt32(sb[1]- '0');
            int d10 = Convert.ToInt32(sb[10] - '0');
            int d100 = Convert.ToInt32(sb[100] - '0');
            int d1000 = Convert.ToInt32(sb[1000] - '0');
            int d10000 = Convert.ToInt32(sb[10000] - '0');
            int d100000 = Convert.ToInt32(sb[100000] - '0');
            int d1000000 = Convert.ToInt32(sb[1000000] - '0');

            Console.WriteLine("{0}", d1 * d10 * d100 * d1000 * d10000 * d100000 * d1000000);
        }
    }
}
