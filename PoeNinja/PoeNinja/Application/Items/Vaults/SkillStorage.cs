// <copyright file="SkillsVault.cs" company="YLazakovich">
// Copyright (c) YLazakovich. All rights reserved.
// </copyright>

namespace PoeNinja.Application.Items.Vaults
{
    using System.Collections.Generic;
    using Models;
    using Newtonsoft.Json;

    /// <summary>
    /// Contains deserialize collections with Objects type.
    /// </summary>
    public class SkillStorage
    {
        [JsonProperty("lines")]
        public List<Gem> SkillGems { get; private set; }
    }
}