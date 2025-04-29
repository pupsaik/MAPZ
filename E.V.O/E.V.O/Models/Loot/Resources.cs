using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.V.O_.Models.Loot
{
    public enum ResourceType
    {
        Wood,
        Metal,
        Stone,
        Rope
    }

    public class Resource : ILoot
    {
        public string Name { get; }
        public ResourceType Type { get; }
        public int Quantity { get; set; }

        public Resource(ResourceType type, int quantity)
        {
            Type = type;
            Name = type.ToString();
            Quantity = quantity;
        }
    }
}
