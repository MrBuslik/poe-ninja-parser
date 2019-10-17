// <copyright file="Program.cs" company="YLazakovich">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoeNinja.Application
{
    using Helper;
    using Newtonsoft.Json.Linq;
    using Utils;

    internal class Program : ApplicationHelper
    {
        private static string url = "https://poe.ninja/api/data/itemoverview?league=Blight&type=SkillGem";

        public static void Main(string[] args)
        {
            string json = string.Empty;

            json = ApiController.GetJson(url: url);
            JObject jObject = JObject.Parse(json);

            InitJson(jObject);

            Reseller.PrintItemWithProfit();
        }
    }
}