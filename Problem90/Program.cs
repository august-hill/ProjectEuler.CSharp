using System;
using System.Collections.Generic;

// Problem 90: Cube Digit Pairs
// Answer: 1217

using System.Diagnostics;

static List<bool[]> GenerateCubes()
{
    var cubes = new List<bool[]>();
    for (int a = 0; a < 5; a++)
    for (int b = a+1; b < 6; b++)
    for (int c = b+1; c < 7; c++)
    for (int d = c+1; d < 8; d++)
    for (int e = d+1; e < 9; e++)
    for (int f = e+1; f < 10; f++)
    {
        var digits = new bool[10];
        digits[a] = true; digits[b] = true; digits[c] = true;
        digits[d] = true; digits[e] = true; digits[f] = true;
        if (digits[6] || digits[9])
        {
            digits[6] = true;
            digits[9] = true;
        }
        cubes.Add(digits);
    }
    return cubes;
}

static int Solve()
{
    var cubes = GenerateCubes();
    int[][] squares = [
        [0,1], [0,4], [0,9], [1,6], [2,5],
        [3,6], [4,9], [6,4], [8,1]
    ];

    int count = 0;
    for (int i = 0; i < cubes.Count; i++)
    {
        for (int j = i; j < cubes.Count; j++)
        {
            bool valid = true;
            foreach (var sq in squares)
            {
                int d1 = sq[0], d2 = sq[1];
                if (!((cubes[i][d1] && cubes[j][d2]) || (cubes[i][d2] && cubes[j][d1])))
                {
                    valid = false;
                    break;
                }
            }
            if (valid) count++;
        }
    }
    return count;
}

// Warmup
for (int i = 0; i < 10; i++)
    Solve();

// Benchmark
const int iterations = 10;
var sw = Stopwatch.StartNew();
int result = 0;
for (int i = 0; i < iterations; i++)
    result = Solve();
sw.Stop();

double nsPerOp = (double)sw.Elapsed.Ticks / iterations * 100;
Console.WriteLine($"Result: {result} ({nsPerOp:F2} ns/op)");
