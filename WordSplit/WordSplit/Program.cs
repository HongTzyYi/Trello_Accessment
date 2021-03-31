using System;
using System.Collections.Generic;
using System.Linq;

namespace WordSplit
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            string[] testArray = { "hello", "apple,bat,cat,goodbye,hell,heLlo,yellow,why,,zee,zzz" };

            Array.ForEach<string>(testArray, Console.WriteLine);
            Console.WriteLine(program.WordSplit(testArray));
        }

        /// <summary>
        /// Split the first element in strArr into 2 words containing in the subsequent elements
        /// Assumes the following:
        /// -All inputs are in English
        /// -For parameters, first array element is the word to split and second array element is the list of words to refer when splitting
        /// </summary>
        /// <param name="strArr"></param>
        /// <returns></returns>
        public string WordSplit(string[] strArr)
        {
            string WordToSplit = strArr[0];
            string[] ToCheck = strArr[1].ToLower().Split(",");
            //any other input check goes here...

            //List<string> ToCheck2 = new List<string>();
            //for(int i=0; i < ToCheck.Length; i++)
            //{
            //    if (!string.IsNullOrEmpty(ToCheck[i]) && WordToSplit.ToLower().Contains(ToCheck[i]))
            //    {
            //        ToCheck2.Add(ToCheck[i]);
            //        ToCheck2.Add(WordToSplit.Replace(ToCheck[i], ""));
            //    }
            //}
            //var matchedvalue = ToCheck.Intersect(ToCheck2);
            //return string.Join(",", matchedvalue);

            //Split using recursive method
            //return IsWord(WordToSplit, ToCheck);

            //Reimplement recursive logic to for loop
            for(int i=1; i < WordToSplit.Length; i++)
            {
                string SplittedWord = WordToSplit.Substring(0, i);
                string SplittedWord2 = WordToSplit.Substring(i);
                if (ToCheck.Contains(SplittedWord) && ToCheck.Contains(SplittedWord2))
                {
                    return SplittedWord + "," + SplittedWord2;
                }
            }
            return "Not possible to split \"" + WordToSplit + "\" from the given word list!";
        }
        /// <summary>
        /// Recursive function to identify one word from BaseWord using ReferenceWords list, split and return it into two words
        /// </summary>
        /// <param name="BaseWord"></param>
        /// <param name="ReferenceWords"></param>
        /// <returns></returns>
        public string IsWord(string BaseWord, string[] ReferenceWords, int SplitFromLetterCount = 0)
        {
            if(SplitFromLetterCount < BaseWord.Length)
            {
                SplitFromLetterCount++;
                string SplittedWord = BaseWord.Substring(0, SplitFromLetterCount);
                string SplittedWord2 = BaseWord.Substring(SplitFromLetterCount);
                if (ReferenceWords.Contains(SplittedWord) && ReferenceWords.Contains(SplittedWord2))
                {
                    return SplittedWord + "," + SplittedWord2;
                }
            }
            else
            {
                return "Not possible to split \"" + BaseWord + "\" from the given word list!";
            }
            return IsWord(BaseWord, ReferenceWords, SplitFromLetterCount);
        }
    }
}
