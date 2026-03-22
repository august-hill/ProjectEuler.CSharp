// Answer: 9857164023
using System;

namespace Problem170;

internal static class Program
{
    static bool IsPandigital(long num)
    {
        if (num < 1000000000L || num > 9999999999L) return false;
        int[] seen = new int[10];
        while (num > 0) { int d = (int)(num % 10); if (seen[d] != 0) return false; seen[d] = 1; num /= 10; }
        for (int i = 0; i < 10; i++) if (seen[i] == 0) return false;
        return true;
    }

    static long ConcatLL(long a, long b)
    {
        long tmp = b;
        if (tmp == 0) return a * 10 + b;
        while (tmp > 0) { a *= 10; tmp /= 10; }
        return a + b;
    }

    // Check if a number with digits digs (sorted) can be arranged so n*that_number has digits digsNf (sorted)
    static long CheckFactor(long n, int[] digsF, int nf, int[] digsNf, int nnf)
    {
        int[] arr = new int[nf];
        for (int i = 0; i < nf; i++) arr[i] = digsF[i];
        Array.Sort(arr);

        do
        {
            if (arr[0] == 0 && nf > 1) goto NextPerm;
            long f = 0;
            for (int i = 0; i < nf; i++) f = f * 10 + arr[i];
            long nfVal = n * f;
            int[] check = new int[10];
            long tmp2 = nfVal;
            int cntD = 0;
            while (tmp2 > 0) { check[tmp2 % 10]++; tmp2 /= 10; cntD++; }
            if (cntD != nnf) goto NextPerm;
            int[] sortedCheck = new int[nnf];
            int si = 0;
            for (int d2 = 0; d2 <= 9; d2++) for (int cc = 0; cc < check[d2]; cc++) sortedCheck[si++] = d2;
            bool ok = true;
            for (int i = 0; i < nnf; i++) if (sortedCheck[i] != digsNf[i]) { ok = false; break; }
            if (ok) return f;

            NextPerm:
            int jj = nf - 2;
            while (jj >= 0 && arr[jj] >= arr[jj + 1]) jj--;
            if (jj < 0) break;
            int ll = nf - 1;
            while (arr[ll] <= arr[jj]) ll--;
            (arr[jj], arr[ll]) = (arr[ll], arr[jj]);
            int lo2 = jj + 1, hi2 = nf - 1;
            while (lo2 < hi2) { (arr[lo2], arr[hi2]) = (arr[hi2], arr[lo2]); lo2++; hi2--; }
        } while (true);

        return -1;
    }

    static bool _initialized;
    static long _answerCache;

    static long Solve()
    {
        if (_initialized) return _answerCache;
        _initialized = true;

        long best = 0;

        for (int n = 2; n <= 98; n++)
        {
            int[] nDigs = new int[3];
            int nn = 0;
            { int tmp = n; while (tmp > 0) { nDigs[nn++] = tmp % 10; tmp /= 10; } }
            bool[] nSeen = new bool[10];
            bool validN = true;
            for (int i = 0; i < nn; i++) { if (nSeen[nDigs[i]]) { validN = false; break; } nSeen[nDigs[i]] = true; }
            if (!validN) continue;

            int[] remDigs = new int[10]; int nrem = 0;
            for (int d = 0; d <= 9; d++) if (!nSeen[d]) remDigs[nrem++] = d;

            int nsub = 1 << nrem;
            for (int mask1 = 1; mask1 < nsub - 1; mask1++)
            {
                int[] digsF1 = new int[10]; int nf1 = 0;
                int[] digsF2 = new int[10]; int nf2 = 0;
                for (int i = 0; i < nrem; i++)
                {
                    if ((mask1 & (1 << i)) != 0) digsF1[nf1++] = remDigs[i];
                    else digsF2[nf2++] = remDigs[i];
                }
                Array.Sort(digsF1, 0, nf1);
                Array.Sort(digsF2, 0, nf2);

                int maxE = 10 - (nf1 + nf2);
                for (int e1 = 0; e1 <= maxE; e1++)
                {
                    int nf1p = nf1 + e1;
                    int nf2p = 10 - nf1p;
                    if (nf2p < nf2 || nf2p > nf2 + maxE) continue;
                    if (nf1p <= 0 || nf2p <= 0) continue;

                    int nc = nf1p;
                    if (nc > 10) continue;
                    int[] combo = new int[nc];
                    for (int i = 0; i < nc; i++) combo[i] = i;

                    while (true)
                    {
                        int[] digsNf1 = new int[nc]; int[] digsNf2 = new int[10 - nc];
                        bool[] inCombo = new bool[10];
                        for (int i = 0; i < nc; i++) inCombo[combo[i]] = true;
                        int n1 = 0, n2 = 0;
                        for (int d2 = 0; d2 <= 9; d2++) { if (inCombo[d2]) digsNf1[n1++] = d2; else digsNf2[n2++] = d2; }

                        long f1 = CheckFactor(n, digsF1[0..nf1], nf1, digsNf1, nf1p);
                        if (f1 >= 0)
                        {
                            long f2 = CheckFactor(n, digsF2[0..nf2], nf2, digsNf2, nf2p);
                            if (f2 >= 0)
                            {
                                long p1 = (long)n * f1, p2 = (long)n * f2;
                                long prodConcat = ConcatLL(p1, p2);
                                if (IsPandigital(prodConcat) && prodConcat > best)
                                    best = prodConcat;
                            }
                        }

                        int ii = nc - 1;
                        while (ii >= 0 && combo[ii] == 10 - nc + ii) ii--;
                        if (ii < 0) break;
                        combo[ii]++;
                        for (int jj2 = ii + 1; jj2 < nc; jj2++) combo[jj2] = combo[jj2 - 1] + 1;
                    }
                }
            }
        }

        _answerCache = best;
        return _answerCache;
    }

    static void Main() => Bench.Run(170, Solve);
}
