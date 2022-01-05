using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TerryAlgorithm
{
    /*
     Input: 1->2->4, 1->3->4
Output: 1->1->2->3->4->4
         */

    /*
    Input:
nums1 = [1,2,3,0,0,0], m = 3
nums2 = [2,5,6],       n = 3
Output: [1,2,2,3,5,6]

    */

    class ListNode
    {
        public int Value { get; set; }

        public ListNode Next { get; set; }
    }

    partial class Program
    {
        static void mergeListsTest()
        {
            // build
            var first = buildList(new int[] { 1, 2, 4 });
            var second = buildList(new int[] { 1, 3, 4 });

            // print
            printList(first);
            printList(second);

            // merge
            var merged = mergeLists(first, second);

            // print merging result
            printList(merged);
        }

        static void mergeArraysTest()
        {
            // build
            int m = 3;
            int n = 3;
            var first = Enumerable.Range(1, m + n).Select(x => x > m ? 0 : x).ToArray();
            var second = new int[] { 2, 5, 6 };

            // print
            Console.WriteLine(string.Join("->", first));
            Console.WriteLine(string.Join("->", second));

            // merge
            mergeArrays(first, m, second);

            // print merging result
            Console.WriteLine(string.Join("->", first));
        }

        static ListNode mergeLists(ListNode first, ListNode second)
        {
            // assert
            if (first == null && second == null)
            {
                return null;
            }

            if (first == null && second != null)
            {
                return second;
            }

            if (first != null && second == null)
            {
                return first;
            }

            ListNode merged = null;
            ListNode current = null;
            ListNode firstCurrent = first;
            ListNode secondCurrent = second;

            // initalize merged root node
            if (firstCurrent.Value <= secondCurrent.Value)
            {
                merged = firstCurrent;
                firstCurrent = firstCurrent.Next;
            }
            else
            {
                merged = secondCurrent;
                secondCurrent = secondCurrent.Next;
            }

            merged.Next = null;
            current = merged;

            // start to merge
            while (true)
            {
                if (firstCurrent == null)
                {
                    current.Next = secondCurrent;
                    break;
                }

                if (secondCurrent == null)
                {
                    current.Next = firstCurrent;
                    break;
                }

                if (firstCurrent.Value <= secondCurrent.Value)
                {
                    current.Next = firstCurrent;
                    firstCurrent = firstCurrent.Next;
                }
                else
                {
                    current.Next = secondCurrent;
                    secondCurrent = secondCurrent.Next;
                }

                current = current.Next;
            }

            return merged;
        }

        static ListNode buildList(int[] values)
        {
            var root = new ListNode() { Value = values[0] };
            var current = root;

            for (int i = 1; i < values.Length; i++)
            {
                current.Next = new ListNode { Value = values[i] };
                current = current.Next;
            }

            return root;
        }

        static void printList(ListNode root)
        {
            if (root == null)
            {
                Console.WriteLine("list is null.");
                return;
            }

            var node = root;

            while (node != null)
            {
                Console.Write(node.Value);

                if (node.Next != null)
                {
                    Console.Write("->");
                }

                node = node.Next;
            }

            Console.WriteLine();
        }

        static void mergeArrays(int[] first, int firstLength, int[] second)
        {
            int movement = second.Length;
            int currentEnd = firstLength - 1;

            for (int i = second.Length - 1; i >= 0; i--)
            {
                for (int j = currentEnd; j >= 0; j--)
                {
                    if (second[i] > first[j])
                    {
                        for (int k = currentEnd; k >= j + 1; k--)
                        {
                            first[k + movement] = first[k];
                        }

                        first[j + movement] = second[i];
                        currentEnd = j;
                        movement--;
                        break;
                    }
                }
            }
        }
    }
}
