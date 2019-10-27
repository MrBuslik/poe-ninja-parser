// <copyright file="SkillsVault.cs" company="YLazakovich">
// Copyright (c) YLazakovich. All rights reserved.
// </copyright>

namespace PoeNinja.Application.Items.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Contains deserialize collections with Objects type.
    /// </summary>
    public class SkillsVault
    {
        [JsonProperty("lines")]
        public List<Gem> SkillGems { get; private set; }
    }
}