using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Problem17
{
    public class NumericWordFormat : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        public string Format(string fmt, object arg, IFormatProvider formatProvider)
        {
            // Provide default formatting if arg is not an Int32. 
            if (arg.GetType() != typeof(Int32))
                try
                {
                    return HandleOtherFormats(fmt, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(String.Format("The format of '{0}' is invalid.", fmt), e);
                }

            // No format specified? Provide a default
            if (fmt == null)
                try
                {
                    return HandleOtherFormats(fmt, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(String.Format("The format of '{0}' is invalid.", fmt), e);
                }

            // Provide default formatting for unsupported format strings. 
            string ufmt = fmt.ToUpper(CultureInfo.InvariantCulture);
            if (!(ufmt == "W"))
                try
                {
                    return HandleOtherFormats(fmt, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(String.Format("The format of '{0}' is invalid.", fmt), e);
                }

            // Convert argument to words
            return IntToWords((int)arg);
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            else if (arg != null)
                return arg.ToString();
            else
                return String.Empty;
        }

        private string IntToWords(int n)
        {
            string result = "";
            List<string> words = new List<string>();
            string[] units = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] tens = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string[] teens = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            do
            {
                if (n >= 1000)  // we only support n <= 1000
                {
                    words.Add("one thousand");
                    n -= 1000;
                }

                if (n > 99)
                {
                    int h = n / 100;
                    words.Add(units[h] + " hundred");
                    n -= 100 * h;
                }

                if (n > 19)
                {
                    int t = n / 10;
                    string s = tens[t - 2];
                    n -= 10 * t;
                    if (n == 0)
                    {
                        words.Add(s);
                    }
                    else
                    {
                        words.Add(s + "-" + units[n]);
                    }
                    break;
                }

                if (n > 9)
                {
                    words.Add(teens[n - 10]);
                    break;
                }

                if (n > 0)
                {
                    words.Add(units[n]);
                    break;
                }

                // zero is special
                if (words.Count == 0)
                {
                    words.Add(units[n]);
                }

            } while (false);

            for (int i = 0; i < words.Count; i++)
            {
                if (i == 0)
                {
                    result = words[i];
                }
                else if (i == words.Count - 1)
                {
                    result += " and " + words[i];
                }
                else
                {
                    result += " " + words[i];
                }
            }

            return result;
        }
    }

    class Program
    {
        static int Lc(string s)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] >= 'a' && s[i] <= 'z')
                {
                    count++;
                }
            }
            return count;
        }

        static void Main(string[] args)
        {
            for (int i = 1; i <= 5; i++)
            {
                string output = String.Format(new NumericWordFormat(), "{0} is {0:W}", i);
                Console.WriteLine(output);
            }
            Console.WriteLine(String.Format(new NumericWordFormat(), "{0} is {0:W} length {1}", 342,
                Lc(String.Format(new NumericWordFormat(), "{0:W}",342))));
            Console.WriteLine(String.Format(new NumericWordFormat(), "{0} is {0:W} length {1}", 115,
                Lc(String.Format(new NumericWordFormat(), "{0:W}", 115))));
            Console.WriteLine(String.Format(new NumericWordFormat(), "{0} is {0:W}", 1000));
            Console.WriteLine(String.Format(new NumericWordFormat(), "{0} is {0:W}", 200));
            Console.WriteLine(String.Format(new NumericWordFormat(), "{0} is {0:W}", 19));
            Console.WriteLine(String.Format(new NumericWordFormat(), "{0} is {0:W}", 305));
            Console.WriteLine(String.Format(new NumericWordFormat(), "{0} is {0:W}", 0));
            Console.WriteLine(String.Format(new NumericWordFormat(), "{0} is {0:W}", 960));

            //string s = "";
            //for (int i = 1; i <= 5; i++)
            //{
            //    s += String.Format(new NumericWordFormat(), "{0:W}", i) + " ";
            //}
            //Console.WriteLine("{0} is {1} long",s,Lc(s));

            //s = "";
            //for (int i = 1; i <= 1000; i++)
            //{
            //    s += String.Format(new NumericWordFormat(), "{0:W}", i) + " ";
            //}
            //Console.WriteLine("{0} is {1} long", s, Lc(s));
           
            var nf = new NumericWordFormat();
            int answer = Enumerable.Range(1, 1000).Sum(x => String.Format(nf,"{0:W}",x).Count(y => Char.IsLetter(y)));
            Console.WriteLine("answer={0}", answer);

        }
    }
}
