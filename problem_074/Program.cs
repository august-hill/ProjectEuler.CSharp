// Answer: 402

namespace Problem74;

internal static class Program
{
    static long Solve()
    {
        int[] factorials = new int[10];
        factorials[0] = 1;
        for (int i = 1; i <= 9; i++) factorials[i] = factorials[i - 1] * i;

        const int cacheSize = 2_200_000;
        byte[] chainLen = new byte[cacheSize];
        chainLen[1] = 1; chainLen[2] = 1; chainLen[145] = 1;
        chainLen[169] = 3; chainLen[363601] = 3; chainLen[1454] = 3;
        chainLen[871] = 2; chainLen[45361] = 2;
        chainLen[872] = 2; chainLen[45362] = 2;

        int count = 0;
        long[] chain = new long[64];
        for (long start = 1; start < 1_000_000; start++)
        {
            int chainIdx = 0;
            long n = start;
            while (true)
            {
                if (n < cacheSize && chainLen[n] > 0)
                {
                    int remaining = chainLen[n];
                    int total = chainIdx + remaining;
                    for (int i = 0; i < chainIdx; i++)
                    {
                        int len = total - i;
                        if (chain[i] < cacheSize && len <= 255)
                            chainLen[chain[i]] = (byte)len;
                    }
                    if (total == 60) count++;
                    break;
                }
                bool found = false;
                for (int i = 0; i < chainIdx; i++)
                    if (chain[i] == n) { found = true; break; }
                if (found) break;
                chain[chainIdx++] = n;
                long next = 0;
                long tmp = n;
                while (tmp > 0) { next += factorials[tmp % 10]; tmp /= 10; }
                n = next;
            }
        }
        return count;
    }

    static void Main() => Bench.Run(74, Solve);
}
