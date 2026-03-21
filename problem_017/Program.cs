// Answer: 21124
using System;
using System.Globalization;
using System.Linq;

namespace Problem17;

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
        if (arg.GetType() != typeof(Int32))
            try { return HandleOtherFormats(fmt, arg); }
            catch (FormatException e) { throw new FormatException(String.Format("The format of '{0}' is invalid.", fmt), e); }

        if (fmt == null)
            try { return HandleOtherFormats(fmt, arg); }
            catch (FormatException e) { throw new FormatException(String.Format("The format of '{0}' is invalid.", fmt), e); }

        string ufmt = fmt.ToUpper(CultureInfo.InvariantCulture);
        if (!(ufmt == "W"))
            try { return HandleOtherFormats(fmt, arg); }
            catch (FormatException e) { throw new FormatException(String.Format("The format of '{0}' is invalid.", fmt), e); }

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
        var words = new System.Collections.Generic.List<string>();
        string[] units = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        string[] tens = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        string[] teens = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        do
        {
            if (n >= 1000)
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
                if (n == 0) { words.Add(s); }
                else { words.Add(s + "-" + units[n]); }
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
            if (words.Count == 0)
            {
                words.Add(units[n]);
            }
        } while (false);

        for (int i = 0; i < words.Count; i++)
        {
            if (i == 0) result = words[i];
            else if (i == words.Count - 1) result += " and " + words[i];
            else result += " " + words[i];
        }
        return result;
    }
}

internal static class Program
{
    static long Solve()
    {
        var nf = new NumericWordFormat();
        int answer = Enumerable.Range(1, 1000).Sum(x => String.Format(nf, "{0:W}", x).Count(y => Char.IsLetter(y)));
        return answer;
    }

    static void Main() => Bench.Run(17, Solve);
}
