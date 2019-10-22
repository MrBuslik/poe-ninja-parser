// <copyright file="Gem.cs" company="YLazakovich">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoeNinja.Application.Items
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Gem : IComparer<Gem>
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

        public int Compare(Gem x, Gem y)
        {
            return x?.ChaosValue < y?.ChaosValue ? 1 : -1;
        }
    }
}