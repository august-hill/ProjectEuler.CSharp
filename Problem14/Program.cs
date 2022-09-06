using System.Diagnostics;

namespace Problem14;

internal static class Program
{
    private static int C(long n)
    {
        if (n == 1) return 1;

        if (n % 2 == 0)
            return C(n / 2) + 1;
        return C(3 * n + 1) + 1;
    }

    private static void Main(string[] args)
    {
        //Console.WriteLine("C({0})={1}", 1, C(1));
        //Console.WriteLine("C({0})={1}", 5, C(5));
        //Console.WriteLine("C({0})={1}", 13, C(13));
        //Console.WriteLine("C({0})={1}", 40, C(40));

        long best_i = 0;
        long best_c = 0;
        for (long i = 999999; i > 0; i--)
        {
            var c = C(i);
            if (c > best_c)
            {
                best_c = c;
                best_i = i;
                Console.WriteLine("C({0})={1}", best_i, best_c);
            }
        }

        Console.WriteLine("C({0})={1}", best_i, best_c);
        Debug.Assert(best_i == 837799);
    }
}