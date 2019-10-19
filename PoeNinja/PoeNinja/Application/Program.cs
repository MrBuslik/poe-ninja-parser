// <copyright file="Program.cs" company="YLazakovich">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoeNinja.Application
{
    using System;
    using RestSharp;
    using Helper;
    using Newtonsoft.Json.Linq;
    using Utils;

    /// <summary>
    /// Makes run console application
    /// </summary>
    public class Program : ApplicationHelper
    {
        // TODO PROTOYPE IS DONE WITH REST can to start refactoring code;

        public static void Main(string[] args)
        {
            // TODO remove before merge;
            var league = "Blight";
            var item = "SkillGem";

            string url = "https://poe.ninja/api/data/itemoverview";

            RestClient client = new RestClient
            {
                BaseHost = "poe.ninja",
                BaseUrl = new Uri(url)
            };

            RestRequest request = new RestRequest
            {
                Method = Method.GET,
                Parameters =
                {
                    new Parameter("league", league, ParameterType.QueryString),
                    new Parameter("type", item, ParameterType.QueryString),
                }
            };

            var response = client.Execute(request);

            response.ContentType = "application/json";

            string json = response.Content;
            Console.WriteLine(json);

//            json = ApiController.GetJson(url: url);
//            JObject jObject = JObject.Parse(json);

//            InitJson(jObject);

//            Reseller.PrintItemWithProfit();
        }
    }
}