namespace PoeNinja.Application.Model
{
    using System.Collections.Generic;

    public class Gem : IComparer<Gem>
    {
        public string name { get; set; }
        public string variant { get; set; }
        public bool corrupted { get; set; }
        public int gemLevel { get; set; }
        public int gemQuality { get; set; }
        public double chaosValue { get; set; }
        
     public int Compare(Gem x, Gem y)
     {
         return x.chaosValue < y.chaosValue ? 1 : -1;
     }
    }
}