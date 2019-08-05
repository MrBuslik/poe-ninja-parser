namespace PoeNinja
{
    using Model;
    using Helper;
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;

    internal class Program
    {
        static string url = @"https://poe.ninja/api/data/itemoverview?league=Legion&type=SkillGem";

        public static void Main(string[] args)
        {
            string json = string.Empty;

            json = ApiController.GetHtml(url: url);
            JObject jObject = JObject.Parse(json);
            

        }
    }
}