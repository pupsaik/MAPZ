using E.V.O_.Models.Loot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.V.O_.Models.Map
{
    public class LootDrop
    {
        public IOccupationProfit Item { get; }
        public int DropChance { get; set; }
        public int MinAmount { get; set; }
        public int MaxAmount { get; set; }

        public LootDrop(IOccupationProfit item, int dropChance, int minAmount, int maxAmount)
        {
            Item = item;
            DropChance = dropChance;
            MinAmount = minAmount;
            MaxAmount = maxAmount;
        }
    }

    public class TileLootTable
    {
        public List<LootDrop> Drops { get; set; }

        public TileLootTable(List<LootDrop> drops)
        {
            Drops = drops;
        }
    }
}
