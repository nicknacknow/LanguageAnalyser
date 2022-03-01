using System;
using System.Collections.Generic;

namespace LanguageAnalyser
{
    class Program
    {
        private static string alphabet = "abcdefghijklmnopqrstuvwxyz";
        static Dictionary<char, int> CountLetters(string text)
        {
            Dictionary<char, int> letterFrequencies = new Dictionary<char, int>();

            foreach (char c in alphabet)
            {
                letterFrequencies.Add(c, 0);
            }

            foreach (char c in text)
            {
                if (alphabet.Contains(char.ToLower(c)))
                {
                    letterFrequencies[char.ToLower(c)]++;
                }
            }

            return letterFrequencies;
        }

        static Dictionary<char, decimal> AnalyseLetterCount(Dictionary<char, int> letters)
        {
            int whatever = 0;
            foreach (KeyValuePair<char, int> pairs in letters)
            {
                whatever += pairs.Value;
            }

            Dictionary<char, decimal> letterFreq = new Dictionary<char, decimal>();

            foreach (KeyValuePair<char, int> pairs in letters)
            {
                letterFreq.Add(pairs.Key, Convert.ToDecimal(pairs.Value) / Convert.ToDecimal(whatever));
            }

            return letterFreq;
        }

        static List<decimal> VectoriseCount(Dictionary<char, decimal> letterFreq)
        {
            List<decimal> local = new List<decimal>();

            foreach (KeyValuePair<char, decimal> pair in letterFreq)
            {
                local.Add(pair.Value);
            }

            return local;
        }

        static decimal CompareToLanguage(int languageID, List<decimal> bodyTextCount)
        {
            List<decimal> list = new Languages().ParseData()[languageID.ToString()];
            List<decimal> residuals = new List<decimal>();

            for (int i = 0; i < list.Count; i++)
            {
                residuals.Add(Math.Abs(bodyTextCount[i] * 100 - list[i]));
            }

            decimal residualCumulative = 0;
            foreach (decimal d in residuals)
            {
                residualCumulative += d;
            }

            return residualCumulative;
        }

        static int CompareToAllLanguages(string bodyText)
        {
            var bodyVector = VectoriseCount(AnalyseLetterCount(CountLetters(bodyText)));

            List<decimal> residualCumulatives = new List<decimal>();

            for (int i = 0; i < 15; i++)
            {
                residualCumulatives.Add(CompareToLanguage(i, bodyVector));
            }

            int lowestIndex = 0;
            decimal lowestDecimal = 101;
            for (int i = 0; i < 15; i++)
            {
                if (residualCumulatives[i] < lowestDecimal)
                {
                    lowestIndex = i;
                    lowestDecimal = residualCumulatives[i];
                }
            }

            return lowestIndex;
        }

        static string LanguageNameFromID(int id)
        {
            switch (id)
            {
                case 0:
                    return "English";
                case 1:
                    return "French";
                case 2:
                    return "German";
                case 3:
                    return "Spanish";
                case 4:
                    return "Portuguese";
                case 5:
                    return "Esperanto";
                case 6:
                    return "Italian";
                case 7:
                    return "Turkish";
                case 8:
                    return "Swedish";
                case 9:
                    return "Polish";
                case 10:
                    return "Dutch";
                case 11:
                    return "Danish";
                case 12:
                    return "Icelandic";
                case 13:
                    return "Finnish";
                case 14:
                    return "Czech";
            }
            return "wtf is wrong with u";
        }
        static void Main(string[] args)
        {
            while (true)
            {


                int lang = CompareToAllLanguages(Console.ReadLine());


                Console.WriteLine(LanguageNameFromID(lang));

            }

            /*Dictionary<char, int> dict = CountLetters("hello");
            Dictionary<char, decimal> dict2 = AnalyseLetterCount(dict);
            List<decimal> dict3 = VectoriseCount(dict2);

            foreach(decimal d in dict3)
            {
                Console.WriteLine(d);
            }*/

            /*foreach (KeyValuePair<char, decimal> pair in dict2)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }*/
        }
    }
}
