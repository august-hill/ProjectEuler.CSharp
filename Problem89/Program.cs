using System;
using System.IO;
using System.Text;

// Problem 89: Roman Numerals
// Answer: 743

using System.Diagnostics;

var lines = File.ReadAllLines("p089_roman.txt");

static int RomanCharVal(char c) => c switch
{
    'M' => 1000, 'D' => 500, 'C' => 100, 'L' => 50,
    'X' => 10, 'V' => 5, 'I' => 1, _ => 0
};

static int RomanToInt(string s)
{
    int total = 0;
    for (int i = 0; i < s.Length; i++)
    {
        int v = RomanCharVal(s[i]);
        if (i + 1 < s.Length)
        {
            int next = RomanCharVal(s[i + 1]);
            if (v < next) { total += next - v; i++; continue; }
        }
        total += v;
    }
    return total;
}

static string IntToRoman(int n)
{
    var sb = new System.Text.StringBuilder();
    (int val, string sym)[] table = [
        (1000, "M"), (900, "CM"), (500, "D"), (400, "CD"),
        (100, "C"), (90, "XC"), (50, "L"), (40, "XL"),
        (10, "X"), (9, "IX"), (5, "V"), (4, "IV"), (1, "I")
    ];
    foreach (var (val, sym) in table)
        while (n >= val) { sb.Append(sym); n -= val; }
    return sb.ToString();
}

static int Solve(string[] lines)
{
    int saved = 0;
    foreach (var line in lines)
    {
        var trimmed = line.Trim();
        if (trimmed.Length == 0) continue;
        int value = RomanToInt(trimmed);
        string minimal = IntToRoman(value);
        saved += trimmed.Length - minimal.Length;
    }
    return saved;
}

// Warmup
for (int i = 0; i < 10; i++)
    Solve(lines);

// Benchmark
const int iterations = 10;
var sw = Stopwatch.StartNew();
int result = 0;
for (int i = 0; i < iterations; i++)
    result = Solve(lines);
sw.Stop();

double nsPerOp = (double)sw.Elapsed.Ticks / iterations * 100;
Console.WriteLine($"Result: {result} ({nsPerOp:F2} ns/op)");
