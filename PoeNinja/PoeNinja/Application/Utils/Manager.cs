namespace PoeNinja.Application.Utils
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json.Linq;
    using Model;

    public class Manager
    {
        public static void InitJson(JObject jObject)
        {
            Gem item = new Gem();
            List<Gem> pList = new List<Gem>();
            List<Gem> qList = new List<Gem>();
            
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
                    pList.Add(item);
                }

                if (!item.corrupted && item.gemLevel == 1 && item.gemQuality == 20)
                {
                    qList.Add(item);
                }
            }
        }
    }
}