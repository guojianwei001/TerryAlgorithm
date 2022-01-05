using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

/*
 
    LRUCache cache = new LRUCache( 2 // capacity ); 
cache.put(1, 1);
cache.put(2, 2);

cache.get(1);       // returns 1
cache.put(3, 3);    // evicts key 2
cache.get(2);       // returns -1 (not found)
cache.put(4, 4);    // evicts key 1
cache.get(1);       // returns -1 (not found)
cache.get(3);       // returns 3
cache.get(4);       // returns 4


*/


namespace TerryAlgorithm
{
    partial class Program
    {
        public class ListLRUNode
        {
            public int Key { get; set; }

            public int Value { get; set; }

            public ListLRUNode Prev { get; set; }

            public ListLRUNode Next { get; set; }
        }

        static void testLRU()
        {
            LRUCache cache = new LRUCache(2); 

            int value = cache.get(1);       // returns 1
            cache.put(3, 3);    // evicts key 2
            value = cache.get(2);       // returns -1 (not found)
            cache.put(4, 4);    // evicts key 1
            value = cache.get(1);       // returns -1 (not found)
            value = cache.get(3);       // returns 3
            value = cache.get(4);       // returns 4
        }

        public class LRUCache
        {
            private Hashtable key2PriorityTable = new Hashtable();
            private ListLRUNode head = new ListLRUNode();
            private ListLRUNode tail = null;

            public LRUCache(int capacity)
            {
                var node = head;

                for (int i = 1; i <= capacity; i++)
                {
                    node.Next = new ListLRUNode { Key=i, Value=i };
                    node.Next.Prev = node;
                    key2PriorityTable.Add(i, node.Next);
                    node = node.Next;
                }

                tail = node;
            }

            public int get(int key)
            {
                if (key2PriorityTable.ContainsKey(key) == false)
                {
                    return -1;
                }

                var node = (ListLRUNode)key2PriorityTable[key];
                removeNode(node);
                pushBack(node);

                return node.Value;
            }

            public void put(int key, int value)
            {
                key2PriorityTable.Remove(head.Next.Key);

                var node = new ListLRUNode { Key = key, Value = value};
                pushBack(node);
                removeFirstNode();

                key2PriorityTable.Add(key, tail);
            }

            /// <summary>
            /// remove head node with lowest priority
            /// </summary>
            private void removeNode(ListLRUNode node)
            {
                node.Prev.Next = node.Next;
                node.Next.Prev = node.Prev;
            }

            /// <summary>
            /// remove head node with lowest priority
            /// </summary>
            private void removeFirstNode()
            {
                head.Next = head.Next.Next;
                head.Next.Prev = head;
            }

            /// <summary>
            /// insert the new element at the tail of list
            /// </summary>
            /// <param name="node"></param>
            private void pushBack(ListLRUNode node)
            {
                tail.Next = node;
                tail.Next.Prev = tail;
                tail = tail.Next;
                tail.Next = null;
            }
        }
    }
}
