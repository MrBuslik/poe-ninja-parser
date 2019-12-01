// <copyright file="Program.cs" company="YLazakovich">
// Copyright (c) YLazakovich. All rights reserved.
// </copyright>

namespace PoeNinja.Application
{
    using System;
    using System.Collections.Generic;
    using Helper;
    using RestSharp;
    using Utils;

    /// <summary>
    /// Makes run console application.
    /// </summary>
    public class Program : ApplicationHelper
    {
        public static void FullTest()
        {
            RestClient client = InitRestClient();

            Vault vault = Vault.GetVaultInstance();
            vault.SetSkillVault(client);
            vault.SetJewelVault(client);
            vault.SetWeaponVault(client);

            GetProfitFromVault(vault);
        }

        public static IDictionary<string, double> GetSkills()
        {
            RestClient client = InitRestClient();

            Vault vault = Vault.GetVaultInstance();
            vault.SetSkillVault(client);

            return GetDictionarySkills(vault);
        }

        public static IDictionary<string, double> GetRecipeGolemJewel()
        {
            RestClient client = InitRestClient();

            Vault vault = Vault.GetVaultInstance();
            vault.SetJewelVault(client);

            return GetDictionaryRecipeJewel(vault);
        }

        public static IDictionary<string, double> GetRecipeBow()
        {
            RestClient client = InitRestClient();

            Vault vault = Vault.GetVaultInstance();
            vault.SetWeaponVault(client);

            return GetDictionaryRecipeBow(vault);
        }

        public static IDictionary<string, double> GetRecipeAxe()
        {
            RestClient client = InitRestClient();

            Vault vault = Vault.GetVaultInstance();
            vault.SetWeaponVault(client);

            return GetDictionaryRecipeAxe(vault);
        }

        private static RestClient InitRestClient()
        {
            return new RestClient
            {
                BaseHost = "poe.ninja",
                BaseUrl = new Uri(Constants.Url)
            };
        }
    }
}