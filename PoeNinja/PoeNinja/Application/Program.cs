﻿namespace PoeNinja.Application
{
    using System;
    using Helper;
    using Newtonsoft.Json.Linq;
    using Utils;

    internal class Program : ApplicationHelper
    {
        static string url = @"https://poe.ninja/api/data/itemoverview?league=Blight&type=SkillGem";

        public static void Main(string[] args)
        {
            string json = string.Empty;

            json = ApiController.GetJson(url: url);
            JObject jObject = JObject.Parse(json);

            InitJson(jObject);
            
            Reseller.InvestigateItemPositions();
            Console.ReadLine();
        }
    }
}