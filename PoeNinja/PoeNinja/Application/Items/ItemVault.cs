// <copyright file="ItemVault.cs" company="YLazakovich">
// Copyright (c) YLazakovich. All rights reserved.
// </copyright>

namespace PoeNinja.Application.Items
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Contains deserialize collections with Objects type.
    /// </summary>
    public class ItemVault
    {
        [JsonProperty("lines")]
        public List<Gem> SkillGems { get; private set; }
    }
}