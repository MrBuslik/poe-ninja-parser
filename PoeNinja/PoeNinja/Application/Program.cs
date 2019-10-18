// <copyright file="Program.cs" company="YLazakovich">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoeNinja.Application
{
    using Helper;
    using Newtonsoft.Json.Linq;
    using Utils;

    /// <summary>
    /// Makes run console application
    /// </summary>
    public class Program : ApplicationHelper
    {
        private const string Url = "https://poe.ninja/api/data/itemoverview?league=Blight&type=SkillGem";

        public static void Main()
        {
            string json = string.Empty;

            json = ApiController.GetJson(url: Url);
            JObject jObject = JObject.Parse(json);

            InitJson(jObject);

            Reseller.PrintItemWithProfit();
        }
    }
}