// Answer: 9110846700

namespace Problem48;

internal static class Program
{
    const long Mod = 10000000000L; // 10^10

    private static long ModPow(long baseVal, long exp, long m)
    {
        long result = 1;
        baseVal %= m;
        while (exp > 0)
        {
            if ((exp & 1) == 1) result = ModMul(result, baseVal, m);
            exp >>= 1;
            baseVal = ModMul(baseVal, baseVal, m);
        }
        return result;
    }

    private static long ModMul(long a, long b, long m)
    {
        // Use decimal to avoid overflow for 10-digit modulus
        return (long)((decimal)a * b % m);
    }

    static long Solve()
    {
        long sum = 0;
        for (long i = 1; i <= 1000; i++)
        {
            sum = (sum + ModPow(i, i, Mod)) % Mod;
        }
        return sum;
    }

    static void Main() => Bench.Run(48, Solve);
}
