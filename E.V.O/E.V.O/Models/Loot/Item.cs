using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace E.V.O_.Models.Loot
{
    public interface IItem : ILoot, IOccupationProfit
    {
        
    }

    public enum LootCategory
    {
        Resource,
        Consumable,
        Tool
    }
}
