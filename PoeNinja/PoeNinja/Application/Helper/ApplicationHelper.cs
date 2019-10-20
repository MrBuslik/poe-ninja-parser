namespace PoeNinja.Application.Helper
{
    using RestSharp;
    using System;
    using System.Collections.Generic;
    using Items;
    using Newtonsoft.Json.Linq;

    public abstract class ApplicationHelper
    {
        protected static Dictionary<string, double> lvlDictionary = new Dictionary<string, double>();
        protected static Dictionary<string, double> qualityDictionary = new Dictionary<string, double>();

        public static void InitJson(JObject jObject)
        {
            Gem item = new Gem();

            foreach (var jsonItem in jObject["lines"])
            {
                item.name = jsonItem["name"].ToString();
                item.variant = jsonItem["variant"].ToString();
                item.gemLevel = Convert.ToInt16(jsonItem["gemLevel"]);
                item.gemQuality = Convert.ToInt16(jsonItem["gemQuality"]);
                item.corrupted = Convert.ToBoolean(jsonItem["corrupted"]);
                item.chaosValue = Convert.ToDouble(jsonItem["chaosValue"]);

                if (!item.corrupted && item.gemLevel == 20 && item.variant.Equals("20"))
                {
                    InitLvlGem(item);
                }
                else if (!item.corrupted && item.gemLevel == 1 && item.gemQuality == 20)
                {
                    InitQualityGem(item);
                }
            }
            
            Console.WriteLine($"\nThere are Gems 20lvl/1% : {lvlDictionary.Count}");
            Console.WriteLine($"There are Gems 1lvl/20% : {qualityDictionary.Count}\n");
        }

        public static string ConvertResponseToJson(IRestResponse response)
        {
            response.ContentType = "application/json";
            
            return response.Content;
        }

        private static void InitLvlGem(Gem gem)
        {
            lvlDictionary[gem.name] = gem.chaosValue;
        }

        private static void InitQualityGem(Gem gem)
        {
            qualityDictionary[gem.name] = gem.chaosValue;
        }
    }
}