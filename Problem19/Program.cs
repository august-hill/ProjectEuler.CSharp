using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem19
{
    class Program
    {
#if false
        static int[] Days = {
                                  31,   // January
                                  28,   // February
                                  31,   // March
                                  30,   // April
                                  31,   // May
                                  30,   // June
                                  31,   // July
                                  31,   // August
                                  30,   // September
                                  31,   // October
                                  30,   // November
                                  31};  // December

        enum Month
        {
            January,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        };

        enum WeekDay
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday
        };

        const int DaysInWeek = 7;

        static bool LeapYear(int year)
        {
            bool result = false;

            if (year % 4 == 0)
            {
                result = true;
                if (year % 100 == 0)
                {
                    result = false;
                    if (year % 400 == 0)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }
#endif 

        static void Main(string[] args)
        {
            DateTime start = new DateTime(1901, 1, 1);
            Console.WriteLine("start {0}, {1}", start.DayOfWeek.ToString(), start.Day);
            // Find the next Sunday...
            TimeSpan fiveDays = new TimeSpan(5, 0, 0, 0);
            start += fiveDays;
            Console.WriteLine("a {0}, {1}", start.DayOfWeek.ToString(), start.Day);

            TimeSpan week = new TimeSpan(7, 0, 0, 0);
            DateTime end = new DateTime(2000, 12, 31);
            int count = 0;
            while (start <= end)
            {
                if (start.Day == 1)
                {
                    Console.WriteLine("{0} {1} {2}", start.ToString(), start.DayOfWeek.ToString(), start.Day);
                    count++;
                }
                start += week;
            }

            Console.WriteLine("answer = {0}", count);
        }
    }
}
