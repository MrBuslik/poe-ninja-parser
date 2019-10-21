// <copyright file="Program.cs" company="YLazakovich">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoeNinja.Application
{
    using System;
    using Items;
    using Helper;
    using Newtonsoft.Json;
    using RestSharp;
    using Utils;

    /// <summary>
    /// Makes run console application
    /// </summary>
    public class Program : ApplicationHelper
    {
        public static void Main()
        {
            RestClient client = new RestClient
            {
                BaseHost = "poe.ninja",
                BaseUrl = new Uri(Constants.Url)
            };

            ResponseWrapper responseWrapper = new ResponseWrapper(client);

            var response = responseWrapper.GetSkillInfo();

            Gems list = JsonConvert.DeserializeObject<Gems>(ConvertResponseToJson(response));

            Console.WriteLine(ConvertResponseToJson(response));
        }
    }
}