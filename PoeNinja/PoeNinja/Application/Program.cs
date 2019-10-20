// <copyright file="Program.cs" company="YLazakovich">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoeNinja.Application
{
    using System;
    using Utils;
    using Helper;
    using RestSharp;

    /// <summary>
    /// Makes run console application
    /// </summary>
    public class Program : ApplicationHelper
    {
        public static void Main(string[] args)
        {
            RestClient client = new RestClient
            {
                BaseHost = "poe.ninja",
                BaseUrl = new Uri(Constants.Url)
            };

            ResponseWrapper responseWrapper = new ResponseWrapper(client);

            var response = responseWrapper.GetSkillInfo();
            
            Console.WriteLine(ConvertResponseToJson(response));

//            json = ApiController.GetJson(url: url);
//            JObject jObject = JObject.Parse(json);

//            InitJson(jObject);

//            Reseller.PrintItemWithProfit();
        }
    }
}