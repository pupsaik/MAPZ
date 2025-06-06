﻿using E.V.O_.Models.Characters;
using E.V.O_.Models.Exceptions;
using E.V.O_.Models.Loot;
using E.V.O_.Models.Map;
using E.V.O_.Models.Observer;
using E.V.O_.Models.Occupation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.V.O_.Models.Buildings
{
    public class SleepingBag : Building
    {
        public override string Name => "Sleeping Bag";

        public override OccupationType OccupationType => OccupationType.Rest;

        public override int Duration => 1;

        public override TileLootTable TileLootTable => new TileLootTable(
            [
                new LootDrop(new SanityImpact(10), 100, 1, 1)
            ]   
        );
    }
}
