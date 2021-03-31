/*String Period Problem
 *Have the function StringPeriods(str) take the str parameter being passed and determine if there is some substring K that can be repeated 
 *N > 1 times to produce the input string exactly as it appears. Your program should return the longest substring K, and if there is none it 
 *should return the string -1.
 *For example: if str is "abcababcababcab" then your program should return abcab because that is the longest substring that is 
 *repeated 3 times to create the final string. Another example: if str is "abababababab" then your program should return ababab because 
 *it is the longest substring. If the input string contains only a single character, your program should return the string -1. 
 */

/*Logic Crafting:
 *Assumption: 
 *-For string to repeat itself, the max length for that pattern will always be 1/2 of given string length
 *-Based on problem description, the pattern should be able to fully formed the input string by itself
 *
 *Using Recursion approach:
 *-the starting string to check for would be substring of 1/2 length from given input
 *-check whether the string is being repeated in the given input
 *-If the string repeated more than once, end checking and return result
 *-else call the function again, this time with the checking sting length -1 from previous checking
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
            string testInput = "ababababababa";
            Console.WriteLine("Base string: " + testInput);
            Console.WriteLine(program.StringPeriod(testInput));
        }
        /// <summary>
        /// Base function to handle input checking and find longest repeating pattern in input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string StringPeriod(string input)
        {
            if(input.Length <= 1)
            {
                return "-1";
            }

            /*Apporach 2:
             * -Get substring of 1/2 length of input
             * -Attempt to replace the pattern to determine whether it can be fully replaced
             * -Since this logic check from max length pattern first, thus the moment any pattern able to fully replace input string 
             * will be the longest pattern present in input
             */
            for (int i = 0; i < input.Length/2; i++)
            {
                string Pattern = input.Substring(0, (input.Length / 2) - i);
                if (string.IsNullOrEmpty(input.Replace(Pattern, "")))
                {
                    return "Longest repeating pattern: " + Pattern;
                }
            }
            return "No repeating pattern in this string!";
            //return StringPeriod(input, input.Substring(0, input.Length / 2));
        }
        /// <summary>
        /// Overloaded function to check for longest repeating pattern recursively
        /// </summary>
        /// <param name="BaseInput"></param>
        /// <param name="TestInput"></param>
        /// <returns></returns>
        public string StringPeriod(string BaseInput, string TestInput = "")
        {
            //Count occurence of repeated pattern here
            string[] ToCheck = BaseInput.Split(TestInput);
            if(ToCheck.Length > 2 && ToCheck.All(i => i == ""))
            {
                return "Longest repeating pattern: " + TestInput;
            }
            
            if(TestInput.Length <= 1)
            {
                return "No repeating pattern in this string!";
            }

            return StringPeriod(BaseInput, TestInput.Substring(0, TestInput.Length-1));
        }
    }
}