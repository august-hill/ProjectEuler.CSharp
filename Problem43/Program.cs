using System.Diagnostics;

namespace Problem43;

internal class Program
{
    private static void Main()
    {
        var timeTaken = Stopwatch.StartNew();

        var number = new List<byte> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
        ulong sum = 0;

        do
        {
            if (!IsDivisible(number[1] * 100 + number[2] * 10 + number[3], 2)) continue;
            if (!IsDivisible(number[2] * 100 + number[3] * 10 + number[4], 3)) continue;
            if (!IsDivisible(number[3] * 100 + number[4] * 10 + number[5], 5)) continue;
            if (!IsDivisible(number[4] * 100 + number[5] * 10 + number[6], 7)) continue;
            if (!IsDivisible(number[5] * 100 + number[6] * 10 + number[7], 11)) continue;
            if (!IsDivisible(number[6] * 100 + number[7] * 10 + number[8], 13)) continue;
            if (!IsDivisible(number[7] * 100 + number[8] * 10 + number[9], 17)) continue;

            var n =
                (ulong) number[0] * 1000000000L +
                (ulong) number[1] * 100000000L +
                (ulong) number[2] * 10000000L +
                (ulong) number[3] * 1000000L +
                (ulong) number[4] * 100000L +
                (ulong) number[5] * 10000L +
                (ulong) number[6] * 1000L +
                (ulong) number[7] * 100L +
                (ulong) number[8] * 10L +
                number[9];

            Console.WriteLine(n);

            sum += n;
        } while (NextPermutation(number));

        timeTaken.Stop();
        Console.WriteLine($"sum = {sum}, in {timeTaken.ElapsedMilliseconds} ms.");
    }

    private static bool IsDivisible(int n, int m)
    {
        return n % m == 0;
    }

    private static bool NextPermutation<T>(IList<T> a) where T : IComparable
    {
        if (a.Count < 2) return false;
        var k = a.Count - 2;

        while (k >= 0 && a[k].CompareTo(a[k + 1]) >= 0) k--;
        if (k < 0) return false;

        var l = a.Count - 1;
        while (l > k && a[l].CompareTo(a[k]) <= 0) l--;

        var tmp = a[k];
        a[k] = a[l];
        a[l] = tmp;

        var i = k + 1;
        var j = a.Count - 1;
        while (i < j)
        {
            tmp = a[i];
            a[i] = a[j];
            a[j] = tmp;
            i++;
            j--;
        }

        return true;
    }
}