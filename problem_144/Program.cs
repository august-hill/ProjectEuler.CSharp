// Answer: 354
using System;

namespace Problem144;

internal static class Program
{
    static long Solve()
    {
        double x0 = 0.0, y0 = 10.1;
        double x1 = 1.4, y1 = -9.6;
        int count = 0;

        while (true)
        {
            double dx = x1 - x0;
            double dy = y1 - y0;

            double nx = 4.0 * x1, ny = y1;
            double dot = dx * nx + dy * ny;
            double nn = nx * nx + ny * ny;

            double rx = dx - 2.0 * dot / nn * nx;
            double ry = dy - 2.0 * dot / nn * ny;

            double a = 4.0 * rx * rx + ry * ry;
            double b = 8.0 * x1 * rx + 2.0 * y1 * ry;
            double c = 4.0 * x1 * x1 + y1 * y1 - 100.0;

            double disc = b * b - 4.0 * a * c;
            double t = (-b + Math.Sqrt(disc)) / (2.0 * a);
            if (Math.Abs(t) < 1e-9)
                t = (-b - Math.Sqrt(disc)) / (2.0 * a);

            x0 = x1; y0 = y1;
            x1 = x0 + t * rx;
            y1 = y0 + t * ry;
            count++;

            if (y1 > 0 && Math.Abs(x1) <= 0.01)
                break;
        }
        return count;
    }

    static void Main() => Bench.Run(144, Solve);
}
