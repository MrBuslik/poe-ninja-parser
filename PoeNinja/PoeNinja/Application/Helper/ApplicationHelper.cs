// <copyright file="ApplicationHelper.cs" company="YLazakovich">
// Copyright (c) YLazakovich. All rights reserved.
// </copyright>

namespace PoeNinja.Application.Helper
{
    using System;
    using System.Collections.Generic;
    using Items.Models;
    using RestSharp;
    using Utils;

    /// <summary>
    /// Helper class.
    /// </summary>
    public abstract class ApplicationHelper
    {
        protected static Dictionary<string, double> storageQualitySkills = new Dictionary<string, double>();
        protected static Dictionary<string, double> storageLvlSkills = new Dictionary<string, double>();

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
        /// <param name="vault">vault with object dates.</param>
        protected static void TakeDataFromVault(Vault vault)
        {
            GetGemSalePrices(vault);
            GetJewelSalePrice(vault);
        }

        /// <summary>
        /// Records gem.Name and gem.Price to dictionary for gem 20lvl/0%quality.
        /// </summary>
        /// <param name="gem">Gem object.</param>
        private static void CollectLvlSkills(Gem gem)
        {
            storageLvlSkills[gem.Name] = gem.ChaosValue;
        }

        /// <summary>
        /// Records gem.Name and gem.Price to dictionary for gem 1lvl/20%quality.
        /// </summary>
        /// <param name="gem">Gem object.</param>
        private static void CollectQualitySkills(Gem gem)
        {
            storageQualitySkills[gem.Name] = gem.ChaosValue;
        }

        /// <summary>
        /// Returns collection after comparison.
        /// </summary>
        /// <param name="one">Dictionary with item_name and item_price.</param>
        /// <param name="two">same.</param>
        /// <returns>Dictionary collection type.</returns>
        private static Dictionary<string, double> ReceiveMargin(Dictionary<string, double> one,
            Dictionary<string, double> two)
        {
            Dictionary<string, double> smallDict = new Dictionary<string, double>();
            Dictionary<string, double> bigDict = new Dictionary<string, double>();

            bool isSmall = storageLvlSkills.Count < storageQualitySkills.Count;

            switch (isSmall)
            {
                case true:
                    smallDict = one;
                    bigDict = two;
                    break;
                case false:
                    smallDict = two;
                    bigDict = one;
                    break;
            }

            Dictionary<string, double> final = new Dictionary<string, double>();

            string key = string.Empty;
            double price;

            foreach (var item in smallDict)
            {
                key = item.Key;
                price = bigDict[key] - smallDict[key];

                if (price > 7)
                {
                    final[key] = price;
                }
            }

            return final;
        }

        protected static void GetGemSalePrices(Vault vault)
        {
            List<Gem> skills = vault.Storage[Constants.Gem];

            foreach (var skill in skills)
            {
                if (!skill.Corrupted && skill.GemLevel == 20 && skill.Variant.Equals("20"))
                {
                    CollectLvlSkills(skill);
                }
                else if (!skill.Corrupted && skill.GemLevel == 1 && skill.GemQuality == 20)
                {
                    CollectQualitySkills(skill);
                }
            }

            Console.WriteLine($"\nThere are Gems 20lvl/1% : {storageLvlSkills.Count}");
            Console.WriteLine($"There are Gems 1lvl/20% : {storageQualitySkills.Count}\n");

            var final = ReceiveMargin(storageLvlSkills, storageQualitySkills);

            foreach (var variable in final)
            {
                Console.WriteLine($"{variable.Key} : {variable.Value}");
            }
        }

        protected static void GetJewelSalePrice(Vault vault)
        {
            List<Jewel> jewels = vault.Storage[Constants.Jewel];

            Console.WriteLine("\n-----JEWEL RECIPE-------");
            Console.WriteLine("Primordial Might\nPrimordial Harmony\nPrimordial Eminence");

            double price = 0;

            foreach (var jewel in jewels)
            {
                if (jewel.Name == "The Anima Stone")
                {
                    price = jewel.ChaosValue;
                }

                if (jewel.Name == "Primordial Might")
                {
                    price -= jewel.ChaosValue;
                }

                if (jewel.Name == "Primordial Harmony")
                {
                    price -= jewel.ChaosValue;
                }

                if (jewel.Name == "Primordial Eminence")
                {
                    price -= jewel.ChaosValue;
                }
            }

            Console.WriteLine("-----------------------");
            Console.WriteLine($"From sale you will get : {price}");
            Console.WriteLine("-----------------------");
        }
    }
}