// Answer: 997651

namespace Problem50;

internal static class Program
{
    const int Limit = 1000000;

    static long Solve()
    {
        bool[] isPrime = new bool[Limit + 1];
        Array.Fill(isPrime, true);
        isPrime[0] = isPrime[1] = false;
        for (int i = 2; i * i <= Limit; i++)
            if (isPrime[i])
                for (int j = i * i; j <= Limit; j += i)
                    isPrime[j] = false;

        var primes = new System.Collections.Generic.List<int>();
        for (int i = 2; i <= Limit; i++)
            if (isPrime[i]) primes.Add(i);

        int maxLen = 0, maxSum = 0;
        for (int i = 0; i < primes.Count; i++)
        {
            int sum = 0;
            for (int j = 0; i + j < primes.Count; j++)
            {
                sum += primes[i + j];
                if (sum >= Limit) break;
                if (isPrime[sum] && j > maxLen)
                {
                    maxLen = j;
                    maxSum = sum;
                }
            }
        }
        return maxSum;
    }

    static void Main() => Bench.Run(50, Solve);
}
