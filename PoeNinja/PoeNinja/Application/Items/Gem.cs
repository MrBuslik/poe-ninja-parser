namespace PoeNinja.Application.Items
{
    public class Gem : Item
    {
        public string Name
        {
            get => name;
            set => name = value;
        }

        public double Price
        {
            get => chaosValue;
            set => chaosValue = value;
        }

        public string variant { get; set; }
        public bool corrupted { get; set; }
        public int gemLevel { get; set; }
        public int gemQuality { get; set; }
    }
}