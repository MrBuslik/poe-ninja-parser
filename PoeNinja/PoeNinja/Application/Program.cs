// <copyright file="Program.cs" company="YLazakovich">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using RestSharp;

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
        // TODO PROTOYPE IS DONE WITH REST can to start refactoring code;
        
        public static void Main(string[] args)
        {
            // TODO remove before merge;
            // var league = args[0];
            var league = "Blight";
            var item = "SkillGem";
            
//            string url = $"https://poe.ninja/api/data/itemoverview?league={league}&type=SkillGem";
            string url = "https://poe.ninja/api/data/itemoverview";

            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest
            {
                Method = Method.GET,
                Parameters =
                {
                    new Parameter("league", league, ParameterType.QueryString),
                    new Parameter("type", item, ParameterType.QueryString),
                    new Parameter("Content-Type", "application/json", ParameterType.HttpHeader),
                    new Parameter("Host", "poe.ninja", ParameterType.HttpHeader),
                }
            };
            
            var response = client.Execute(request);

            Console.WriteLine(response.Content);
            
            string json = string.Empty;

//            json = ApiController.GetJson(url: url);
//            JObject jObject = JObject.Parse(json);

//            InitJson(jObject);

//            Reseller.PrintItemWithProfit();
        }
    }
}