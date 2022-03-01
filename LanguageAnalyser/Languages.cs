using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LanguageAnalyser
{
    class Languages
    {
        public Dictionary<char, decimal> English = new Dictionary<char, decimal>();
        private string alphabet = "abcdefghijklmnopqrstuvwxyz";

        public string[] ReadLanguageFile()
        {
            string[] content = File.ReadAllLines(@"M:\Student16\Areas$\2016199\Programming\LanguageAnalyser\LanguageAnalyser\English.txt");
            return content;
        }

        public Dictionary<string, List<decimal>> ParseData()
        {
            string[] languageData = ReadLanguageFile();
            Dictionary<string, List<decimal>> languageFrequencies = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < 15; i++)
            {
                List<decimal> SpecificLanguageFrequencies = new List<decimal>();
                foreach (string index in languageData)
                {
                    string[] decimalValue = index.Trim().Split(":");
                    SpecificLanguageFrequencies.Add(Decimal.Parse(decimalValue[i]));
                }
                languageFrequencies.Add(i.ToString(), SpecificLanguageFrequencies);
            }

            return languageFrequencies;
        }
    }
}
