using System.Windows;

namespace E.V.O_.Models.Map.Tiles
{
    public class ForestTile : Tile
    {
        public override string Name => "Forest";

        public override TileType Type => TileType.Forest;

        public TileLootTable TileLootTable { get; }

        public List<DangerousEvent> DangerousEvents { get; }

        public override Tile Clone(Point coordinates)
        {
            return new ForestTile(coordinates, TileLootTable, DangerousEvents);
        }

        public ForestTile(Point coordinates, TileLootTable tileLootTable, List<DangerousEvent> dangerousEvents) : base(coordinates)
        {
            TileLootTable = tileLootTable;
            DangerousEvents = dangerousEvents;
        }
    }
}