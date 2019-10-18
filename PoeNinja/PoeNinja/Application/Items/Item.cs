using System;
using System.Collections.Generic;

namespace PoeNinja.Application.Items
{
    public abstract class Item : IComparer<Item>
    {
        public string name { get; set; }
        public double chaosValue { get; set; }


        public int Compare(Item x, Item y)
        {
            return x.chaosValue < y.chaosValue ? 1 : -1;
        }
    }
}