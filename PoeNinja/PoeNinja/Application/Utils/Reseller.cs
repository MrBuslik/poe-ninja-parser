// <copyright file="Reseller.cs" company="YLazakovich">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoeNinja.Application.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Helper;

    public class Reseller : ApplicationHelper
    {
        private const double LowPrice = 7.0;

        public static void PrintItemWithProfit()
        {
            var result = CompareDict(LvlDictionary, QualityDictionary);

            Console.WriteLine($"Total profitable positions: {result.Count}\n");

            foreach (var item in result.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"\"{item.Key}\" : \"{item.Value}\"");
            }
        }

        private static Dictionary<string, double> CompareDict(
            Dictionary<string, double> d1,
            Dictionary<string, double> d2)
        {
            Dictionary<string, double> finalDictionary = new Dictionary<string, double>();

            string key = string.Empty;
            double price;

            foreach (var item in d1)
            {
                key = item.Key;
                price = d2[key] - d1[key];

                if (price > LowPrice)
                {
                    finalDictionary[key] = price;
                }
            }

            return finalDictionary;
        }
    }
}