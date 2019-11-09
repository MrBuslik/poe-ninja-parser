// <copyright file="Weapon.cs" company="YLazakovich">
// Copyright (c) YLazakovich. All rights reserved.
// </copyright>

namespace PoeNinja.Application.Items.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Model for Weapon.
    /// </summary>
    public class Weapon
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("baseType")]
        public string BaseType { get; set; }

        [JsonProperty("links")]
        public int Links { get; set; }

        [JsonProperty("itemType")]
        public string ItemType { get; set; }

        [JsonProperty("corrupted")]
        public bool Corrupted { get; set; }

        [JsonProperty("chaosValue")]
        public double ChaosValue { get; set; }
    }
}