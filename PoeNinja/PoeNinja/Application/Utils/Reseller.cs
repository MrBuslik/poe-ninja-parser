using System.Linq;

namespace PoeNinja.Application.Utils
{
    using System.Collections.Generic;
    using System;
    using Helper;

    public class Reseller : ApplicationHelper
    {
        public static void PrintItemWithProfit()
        {

            var result = CompareDict(lvlDictionary, qualityDictionary);

            Console.WriteLine($"Total profitable values: {result.Count}\n");

            foreach (var item in result)
            {
                Console.WriteLine($"\"{item.Key}\" : \"{item.Value}\"");
            }
        }

        private static Dictionary<string, double> CompareDict(Dictionary<string, double> d1,
            Dictionary<string, double> d2)
        {
            Dictionary<string, double> finalDictionary = new Dictionary<string, double>();

            string key = string.Empty;
            double price = Double.MinValue;
            double lowPrice = 7.0;

            foreach (var item in d1)
            {
                key = item.Key;
                price = d2[key] - d1[key];

                if (price > lowPrice)
                {
                    finalDictionary[key] = price;
                }
            }
            
            return finalDictionary;
        }
    }
}