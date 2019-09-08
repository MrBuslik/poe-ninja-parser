using System.Linq;

namespace PoeNinja.Application.Utils
{
    using System.Collections.Generic;
    using System;
    using Helper;

    public class Reseller : ApplicationHelper
    {
        public static void InvestigateItemPositions()
        {

            var result = CompareDict(lvlDictionary, qualityDictionary);

            Console.WriteLine($"Total profitable positions: {result.Count}\n");

            foreach (var item in result.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"\"{item.Key}\" : \"{item.Value}\"");
            }
        }

        private static Dictionary<string, double> CompareDict(Dictionary<string, double> d1,
            Dictionary<string, double> d2)
        {
            Dictionary<string, double> result = new Dictionary<string, double>();

            Dictionary<string, double> min = d1.Keys.Count <= d2.Keys.Count ? d1 : d2;
            Dictionary<string, double> max = d2.Keys.Count <= d1.Keys.Count ? d1 : d2;
            

            string key = string.Empty;
            double price;
            double lowPrice = 7.0;

            foreach (var item in min)
            {
                key = item.Key;
                price = max[key] - min[key];

                if (lowPrice < price)
                {
                    result[key] = price;
                }
            }
            
            return result;
        }
    }
}