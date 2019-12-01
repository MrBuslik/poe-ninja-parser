// <copyright file="ApplicationHelper.cs" company="YLazakovich">
// Copyright (c) YLazakovich. All rights reserved.
// </copyright>

namespace PoeNinja.Application.Helper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Items.Models;
    using RestSharp;
    using Utils;

    /// <summary>
    /// Helper class.
    /// </summary>
    public abstract class ApplicationHelper
    {
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
        protected static void GetProfitFromVault(Vault vault)
        {
            GetSkillsSalePrices(vault);
            GetJewelSalePrice(vault);
            GetBowSalePrice(vault);
            GetAxeSalePrice(vault);
        }

        /// <summary>
        /// Returns expected profit from SkillGems.
        /// Profit gets from craft and sale on market.
        /// </summary>
        /// <param name="vault">vault with object dates.</param>
        protected static void GetSkillsSalePrices(Vault vault)
        {
            Dictionary<string, double> storageQualitySkills = new Dictionary<string, double>();
            Dictionary<string, double> storageLvlSkills = new Dictionary<string, double>();

            List<Gem> skills = vault.Storage[Constants.Gem];

            foreach (var skill in skills)
            {
                if (!skill.Corrupted && skill.GemLevel == 20 && skill.Variant.Equals("20"))
                {
                    storageLvlSkills[skill.Name] = skill.ChaosValue;
                }
                else if (!skill.Corrupted && skill.GemLevel == 1 && skill.GemQuality == 20)
                {
                    storageQualitySkills[skill.Name] = skill.ChaosValue;
                }
            }

            var final = ReceiveMargin(storageLvlSkills, storageQualitySkills);

            Console.WriteLine("-------Skills for sale---------");
            Console.WriteLine($"There are Skills 20lvl/1% : {storageLvlSkills.Count}");
            Console.WriteLine($"There are Skills 1lvl/20% : {storageQualitySkills.Count}");
            Console.WriteLine("------------------------------");

            foreach (var variable in final)
            {
                Console.WriteLine($"{variable.Key} : {variable.Value}");
            }

            Console.WriteLine("------------------------------");
        }

        /// <summary>
        /// Returns expected profit from The Anima Jewel.
        /// Profit gets from craft and sale on market.
        /// </summary>
        /// <param name="vault">vault with object dates.</param>
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

            Console.WriteLine("------------------------------");
            Console.WriteLine($"From sale you will get : {price}");
            Console.WriteLine("------------------------------");
        }

        protected static void GetBowSalePrice(Vault vault)
        {
            List<Weapon> weapons = vault.Storage[Constants.Weapon];

            Console.WriteLine("\n-----BOW RECIPE-------");
            Console.WriteLine("Grelwood Shank\nBeltimber Blade\n1 orb of fuse");
            Console.WriteLine("------------------------------");

            double price = 0;

            foreach (var weapon in weapons)
            {
                if (weapon.Name == "Grelwood Shank")
                {
                    price += weapon.ChaosValue;
                }

                if (weapon.Name == "Beltimber Blade")
                {
                    price += weapon.ChaosValue;
                }

                if (weapon.Name == "Arborix" && weapon.Links == 6)
                {
                    Console.WriteLine($"From sale 6-link bow you will get: {weapon.ChaosValue - price}");
                }

                if (weapon.Name == "Arborix" && weapon.Links == 5)
                {
                    Console.WriteLine($"From sale 5-link bow you will get: {weapon.ChaosValue - price}");
                }

                if (weapon.Name == "Arborix" && weapon.Links == 0)
                {
                    Console.WriteLine($"From sale 0-4 link bow you will get: {weapon.ChaosValue - price}");
                }
            }

            Console.WriteLine("------------------------------");
        }

        protected static void GetAxeSalePrice(Vault vault)
        {
            List<Weapon> weapons = vault.Storage[Constants.Weapon];

            Console.WriteLine("\n-----AXE RECIPE-------");
            Console.WriteLine("Soul Taker\nHeartbreaker\n1 orb of fuse");
            Console.WriteLine("------------------------------");

            double price = 0;

            foreach (var weapon in weapons)
            {
                if (weapon.Name == "Soul Taker")
                {
                    price += weapon.ChaosValue;
                }

                if (weapon.Name == "Heartbreaker")
                {
                    price += weapon.ChaosValue;
                }

                if (weapon.Name == "Kingmaker" && weapon.Links == 6)
                {
                    Console.WriteLine($"From sale 6-link axe you will get: {weapon.ChaosValue - price}");
                }

                if (weapon.Name == "Kingmaker" && weapon.Links == 5)
                {
                    Console.WriteLine($"From sale 5-link axe you will get: {weapon.ChaosValue - price}");
                }

                if (weapon.Name == "Kingmaker" && weapon.Links == 0)
                {
                    Console.WriteLine($"From sale 0-4 link axe you will get: {weapon.ChaosValue - price}");
                }
            }

            Console.WriteLine("------------------------------");
        }

        /// <summary>
        /// Returns dictionary collection after custom comparing.
        /// </summary>
        /// <param name="one">Dictionary with item_name and item_price.</param>
        /// <param name="two">same.</param>
        /// <returns>Dictionary collection with item for sale.</returns>
        private static Dictionary<string, double> ReceiveMargin(
            Dictionary<string, double> one,
            Dictionary<string, double> two)
        {
            Dictionary<string, double> smallDict = new Dictionary<string, double>();
            Dictionary<string, double> bigDict = new Dictionary<string, double>();

            switch (one.Count <= two.Count)
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

                if (!smallDict.ContainsKey(key) || !bigDict.ContainsKey(key))
                {
                    continue;
                }

                price = bigDict[key] - smallDict[key];

                if (price > 7)
                {
                    final[key] = price;
                }
            }

            return final.OrderByDescending(x => x.Value).ToDictionary(y => y.Key, z => z.Value);
        }

        /// <summary>
        /// Returns dictionary SkillGems.
        /// </summary>
        /// <param name="vault">vault with object dates.</param>
        /// <returns>Dictionary SkillGems.</returns>
        protected static IDictionary<string, double> GetDictionarySkills(Vault vault)
        {
            Dictionary<string, double> storageQualitySkills = new Dictionary<string, double>();
            Dictionary<string, double> storageLvlSkills = new Dictionary<string, double>();

            List<Gem> skills = vault.Storage[Constants.Gem];

            foreach (var skill in skills)
            {
                if (!skill.Corrupted && skill.GemLevel == 20 && skill.Variant.Equals("20"))
                {
                    storageLvlSkills[skill.Name] = skill.ChaosValue;
                }
                else if (!skill.Corrupted && skill.GemLevel == 1 && skill.GemQuality == 20)
                {
                    storageQualitySkills[skill.Name] = skill.ChaosValue;
                }
            }

            return ReceiveMargin(storageLvlSkills, storageQualitySkills);
        }

        /// <summary>
        /// Returns expected profit from The Anima Jewel.
        /// Profit gets from craft and sale on market.
        /// </summary>
        /// <param name="vault">vault with object dates.</param>
        /// <returns>Dictionary recipe of Golem Jewel.</returns>
        protected static IDictionary<string, double> GetDictionaryRecipeJewel(Vault vault)
        {
            List<Jewel> jewels = vault.Storage[Constants.Jewel];
            IDictionary<string, double> jewelRecipe = new Dictionary<string, double>();

            foreach (var jewel in jewels)
            {
                if (jewel.Name == "The Anima Stone")
                {
                    jewelRecipe[jewel.Name] = jewel.ChaosValue;
                }

                if (jewel.Name == "Primordial Might")
                {
                    jewelRecipe[jewel.Name] = jewel.ChaosValue;
                }

                if (jewel.Name == "Primordial Harmony")
                {
                    jewelRecipe[jewel.Name] = jewel.ChaosValue;
                }

                if (jewel.Name == "Primordial Eminence")
                {
                    jewelRecipe[jewel.Name] = jewel.ChaosValue;
                }
            }

            return jewelRecipe;
        }

        /// <summary>
        /// Returns expected profit from Bow.
        /// Profit gets from craft and sale on market.
        /// </summary>
        /// <param name="vault">vault with object dates.</param>
        /// <returns>Dictionary recipe of Bow.</returns>
        protected static IDictionary<string, double> GetDictionaryRecipeBow(Vault vault)
        {
            List<Weapon> weapons = vault.Storage[Constants.Weapon];
            Dictionary<string, double> recipe = new Dictionary<string, double>();

            foreach (var weapon in weapons)
            {
                if (weapon.Name == "Grelwood Shank")
                {
                    recipe[weapon.Name] = weapon.ChaosValue;
                }

                if (weapon.Name == "Beltimber Blade")
                {
                    recipe[weapon.Name] = weapon.ChaosValue;
                }

                if (weapon.Name == "Arborix" && weapon.Links == 6)
                {
                    recipe[$"{weapon.Name} [6 link]"] = weapon.ChaosValue;
                }

                if (weapon.Name == "Arborix" && weapon.Links == 5)
                {
                    recipe[$"{weapon.Name} [5 link]"] = weapon.ChaosValue;
                }

                if (weapon.Name == "Arborix" && weapon.Links == 0)
                {
                    recipe[$"{weapon.Name} [0-4 link]"] = weapon.ChaosValue;
                }
            }

            return recipe;
        }

        /// <summary>
        /// Returns expected profit from Axe.
        /// Profit gets from craft and sale on market.
        /// </summary>
        /// <param name="vault">vault with object dates.</param>
        /// <returns>Dictionary recipe of Axe.</returns>
        protected static IDictionary<string, double> GetDictionaryRecipeAxe(Vault vault)
        {
            List<Weapon> weapons = vault.Storage[Constants.Weapon];
            Dictionary<string, double> recipe = new Dictionary<string, double>();

            foreach (var weapon in weapons)
            {
                if (weapon.Name == "Soul Taker")
                {
                    recipe[weapon.Name] = weapon.ChaosValue;
                }

                if (weapon.Name == "Heartbreaker")
                {
                    recipe[weapon.Name] = weapon.ChaosValue;
                }

                if (weapon.Name == "Kingmaker" && weapon.Links == 6)
                {
                    recipe[$"{weapon.Name} [6 link]"] = weapon.ChaosValue;
                }

                if (weapon.Name == "Kingmaker" && weapon.Links == 5)
                {
                    recipe[$"{weapon.Name} [5 link]"] = weapon.ChaosValue;
                }

                if (weapon.Name == "Kingmaker" && weapon.Links == 0)
                {
                    recipe[$"{weapon.Name} [0-4 link]"] = weapon.ChaosValue;
                }
            }

            return recipe;
        }
    }
}