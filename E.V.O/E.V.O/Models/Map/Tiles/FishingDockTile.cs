using System.Windows;

namespace E.V.O_.Models.Map.Tiles
{
    public class FishingDockTile : Tile
    {
        public override string Name => "FishingDock";

        public override TileType Type => TileType.FishingDock;

        public TileLootTable TileLootTable { get; }

        public List<DangerousEvent> DangerousEvents { get; }

        public override Tile Clone(Point coordinates)
        {
            return new FishingDockTile(coordinates, TileLootTable, DangerousEvents);
        }

        public FishingDockTile(Point coordinates, TileLootTable tileLootTable, List<DangerousEvent> dangerousEvents) : base(coordinates)
        {
            TileLootTable = tileLootTable;
            DangerousEvents = dangerousEvents;
        }
    }
}
