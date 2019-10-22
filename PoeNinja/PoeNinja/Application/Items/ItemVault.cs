namespace PoeNinja.Application.Items
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ItemVault
    {
        [JsonProperty("lines")]
        public List<Gem> SkillGems { get; set; }
    }
}