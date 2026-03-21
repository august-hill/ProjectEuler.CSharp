// Answer: 55374

namespace Problem78;

internal static class Program
{
    static long Solve()
    {
        const int limit = 100_000;
        const int modulus = 1_000_000;
        int[] p = new int[limit];
        p[0] = 1;

        int[] pentagonals = new int[1000];
        int numPent = 0;
        for (int k = 1; k < 500; k++)
        {
            pentagonals[numPent++] = k * (3 * k - 1) / 2;
            pentagonals[numPent++] = k * (3 * k + 1) / 2;
        }

        for (int n = 1; n < limit; n++)
        {
            long sum = 0;
            for (int i = 0; i < numPent; i++)
            {
                if (pentagonals[i] > n) break;
                int sign = (i % 4 < 2) ? 1 : -1;
                sum = (sum + sign * (long)p[n - pentagonals[i]]) % modulus;
            }
            p[n] = (int)(((sum % modulus) + modulus) % modulus);
            if (p[n] == 0) return n;
        }
        return 0;
    }

    static void Main() => Bench.Run(78, Solve);
}
