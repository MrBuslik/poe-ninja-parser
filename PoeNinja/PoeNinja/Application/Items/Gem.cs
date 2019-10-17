// <copyright file="Gem.cs" company="YLazakovich">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PoeNinja.Application.Items
{
    using System.Collections.Generic;

    /// <summary>
    /// Model of item - 'Gem skill'
    /// </summary>
    public class Gem : IComparer<Gem>
    {
        public string Name { get; set; }

        public string Variant { get; set; }

        public bool Corrupted { get; set; }

        public int GemLevel { get; set; }

        public int GemQuality { get; set; }

        public double ChaosValue { get; set; }

        public int Compare(Gem x, Gem y)
     {
         return x.ChaosValue < y.ChaosValue ? 1 : -1;
     }
    }
}