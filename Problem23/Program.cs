using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem23
{
    class Program
    {

        static long SumProperDivisors(long n)
        {
            long sum = 0;

            for (long i = 1; i < n; i++)
            {
                if (n % i == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }

        static bool IsPerfect(long n)
        {
            return SumProperDivisors(n) == n;
        }

        static bool IsDeficient(long n)
        {
            return SumProperDivisors(n) < n;
        }
        
        static bool IsAbundant(long n)
        {
            return SumProperDivisors(n) > n;
        }

        static void TestCases()
        {
            List<long> testCases = new List<long>();
            testCases.Add(28);
            testCases.Add(12);
            testCases.Add(24);
            foreach (long n in testCases)
            {
                Console.WriteLine("n:{0} SPD:{1} P:{2} D:{3} A:{4}",
                    n, SumProperDivisors(n), IsPerfect(n).ToString(),
                    IsDeficient(n).ToString(), IsAbundant(n).ToString());

            }
        }

        const int MAX_ABUNDANT = 28123;

        static void Main(string[] args)
        {
            SortedSet<int> NL = new SortedSet<int>();
            List<int> ABL = new List<int>();

            for (int i = 1; i <= MAX_ABUNDANT; i++)
            {
                NL.Add(i);
                if (IsAbundant(i))
                {
                    ABL.Add(i);
                }
            }

            for (int i = 0; i < ABL.Count; i++)
            {
                for (int j = 0; j < ABL.Count; j++)
                {
                    NL.Remove(ABL[i] + ABL[j]);
                }
            }

            long sum = 0;
            foreach (int item in NL)
            {
                sum += item;
            }

            Console.WriteLine("{0}", sum);
        }
    }
}
