// <copyright file="Program.cs" company="YLazakovich">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoeNinja.Application
{
    using System;
    using Helper;
    using Newtonsoft.Json.Linq;
    using Utils;

    /// <summary>
    /// Makes run console application
    /// </summary>
    public class Program : ApplicationHelper
    {
        public static void Main()
        {
            var league = Environment.GetEnvironmentVariable("League");
            
            string url = $"https://poe.ninja/api/data/itemoverview?league={league}&type=SkillGem";

            string json = string.Empty;

            json = ApiController.GetJson(url: url);
            JObject jObject = JObject.Parse(json);

            InitJson(jObject);

            Reseller.PrintItemWithProfit();
        }
    }
}