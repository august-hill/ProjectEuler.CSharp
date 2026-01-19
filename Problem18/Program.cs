using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem18
{
    class TNode
    {
        public TNode LChild { get; set; }
        public TNode RChild { get; set; }
        public int Value { get; set; }

        public TNode(int value)
        {
            Value = value;
        }

    }

    class Program
    {
        //static int[] t1 = {
        //                   3,
        //                 7,  4,
        //               2,  4,  6,
        //             8,  5,  9,  3};

        static int[] t1 = {
             75,
             95, 64,
             17, 47, 82,
             18, 35, 87, 10,
             20, 04, 82, 47, 65,
             19, 01, 23, 75, 03, 34,
             88, 02, 77, 73, 07, 63, 67,
             99, 65, 04, 28, 06, 16, 70, 92,
             41, 41, 26, 56, 83, 40, 80, 70, 33,
             41, 48, 72, 33, 47, 32, 37, 16, 94, 29,
             53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14,
             70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57,
             91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48,
             63, 66, 04, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31,
             04, 62, 98, 27, 23, 09, 70, 98, 73, 93, 38, 53, 60, 04, 23};




        static void LinkTNode(TNode p, TNode lc, TNode rc)
        {
            p.LChild = lc;
            p.RChild = rc;
        }

        static int Summation(int n)
        {
            return n * (n + 1) / 2;
        }

        static void Main(string[] args)
        {
            // In order to link the nodes of the tree, read them in order, into
            // a list. This also sets the value of the new node.
            List<TNode> tn = new List<TNode>();

            foreach (int tv in t1)
            {
                tn.Add(new TNode(tv));
            }

            // Calculate the number of levels in the triangle, based on
            // the number of nodes we've been given
            int levels = 0;
            int nodes = tn.Count;
            for (int i = 1; i <= nodes; i++)
            {
                if (Summation(i) == nodes)
                {
                    levels = i;
                    break;
                }
            }

            // Walk the tree, linking the two child nodes to the parent
            for (int level = 0; level < levels - 1; level++)
            {
                int p = Summation(level);
                int c = Summation(level + 1);
                for (int columns = 0; columns <= level; columns++)
                {
                    LinkTNode(tn[p], tn[c], tn[c + 1]);
                    p++;
                    c++;
                }
            }

            TNode root = tn[0];

            int n = Convert.ToInt32(Math.Pow(2, levels - 1));
            BitArray path = new BitArray(levels - 1);
            int greatestSum = 0;
            for (int i = 0; i < n; i++)
            {
                int k = i;
                for (int j = 0; j < levels - 1; j++)
                {
                    path.Set(j, (k & 1) == 1);
                    k >>= 1;
                }
                int sum = PrintTNode(root, path);
                if (sum > greatestSum)
                {
                    greatestSum = sum;
                }
            }
            Console.WriteLine("greatest sum = {0}", greatestSum);
        }

        private static int PrintTNode(TNode root, BitArray path)
        {
            int sum = root.Value;
            for (int i = 0; i < path.Length; i++)
            {
                if (path[i])
                {
                    root = root.RChild;
                }
                else
                {
                    root = root.LChild;
                }
                sum += root.Value;
            }
            Console.WriteLine("sum = {0}", sum);
            return sum;
        }
    }
}
