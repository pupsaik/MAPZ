using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace E.V.O_.Models.Map.Tiles
{
    public class BaseTile : Tile
    {
        public override string Name => "Base";

        public override TileType Type => TileType.Base;

        public TileLootTable TileLootTable { get; }

        public List<DangerousEvent> DangerousEvents { get; }

        public BaseTile(Point coordinates, TileLootTable tileLootTable, List<DangerousEvent> dangerousEvents) : base(coordinates)
        {
            IsVisible = true;
            IsExplored = true;
            TileLootTable = tileLootTable;
            DangerousEvents = dangerousEvents;
        }
    }
}
