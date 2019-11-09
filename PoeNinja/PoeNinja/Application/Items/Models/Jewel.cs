// <copyright file="Jewel.cs" company="YLazakovich">
// Copyright (c) YLazakovich. All rights reserved.
// </copyright>

namespace PoeNinja.Application.Items.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Model for Jewels.
    /// </summary>
    public class Jewel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("baseType")]
        public string BaseType { get; set; }

        [JsonProperty("itemType")]
        public string ItemType { get; set; }

        [JsonProperty("corrupted")]
        public bool Corrupted { get; set; }

        [JsonProperty("chaosValue")]
        public double ChaosValue { get; set; }
    }
}