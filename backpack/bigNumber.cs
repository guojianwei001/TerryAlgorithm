using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TerryAlgorithm
{
    partial class Program
    {
        private static string[] Factorizationlist = new string[6];

        private static string[] F1(int n)
        {
            if (n == 1)
            {
                return new string[] { "1" };
            }

            var factorList = new List<string>();


            for (int i = 1; i <= n - 1; i++)
            {
                factorList.AddRange(F1(n - i).Select(x => $"{i}+{x}"));
            }

            Console.WriteLine($"{n}=");
            Console.WriteLine(string.Join(Environment.NewLine, factorList));
            Console.WriteLine("-----------------------------------------------");

            return factorList.ToArray();

            // 1+F(1) 1+1

            // 1+F(2) 1+1+1
            // 2+F(1) 2+1

            // 1+F(3) 1+1+2
            // 2+F(2) 2+1+1
            // 3+F(1) 3+1

            // 1+F(4) 
            // 2+F(3) 2+1+1+1
            // 3+F(2) 3+1+1
            // 4+F(1) 4+1
        }

        private static string[] F2()
        {
            Factorizationlist[1] = "1";


            for (int i = 2; i <= 5; i++)
            {
                var tempList = new List<string>();
                tempList.Add(i.ToString());

                for (int j = 1; j <= i - 1; j++)
                {
                    var array1 = Factorizationlist[i - j].Split(Environment.NewLine);
                    tempList.AddRange(array1.Select(x => $"{j}+{x}"));
                }

                Factorizationlist[i] = string.Join(Environment.NewLine, tempList);
            }

            Console.WriteLine(Factorizationlist[5]);
            Console.WriteLine("-----------------------------------------------");

            return Factorizationlist;
        }

        private static List<int> v = new List<int>();

        private static List<List<int>> vv = new List<List<int>>();

        private static void fun(int val, int s)
        {
            if (val == 0)
            {
                vv.Add(v);
                return;
            }

            for (int i = s; i <= val; i++)
            {
                v.Add(i);
                fun(val - i, i);
                v.RemoveAt(v.Count - 1);
            }
        }

        private static void testFun()
        {
            fun(10, 1);

            for (int i = 0; i < vv.Count(); i++)
            {
                for (int j = 0; j < vv[i].Count(); j++)
                    Console.WriteLine(vv[i][j]);

                Console.WriteLine();
            }
        }

        private static NumberNode NumberRootNode = new NumberNode { Value = 0, Children = new List<NumberNode>() };

        private static void buildNumberTree(NumberNode node, int sum, int target)
        {
            int start = node.Value >= 1 ? node.Value : 1;

            for (int i = start; i <= target; i++)
            {
                if (sum + i == target)
                {
                    node.Children.Add(new NumberNode { Value = i });
                }
                else
                {
                    if (sum + 2 * i <= target)
                    {
                        var node1 = new NumberNode { Value = i, Children = new List<NumberNode>() };
                        node.Children.Add(node1);
                        buildNumberTree(node1, sum + i, target);
                    }
                }
            }
        }

        private static void traverseNumberTree(NumberNode node, int[] values)
        {
            var newValues = node.Value > 0 ? values.Concat(new int[] { node.Value }).ToArray() : values;

            if (node.Children == null || node.Children.Count() <= 0)
            {
                Console.WriteLine(string.Join(" ", newValues));
                return;
            }

            foreach (var child in node.Children)
            {
                traverseNumberTree(child, newValues);
            }
        }

        private static void buildNumberTree2(int value, IEnumerable<int> values, int target)
        {
            int sum = values.Sum();
            int start = value >= 1 ? value : 1;

            for (int i = start; i <= target; i++)
            {
                if (sum + i == target)
                {
                    Console.WriteLine(string.Join(" ", values.Concat(new int[] { i })));
                }
                else if (sum + 2 * i <= target)
                {
                    buildNumberTree2(i, values.Concat(new int[] { i }).ToArray(), target);
                }
            }
        }

        private static void testBuildNumberTree(int target)
        {
            //buildNumberTree(NumberRootNode, 0, 10);
            //traverseNumberTree(NumberRootNode, new int[] { });
            buildNumberTree2(0, new int[] { }, target);
        }

        //private static void comb(string source, string current)
        //{
        //    if (current.Length == 3)
        //    {
        //        Console.WriteLine(current);
        //        return;
        //    }

        //    int c = string.IsNullOrWhiteSpace(current) == false ? source.IndexOf(current.Last()) + 1 : 0;

        //    for (int i = c; i < source.Length; i++)
        //    {
        //        comb(source, current + source[i]);
        //    }
        //}

        private static void comb(string source, string current)
        {
            if (current.Length == 3)
            {
                Console.WriteLine(current);
                return;
            }

            int start = string.IsNullOrWhiteSpace(current) == false ? source.IndexOf(current.Last()) + 1 : 0;

            for (int i = start; i < source.Length; i++)
            {
                if (current.Length + source.Length - i >= 3)
                {
                    comb(source, current + source[i]);
                }
            }
        }
    }

    public class NumberNode
    {
        public int Value { get; set; }

        public List<NumberNode> Children { get; set; }
    }

    /*
     A+B+C+D+E
     A+F(B,C,D,E)
     B+F(A,C,D,E)
     C+F(A,B,D,E)
     D+F(A,B,C,E)
     E+F(A,B,C,D)
     */
}
