using System;

namespace WordSplit
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            string[] testArray = { "catzzz", "apple,bat,cat,goodbye,hell,heLlo,yellow,why,,zee,zzz" };

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
            string[] ToCheck = strArr[1].Split(',');
            for (int i = 0; i < ToCheck.Length; i++)
            {
                if (!string.IsNullOrEmpty(ToCheck[i]))
                {
                    if (WordToSplit.ToLower().Contains(ToCheck[i].ToLower()))
                    {
                        //Check if another word also contain within the remaining letters
                        for (int o = 0; o < ToCheck.Length; o++)
                        {
                            if (!string.IsNullOrEmpty(ToCheck[o]) && (ToCheck[i] + ToCheck[o]).ToLower() == WordToSplit.ToLower())
                            {
                                result += ToCheck[i] + "," + ToCheck[o];
                                return result; //Located the 2 words within WordToSplit. End the checking loop and return result
                            }
                        }
                    }
                }
            }

            return "Unable to split into 2 words from given list";
        }
    }
}
