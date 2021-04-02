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

        public string WordSplit(string[] strArr)
        {
            string WordToSplit = strArr[0];
            string[] ToCheck = strArr[1].ToLower().Split(",");
            //any other input check goes here...
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
    }
}
