// Answer: 748317

namespace Problem37;

internal static class Program
{
    const int Limit = 1000000;
    private static bool[]? _sieve;

    private static bool[] Sieve()
    {
        if (_sieve != null) return _sieve;
        _sieve = new bool[Limit];
        Array.Fill(_sieve, true);
        _sieve[0] = _sieve[1] = false;
        for (int i = 2; i * i < Limit; i++)
            if (_sieve[i])
                for (int j = i * i; j < Limit; j += i)
                    _sieve[j] = false;
        return _sieve;
    }

    private static bool IsLeftTruncatablePrime(int n, bool[] isPrime)
    {
        int divisor = 1;
        while (divisor <= n) divisor *= 10;
        divisor /= 10;
        while (divisor > 1)
        {
            n = n % divisor;
            if (n == 0 || !isPrime[n]) return false;
            divisor /= 10;
        }
        return true;
    }

    private static bool IsRightTruncatablePrime(int n, bool[] isPrime)
    {
        n /= 10;
        while (n > 0)
        {
            if (!isPrime[n]) return false;
            n /= 10;
        }
        return true;
    }

    static long Solve()
    {
        var isPrime = Sieve();
        long sum = 0;
        int count = 0;
        for (int p = 11; p < Limit && count < 11; p++)
        {
            if (isPrime[p] && IsLeftTruncatablePrime(p, isPrime) && IsRightTruncatablePrime(p, isPrime))
            {
                sum += p;
                count++;
            }
        }
        return sum;
    }

    static void Main() => Bench.Run(37, Solve);
}
