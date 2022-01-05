using System;
using System.Collections.Generic;
using System.Text;

namespace TerryAlgorithm
{
    partial class Program
    {
        static void testLongestSubStr()
        {
            //string str = "abcdefgabcd86b7";
            //string str = "abcdefgabcd86";
            //string str = "babad";
            //string str = "cbbd";
            string str = "";
            Console.WriteLine(LongestSubStr(str));
        }

        static string LongestSubStr(string str)
        {
            if (string.IsNullOrWhiteSpace(str) == true)
            {
                return string.Empty;
            }

            int start = 0, len = 1;

            for (int i = 0; i < str.Length; i++)
            {
                int end = i + len;
                for (int j = str.Length-1; j >= end; j--)
                {
                    if (str[i] == str[j])
                    {
                        start = i;
                        len = j - i + 1;
                    }
                }
            }

            Console.WriteLine($"start={start}, len={len}");
            return str.Substring(start, len);
        }
    }
}
