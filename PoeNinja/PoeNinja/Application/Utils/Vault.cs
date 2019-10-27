// <copyright file="Vault.cs" company="YLazakovich">
// Copyright (c) YLazakovich. All rights reserved.
// </copyright>

namespace PoeNinja.Application.Utils
{
    using System.Collections.Generic;
    using Helper;
    using Items.Models;
    using Items.Vaults;
    using Newtonsoft.Json;
    using RestSharp;

    public class Vault : ApplicationHelper
    {
        public Dictionary<string, dynamic> vault;

        private static Vault instance;

        public static Vault GetVaultInstance()
        {
            if (instance == null)
            {
                instance = new Vault();
                instance.vault = new Dictionary<string, dynamic>
                {
                    [Constants.Gem] = new List<SkillsVault>(),
                    [Constants.Jewel] = new List<JewelsVault>(),
                };
            }

            return instance;
        }

        public void SetSkillVault(RestClient client)
        {
            ResponseWrapper responseWrapper = new ResponseWrapper(client);

            var response = responseWrapper.GetSkillInfo();

            SkillsVault skills = JsonConvert.DeserializeObject<SkillsVault>(ConvertResponseToJson(response));

            vault[Constants.Gem] = skills;
        }

        public void SetJewelVault(RestClient client)
        {
            ResponseWrapper responseWrapper = new ResponseWrapper(client);

            var response = responseWrapper.GetJewelsInfo();

            JewelsVault jewels = JsonConvert.DeserializeObject<JewelsVault>(ConvertResponseToJson(response));

            vault[Constants.Jewel] = jewels;
        }
    }
}