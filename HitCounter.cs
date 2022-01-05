using System;
using System.Collections.Generic;
using System.Text;

namespace TerryAlgorithm
{
    public interface IHitCounter
    {
        void hit(int timestamp);
        int getHits(int timestamp);
    }

    public class HitCounter1:IHitCounter
    {
        private int[] count;
        private int[] indexes;

        /** Initialize your data structure here. */
        public HitCounter1()
        {
            count = new int[300];
            indexes = new int[300];
            for (int i = 0; i < 300; i++)
            {
                indexes[i] = i;
            }
        }

        /** Record a hit.
            @param timestamp - The current timestamp (in seconds granularity). */
        public void hit(int timestamp)
        {
            int index = timestamp % 300;
            if (timestamp != indexes[index])
            {
                indexes[index] = timestamp;
                count[index] = 0;
            }
            count[index]++;
        }

        /** Return the number of hits in the past 5 minutes.
            @param timestamp - The current timestamp (in seconds granularity). */
        public int getHits(int timestamp)
        {
            int result = 0;
            for (int i = 0; i < 300; i++)
            {
                result += timestamp - indexes[i] < 300 ? count[i] : 0;
            }
            return result;
        }
    }

    public class HitCounter2 : IHitCounter
    {
        private int[] count;
        private int[] indexes;

        /** Initialize your data structure here. */
        public HitCounter2()
        {
            count = new int[300];
            indexes = new int[300];

            for (int i = 0; i < 300; i++)
            {
                indexes[i] = i;
            }
        }

        /** Record a hit.
            @param timestamp - The current timestamp (in seconds granularity). */
        public void hit(int timestamp)
        {
            int index = timestamp % 300;
            if (timestamp != indexes[index])
            {
                indexes[index] = timestamp;
                count[index] = 0;
            }
            count[index]++;
        }

        /** Return the number of hits in the past 5 minutes.
            @param timestamp - The current timestamp (in seconds granularity). */
        public int getHits(int timestamp)
        {
            int result = 0;
            for (int i = 0; i < 300; i++)
            {
                result += timestamp - indexes[i] < 300 ? count[i] : 0;
            }
            return result;
        }
    }

    partial class Program
    {
        static void TestHitCounter()
        {
            IHitCounter counter = new HitCounter1();

            // hit at timestamp 1.
            counter.hit(1);

            // hit at timestamp 2.
            counter.hit(2);

            // hit at timestamp 3.
            counter.hit(3);

            // get hits at timestamp 4, should return 3.
            int count = counter.getHits(4);
            Console.WriteLine(count);

            // hit at timestamp 300.
            counter.hit(300);

            // get hits at timestamp 300, should return 4.
            count = counter.getHits(300);
            Console.WriteLine(count);

            // get hits at timestamp 301, should return 3.
            count = counter.getHits(301);
            Console.WriteLine(count);
        }
    }
}
