// <copyright file="Reseller.cs" company="YLazakovich">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoeNinja.Application.Utils
{
    using System.Collections.Generic;
    using Helper;

    /// <summary>
    /// Helps to search profitable items
    /// </summary>
    public class Reseller : ApplicationHelper
    {
        private const double LowPrice = 7.0;

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