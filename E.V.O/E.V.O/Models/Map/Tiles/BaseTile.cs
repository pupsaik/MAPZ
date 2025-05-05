using System.Windows;

namespace E.V.O_.Models.Map.Tiles
{
    public class BaseTile : Tile
    {
        public override string Name => "Base";

        public override TileType Type => TileType.Base;

        public TileLootTable TileLootTable { get; }

        public List<DangerousEvent> DangerousEvents { get; }

        public override Tile Clone(Point coordinates)
        {
            return new BaseTile(coordinates, TileLootTable, DangerousEvents);
        }

        public BaseTile(Point coordinates, TileLootTable tileLootTable, List<DangerousEvent> dangerousEvents) : base(coordinates)
        {
            IsVisible = true;
            IsExplored = true;
            TileLootTable = tileLootTable;
            DangerousEvents = dangerousEvents;
        }
    }
}
