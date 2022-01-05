using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace TerryAlgorithm
{
    partial class Program
    {
        static void TestSlidingBuffer()
        {
            var slidingBuffer = new SlidingBuffer<long>(200);

            var ticketsDays = new List<IEnumerable<int>>();
            int index = 1;

            for (int i = 1; i <= 20; i++)
            {
                ticketsDays.Add(Enumerable.Range(index, 100));
                index += 50;
            }

            //
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var ticketsDay in ticketsDays)
            {
                foreach (var ticket in ticketsDay)
                {
                    slidingBuffer.AddUnique(ticket);
                }
            }

            stopwatch.Stop();

            foreach (var item in slidingBuffer)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"elapsed milli sec:{stopwatch.Elapsed.TotalMilliseconds}");
            Console.ReadLine();
        }
    }

    public class SlidingBuffer<T> : IEnumerable<T>
    {
        private readonly Queue<T> _queue;
        private readonly int _maxCount;

        public SlidingBuffer(int maxCount)
        {
            _maxCount = maxCount;
            _queue = new Queue<T>(maxCount);
        }

        public bool Contains(T item)
        {
            return _queue.Contains(item);
        }

        public void AddUnique(T item)
        {
            if (_queue.Contains(item))
            {
                return;
            }

            this.Add(item);
        }

        public void Add(T item)
        {
            if (_queue.Count == _maxCount)
                _queue.Dequeue();
            _queue.Enqueue(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _queue.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
