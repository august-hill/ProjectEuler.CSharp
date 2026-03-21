// Answer: 296962999629

namespace Problem49;

internal static class Program
{
    private static string SortedDigits(int n)
    {
        char[] chars = n.ToString().ToCharArray();
        Array.Sort(chars);
        return new string(chars);
    }

    static long Solve()
    {
        bool[] isPrime = new bool[10001];
        Array.Fill(isPrime, true);
        isPrime[0] = isPrime[1] = false;
        for (int i = 2; i * i <= 10000; i++)
            if (isPrime[i])
                for (int j = i * i; j <= 10000; j += i)
                    isPrime[j] = false;

        for (int p = 1000; p < 10000; p++)
        {
            if (!isPrime[p] || p == 1487) continue;
            string sig = SortedDigits(p);

            var perms = new System.Collections.Generic.List<int>();
            for (int q = p; q < 10000; q++)
            {
                if (isPrime[q] && SortedDigits(q) == sig)
                    perms.Add(q);
            }

            for (int i = 0; i < perms.Count; i++)
            {
                for (int j = i + 1; j < perms.Count; j++)
                {
                    int diff = perms[j] - perms[i];
                    int third = perms[j] + diff;
                    for (int k = j + 1; k < perms.Count; k++)
                    {
                        if (perms[k] == third)
                            return (long)perms[i] * 100000000L + (long)perms[j] * 10000L + third;
                    }
                }
            }
        }
        return 0;
    }

    static void Main() => Bench.Run(49, Solve);
}
