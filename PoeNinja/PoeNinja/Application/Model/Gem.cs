namespace PoeNinja.Application.Model
{
    public class Gem
    {
        public string name { get; set; }
        public string variant { get; set; }
        public bool corrupted { get; set; }
        public int gemLevel { get; set; }
        public int gemQuality { get; set; }
        public double chaosValue { get; set; }
    }
}