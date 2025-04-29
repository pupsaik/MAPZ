using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace E.V.O_.Models.Map.Tiles
{
    public class HuntersHut : Tile
    {
        public override string Name => "HuntersHut";

        public override TileType Type => TileType.HuntersHut;

        public TileLootTable TileLootTable { get; }

        public List<DangerousEvent> DangerousEvents { get;}

        public HuntersHut(Point coordinates, TileLootTable tileLootTable, List<DangerousEvent> dangerousEvents) : base(coordinates)
        {
            TileLootTable = tileLootTable;
            DangerousEvents = dangerousEvents;
        }
    }
}
