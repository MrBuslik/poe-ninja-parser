// <copyright file="ApplicationHelper.cs" company="YLazakovich">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoeNinja.Application.Helper
{
    using System;
    using System.Collections.Generic;
    using Items;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Helper class
    /// </summary>
    public abstract class ApplicationHelper
    {
        protected static readonly Dictionary<string, double> QualityDictionary = new Dictionary<string, double>();
        protected static readonly Dictionary<string, double> LvlDictionary = new Dictionary<string, double>();

        protected static void InitJson(JObject jObject)
        {
            Gem item = new Gem();

            foreach (var jsonItem in jObject["lines"])
            {
                item.Name = jsonItem["name"].ToString();
                item.Variant = jsonItem["variant"].ToString();
                item.GemLevel = Convert.ToInt16(jsonItem["gemLevel"]);
                item.GemQuality = Convert.ToInt16(jsonItem["gemQuality"]);
                item.Corrupted = Convert.ToBoolean(jsonItem["corrupted"]);
                item.ChaosValue = Convert.ToDouble(jsonItem["chaosValue"]);

                if (!item.Corrupted && item.GemLevel == 20 && item.Variant.Equals("20"))
                {
                    InitLvlGem(item);
                }
                else if (!item.Corrupted && item.GemLevel == 1 && item.GemQuality == 20)
                {
                    InitQualityGem(item);
                }
            }

            Console.WriteLine($"\nThere are Gems 20lvl/1% : {LvlDictionary.Count}");
            Console.WriteLine($"There are Gems 1lvl/20% : {QualityDictionary.Count}\n");
        }

        private static void InitLvlGem(Gem gem)
        {
            LvlDictionary[gem.Name] = gem.ChaosValue;
        }

        private static void InitQualityGem(Gem gem)
        {
            QualityDictionary[gem.Name] = gem.ChaosValue;
        }
    }
}