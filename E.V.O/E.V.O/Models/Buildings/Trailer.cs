using E.V.O_.Models.Characters;
using E.V.O_.Models.Exceptions;
using E.V.O_.Models.Loot;
using E.V.O_.Models.Map;
using E.V.O_.Models.Occupation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;

namespace E.V.O_.Models.Buildings
{
    public class Trailer : Building
    {
        public override string Name => "Trailer";

        public override int Duration => 1;

        public override OccupationType OccupationType => OccupationType.Rest;
        
        public override TileLootTable TileLootTable => new TileLootTable(
            [
                new LootDrop(new SanityImpact(20), 100, 1, 1),
                new LootDrop(new HealthImpact(5), 100, 1, 1)
            ]   
        );
    }
}
