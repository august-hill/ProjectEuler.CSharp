using System.Diagnostics;

namespace Problem44
{
    class Program
    {
        private const int MaximumValue = 3000;

        private static void Main()
        {
            var timeTaken = Stopwatch.StartNew();

            var p = new int[MaximumValue];
            for (int i = 0; i < MaximumValue; i++)
            {
                p[i] = P(i);
            }

            bool found = false;
            for (int j = 1; j < MaximumValue & !found; j++)
            {
                for (int k = j + 1; k < MaximumValue & !found; k++)
                {
                    int sum = p[j] + p[k];
                    if (Array.BinarySearch(p, sum) < 0)
                    {
                        continue;
                    }

                    int diff = p[k] - p[j];
                    if (Array.BinarySearch(p, diff) < 0)
                    {
                        continue;
                    }

                    Console.WriteLine($"P({j}) + P({k}) = {p[j]} + {p[k]} = {sum}");
                    Console.WriteLine($"P({j}) - P({k}) = {p[j]} - {p[k]} = {diff}");
                    found = true;
                    break;
                }
            }

            Console.WriteLine($"in {timeTaken.ElapsedMilliseconds} ms.");
        }

        private static int P(int n)
        {
            return n * (3 * n - 1) / 2;
        }
    }
}