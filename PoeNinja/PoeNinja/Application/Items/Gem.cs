namespace PoeNinja.Application.Items
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    class Gems
    {
        [JsonProperty("lines")]
        public List<Gem> List { get; set; }
    }

    public class Gem : IComparer<Gem>
    {
        [JsonProperty("name")] public string name { get; set; }
        [JsonProperty("variant")] public string variant { get; set; }
        [JsonProperty("corrupted")] public bool corrupted { get; set; }
        [JsonProperty("gemLevel")] public int gemLevel { get; set; }
        [JsonProperty("gemQuality")] public int gemQuality { get; set; }
        [JsonProperty("chaosValue")] public double chaosValue { get; set; }

        public int Compare(Gem x, Gem y)
        {    
            return x.chaosValue < y.chaosValue ? 1 : -1;
        }
    }
}