using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem24
{
    class Program
    {

#if false        
        private static string digits = "0123";

        enum States
        {
            Start,
            Switch,
            Next,
            End
        }

        static string SwapLastTwoCharacters(string s)
        {
            return s.Substring(0, s.Length - 2) + s[s.Length - 1] + s[s.Length - 2];
        }
        
        static int factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * factorial(n - 1);
            }
        }

        static void Main(string[] args)
        {


            string current = "";

            States state = States.Start;

            int count = 0;

            while (state != States.End)
            {
                switch (state)
                {
                    case States.Start:
                        current = digits;
                        count++;
                        state = States.Switch;
                        break;
                    case States.Switch:
                        current = SwapLastTwoCharacters(current);
                        count++;
                        state = States.Next;
                        break;
                    case States.Next:
                        if (factorial(digits.Length) == count)
                        {
                            state = States.End;
                        }
                        else
                        {
                            current = IncrementThirdDigit(current);
                            count++;
                            state = States.Switch;
                        }
                        break;
                }

                Console.WriteLine("{0}: {1}", count, current);
            }

        }

        private static string F(string s)
        {
            string first = s.Substring(0, s.Length - 1);
            string last = s.Substring(s.Length - 1, 1);

            int i = digits.IndexOf(last) + 1;
            if (i == digits.Length)
            {
                return F(first) + "0";
            }
            else
            {
                return first + digits[i];
            }
        }

        private static string G(string s)
        {
            string x = digits;

            for (int i = 0; i < s.Length; i++)
            {
                x = x.Remove(x.IndexOf(s[i]), 1);
            }

            return x;   // Yay, order preserved!
        }

        private static string IncrementThirdDigit(string current)
        {
            string working = current.Substring(0, current.Length - 2);

            working = F(working);

            return working + G(working);
        }
#endif 

        private static string digits = "0123456789";

        private static List<string> permutation = new List<string>();

        static void Main(string[] args)
        {
            string prefix = "";
            f(digits, prefix);
            Console.WriteLine("permutation[{0}]={1}", 999999, permutation[999999]);
        }

        private static void f(string digits, string prefix)
        {
            if (digits.Length == 2)
            {
                permutation.Add(prefix + digits);
                permutation.Add(prefix + digits[1] + digits[0]);
                return;
            }

            for (int i = 0; i < digits.Length; i++)
			{
                string temp_prefix = prefix + digits[i];
                string temp_digits = digits.Remove(i, 1);
                f(temp_digits, temp_prefix);
			}
        }

    }
}
