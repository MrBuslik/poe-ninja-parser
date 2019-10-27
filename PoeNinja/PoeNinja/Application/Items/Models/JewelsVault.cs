// <copyright file="JewelsVault.cs" company="YLazakovich">
// Copyright (c) YLazakovich. All rights reserved.
// </copyright>

namespace PoeNinja.Application.Items.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Contains deserialize collections with Objects type.
    /// </summary>
    public class JewelsVault
    {
        [JsonProperty("lines")]
        public List<Jewel> Jewels { get; private set; }
    }
}