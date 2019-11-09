// <copyright file="Gem.cs" company="YLazakovich">
// Copyright (c) YLazakovich. All rights reserved.
// </copyright>

namespace PoeNinja.Application.Items.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Model for SkillGem.
    /// </summary>
    public class Gem
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("variant")]
        public string Variant { get; set; }

        [JsonProperty("corrupted")]
        public bool Corrupted { get; set; }

        [JsonProperty("gemLevel")]
        public int GemLevel { get; set; }

        [JsonProperty("gemQuality")]
        public int GemQuality { get; set; }

        [JsonProperty("chaosValue")]
        public double ChaosValue { get; set; }
    }
}