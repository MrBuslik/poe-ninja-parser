// <copyright file="Program.cs" company="YLazakovich">
// Copyright (c) YLazakovich. All rights reserved.
// </copyright>

namespace PoeNinja.Application
{
    using System;
    using Helper;
    using Items;
    using Newtonsoft.Json;
    using RestSharp;
    using Utils;

    /// <summary>
    /// Makes run console application.
    /// </summary>
    public class Program : ApplicationHelper
    {
        public static void Main()
        {
            RestClient client;

            client = new RestClient
            {
                BaseHost = "poe.ninja",
                BaseUrl = new Uri(Constants.Url)
            };

            ResponseWrapper responseWrapper = new ResponseWrapper(client);

            var response = responseWrapper.GetSkillInfo();

            ItemVault vault = JsonConvert.DeserializeObject<ItemVault>(ConvertResponseToJson(response));

            Console.WriteLine(ConvertResponseToJson(response));
        }
    }
}