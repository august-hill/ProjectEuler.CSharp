// Answer: 1533776805

namespace Problem45;

internal static class Program
{
    static long Pentagonal(long n) => n * (3 * n - 1) / 2;
    static long Hexagonal(long n) => n * (2 * n - 1);

    static long Solve()
    {
        long p = 1, h = 1;
        long pn = Pentagonal(p), hn = Hexagonal(h);
        while (true)
        {
            if (hn < pn)
                hn = Hexagonal(++h);
            else if (pn < hn)
                pn = Pentagonal(++p);
            else
            {
                if (hn > 40755) return hn;
                pn = Pentagonal(++p);
                hn = Hexagonal(++h);
            }
        }
    }

    static void Main() => Bench.Run(45, Solve);
}
