// Answer: 121313

namespace Problem51;

internal static class Program
{
    const int Upper = 999999;
    const int Lower = Upper / 10; // 99999

    private static bool[]? _sieve;

    private static bool[] Sieve()
    {
        if (_sieve != null) return _sieve;
        _sieve = new bool[Upper + 1];
        Array.Fill(_sieve, true);
        _sieve[0] = _sieve[1] = false;
        for (int i = 2; i * i <= Upper; i++)
            if (_sieve[i])
                for (int j = i * i; j <= Upper; j += i)
                    _sieve[j] = false;
        return _sieve;
    }

    static long Solve()
    {
        var isPrime = Sieve();

        for (int p = Lower + 1; p <= Upper; p++)
        {
            if (!isPrime[p]) continue;
            string s = p.ToString();
            int n = s.Length;

            for (int i = 0; i < n - 2; i++)
            {
                for (int j = i + 1; j < n - 1; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        if (s[i] != s[j] || s[j] != s[k]) continue;

                        int primeCount = 0;
                        int firstPrime = 0;
                        for (char d = '0'; d <= '9'; d++)
                        {
                            char[] tmp = s.ToCharArray();
                            tmp[i] = tmp[j] = tmp[k] = d;
                            int num = int.Parse(new string(tmp));
                            if (num > Lower && isPrime[num])
                            {
                                primeCount++;
                                if (firstPrime == 0) firstPrime = num;
                            }
                        }

                        if (primeCount == 8) return firstPrime;
                    }
                }
            }
        }
        return 0;
    }

    static void Main() => Bench.Run(51, Solve);
}
