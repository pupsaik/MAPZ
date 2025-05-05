using System.Windows;

namespace E.V.O_.Models.Map.Tiles
{
    public class HuntersHutTile : Tile
    {
        public override string Name => "HuntersHut";

        public override TileType Type => TileType.HuntersHut;

        public TileLootTable TileLootTable { get; }

        public List<DangerousEvent> DangerousEvents { get;}

        public override Tile Clone(Point coordinates)
        {
            return new HuntersHutTile(coordinates, TileLootTable, DangerousEvents);
        }

        public HuntersHutTile(Point coordinates, TileLootTable tileLootTable, List<DangerousEvent> dangerousEvents) : base(coordinates)
        {
            TileLootTable = tileLootTable;
            DangerousEvents = dangerousEvents;
        }
    }
}
