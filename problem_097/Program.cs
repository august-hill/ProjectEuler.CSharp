// Answer: 8739992577

namespace Problem97;

internal static class Program
{
    const long Mod = 10000000000L; // 10^10

    private static long ModMul(long a, long b, long m)
    {
        return (long)((decimal)a * b % m);
    }

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

    static long Solve()
    {
        long power = ModPow(2, 7830457, Mod);
        long result = ModMul(28433, power, Mod);
        result = (result + 1) % Mod;
        return result;
    }

    static void Main() => Bench.Run(97, Solve);
}
