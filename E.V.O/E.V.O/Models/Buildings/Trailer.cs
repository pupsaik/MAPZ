using E.V.O_.Models.Characters;
using E.V.O_.Models.Exceptions;
using E.V.O_.Models.Loot;
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
        public override OccupationType Type => OccupationType.Rest;
        
        public override List<IOccupationProfit> BuildingProfitPool => [
            new CompositeEffect(new SanityImpact(20), new HealthImpact(5))
        ];
    }
}
