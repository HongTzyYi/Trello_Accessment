/*String Period Problem
 *Have the function StringPeriods(str) take the str parameter being passed and determine if there is some substring K that can be repeated 
 *N > 1 times to produce the input string exactly as it appears. Your program should return the longest substring K, and if there is none it 
 *should return the string -1.
 *For example: if str is "abcababcababcab" then your program should return abcab because that is the longest substring that is 
 *repeated 3 times to create the final string. Another example: if str is "abababababab" then your program should return ababab because 
 *it is the longest substring. If the input string contains only a single character, your program should return the string -1. 
 */

using System;
using System.Linq;

namespace StringPeriods
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            string testInput = "abcabcabc";
            Console.WriteLine("Base string: " + testInput);
            Console.WriteLine(program.StringPeriod(testInput));
        }
        public string StringPeriod(string input)
        {
            if(input.Length <= 1)
            {
                return "-1";
            }

            for (int i = 0; i < input.Length/2; i++)
            {
                string Pattern = input.Substring(0, (input.Length / 2) - i);
                if (string.IsNullOrEmpty(input.Replace(Pattern, "")))
                {
                    return "Longest repeating pattern: " + Pattern;
                }
            }
            return "No repeating pattern in this string!";
        }
    }
}