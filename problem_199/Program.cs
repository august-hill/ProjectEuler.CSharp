// Answer: 396087
using System;

namespace Problem199;

internal static class Program
{
    static double _totalArea;

    static void FillGap(double k1, double k2, double k3, int depth)
    {
        if (depth == 0) return;
        double k4 = k1 + k2 + k3 + 2.0 * Math.Sqrt(k1 * k2 + k2 * k3 + k1 * k3);
        double r4 = 1.0 / k4;
        _totalArea += Math.PI * r4 * r4;
        FillGap(k1, k2, k4, depth - 1);
        FillGap(k1, k3, k4, depth - 1);
        FillGap(k2, k3, k4, depth - 1);
    }

    static long Solve()
    {
        double R = 1.0;
        double r = R / (1.0 + 2.0 / Math.Sqrt(3.0));
        double kOuter = -1.0 / R;
        double kInner = 1.0 / r;

        double outerArea = Math.PI * R * R;
        _totalArea = 3.0 * Math.PI * r * r;

        FillGap(kInner, kInner, kOuter, 10);
        FillGap(kInner, kInner, kOuter, 10);
        FillGap(kInner, kInner, kOuter, 10);
        FillGap(kInner, kInner, kInner, 10);

        double fraction = (outerArea - _totalArea) / outerArea;
        return (long)Math.Round(fraction * 1e8);
    }

    static void Main() => Bench.Run(199, Solve);
}
