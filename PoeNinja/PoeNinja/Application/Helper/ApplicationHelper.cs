// <copyright file="ApplicationHelper.cs" company="YLazakovich">
// Copyright (c) YLazakovich. All rights reserved.
// </copyright>

namespace PoeNinja.Application.Helper
{
    using System;
    using System.Collections.Generic;
    using Items;
    using RestSharp;

    /// <summary>
    /// Helper class.
    /// </summary>
    public abstract class ApplicationHelper
    {
        private static IDictionary<string, object> lvlDictionary = new Dictionary<string, object>();
        private static IDictionary<string, object> qualityDictionary = new Dictionary<string, object>();
        
        /// <summary>
        /// Returns response content in json format.
        /// </summary>
        /// <param name="response">response.</param>
        /// <returns>JSON Content.</returns>
        protected static string ConvertResponseToJson(IRestResponse response)
        {
            response.ContentType = "application/json";

            return response.Content;
        }

        /// <summary>
        /// Looks profit positions from vault.
        /// </summary>
        /// <param name="vault">vaults with object dates.</param>
        protected static void TakeDataFromVault(ItemVault vault)
        {
            foreach (var item in vault.SkillGems)
            {
                if (!item.Corrupted && item.GemLevel == 20 && item.Variant.Equals("20"))
                {
                    InitLvlGem(item);
                }
                else if (!item.Corrupted && item.GemLevel == 1 && item.GemQuality == 20)
                {
                    InitQualityGem(item);
                }
            }

            Console.WriteLine($"\nThere are Gems 20lvl/1% : {lvlDictionary.Count}");
            Console.WriteLine($"There are Gems 1lvl/20% : {qualityDictionary.Count}\n");
        }

        private static void InitLvlGem(Gem gem)
        {
            lvlDictionary[gem.Name] = gem;
        }

        private static void InitQualityGem(Gem gem)
        {
            qualityDictionary[gem.Name] = gem;
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

                if (price > price)
                {
                    finalDictionary[key] = price;
                }
            }

            return finalDictionary;
        }
    }
}