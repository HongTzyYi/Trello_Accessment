using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordSplit
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            string[] testArray = { "cat", "apple,bat,cat,goodbye,hell,heLlo,yellow,why,,zee,zzz" };

            Array.ForEach<string>(testArray, Console.WriteLine);
            Console.WriteLine(program.WordSplit(testArray));
        }

        /// <summary>
        /// Split the first element in strArr into 2 words containing in the subsequent elements
        /// Assumes the following:
        /// -All inputs are in English
        /// -Splitted words are case insensitive, example "HeLlO" will also be able to split from "helloworld"
        /// -First array element is the word to split and second array element is the list of words to refer when splitting
        /// </summary>
        /// <param name="strArr"></param>
        /// <returns></returns>
        public string WordSplit(string[] strArr)
        {
            string result = string.Empty;

            string WordToSplit = strArr[0];


            //Method 1: Double for loop, check by adding two matching words
            //string[] ToCheck = strArr[1].Split(',');
            //for (int i = 0; i < ToCheck.Length; i++)
            //{
            //    if (!string.IsNullOrEmpty(ToCheck[i]))
            //    {
            //        if (WordToSplit.ToLower().Contains(ToCheck[i].ToLower()))
            //        {
            //            //Check if another word also contain within the remaining letters
            //            for (int o = 0; o < ToCheck.Length; o++)
            //            {
            //                if (!string.IsNullOrEmpty(ToCheck[o]) && (ToCheck[i] + ToCheck[o]).ToLower() == WordToSplit.ToLower())
            //                {
            //                    result += ToCheck[i] + "," + ToCheck[o];
            //                    return result; //Located the 2 words within WordToSplit. End the checking loop and return result
            //                }
            //            }
            //        }
            //    }
            //}
            //return "Unable to split into 2 words from given list";

            //Method 2: one for loop only, done by obtaining the list of remaining letters from first match, then intersect the list with the provided list of words
            List<string> ToCheck = new List<string>(strArr[1].ToLower().Split(","));
            List<string> ToCheck2 = new List<string>();
            for(int i=0; i < ToCheck.Count; i++)
            {
                if (!string.IsNullOrEmpty(ToCheck[i]))
                {
                    if (WordToSplit.ToLower().Contains(ToCheck[i]))
                    {
                        Regex rex = new Regex(ToCheck[i], RegexOptions.IgnoreCase);
                        ToCheck2.Add(rex.Replace(WordToSplit, "", 1));
                    }
                }
            }
            var matchedvalue = ToCheck.Intersect(ToCheck2);
            result = string.Join(",", matchedvalue);

            return result;
        }
    }
}
