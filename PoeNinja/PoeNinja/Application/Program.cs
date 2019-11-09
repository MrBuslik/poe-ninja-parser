// <copyright file="Program.cs" company="YLazakovich">
// Copyright (c) YLazakovich. All rights reserved.
// </copyright>

namespace PoeNinja.Application
{
    using System;
    using Helper;
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

            Vault vault = Vault.GetVaultInstance();
            vault.SetSkillVault(client);
            vault.SetJewelVault(client);

            TakeDataFromVault(vault);
            Console.WriteLine("check-actual-branch");
        }
    }
}