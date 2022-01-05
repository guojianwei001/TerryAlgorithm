using System;
using System.Collections.Generic;
using System.Text;

namespace TerryAlgorithm
{
    partial class Program
    {
        static void testPatternAlgor()
        {
            var testStrings = new string[] { "aa", "aa", "cb", "adceb", "acdcb", "abc88888def7777ghi", "abc88888def7777ghhi" };
            var testPatterns = new string[] { "a", "*", "?a", "*a*b", "a*c?b", "abc*def*ghi", "abc*def*ghi" };
            var expectedResults = new bool[] { false, true, false, true, false, true };

            //for (int i = 0; i < testStrings.Length; i++)
            //{
            //    Console.WriteLine($"string={testStrings[i]}, pattern={testPatterns[i]}, match={matchPattern(testStrings[i], testPatterns[i])}");
            //}

            //int i = 3;
            //Console.WriteLine($"string={testStrings[i]}, pattern={testPatterns[i]}, match={matchPattern(testStrings[i], testPatterns[i])}");

            for (int i = 0; i < testStrings.Length; i++)
            {
                if (i == 5)
                {
                    Console.WriteLine($"string={testStrings[i]}, pattern={testPatterns[i]}, match={comparison(testStrings[i], testPatterns[i])}");
                }
            }

            Console.WriteLine("Hello World!");
        }

        static bool matchPattern(string str, string pattern)
        {
            // do simple check to return true or false
            if (pattern == "*")
            {
                return true;
            }

            if (pattern.Contains("*") == false)
            {
                return str.Contains(pattern);
            }

            var subPattern = pattern.Substring(pattern.IndexOf("*") + 1);
            var firstPattern = pattern.IndexOf("*") >= 0 ? pattern.Substring(0, pattern.IndexOf("*")) : pattern;
            int startIndex = 0;

            // recursively
            while (true)
            {
                if (startIndex > str.Length)
                {
                    return false;
                }

                // remove first part
                startIndex = str.IndexOf(firstPattern);
                startIndex += firstPattern.Length;
                string subStr = str.Substring(startIndex);

                if (matchPattern(subStr, subPattern) == true)
                {
                    return true;
                }
            }
        }

        static bool comparison(string str, string pattern)
        {
            int s = 0, p = 0, match = 0, starIdx = -1;

            // abc88888def7777ghi
            // abc*    def*   ghi
            while (s < str.Length)
            {
                // advancing both pointers
                if (p < pattern.Length && (pattern[p] == '?' || str[s] == pattern[p]))
                {
                    s++;
                    p++;
                }
                // * found, only advancing pattern pointer
                else if (p < pattern.Length && pattern[p] == '*')
                {
                    starIdx = p;
                    match = s;
                    p++;
                }
                // last pattern pointer was *, advancing string pointer
                else if (starIdx != -1)
                {
                    p = starIdx + 1;
                    match++;
                    s = match;
                }
                //current pattern pointer is not star, last patter pointer was not *
                //characters do not match
                else return false;
            }

            //check for remaining characters in pattern
            while (p < pattern.Length && pattern[p] == '*')
                p++;

            return p == pattern.Length;
        }
    }
}
