using System.Windows;

namespace E.V.O_.Models.Map.Tiles
{
    public class CampingSiteTile : Tile
    {
        public override string Name => "CampingSite";

        public override TileType Type => TileType.CampingSite;

        public TileLootTable TileLootTable { get; }

        public List<DangerousEvent> DangerousEvents { get; }

        public override Tile Clone(Point coordinates)
        {
            return new CampingSiteTile(coordinates, TileLootTable, DangerousEvents);
        }

        public CampingSiteTile(Point coordinates, TileLootTable tileLootTable, List<DangerousEvent> dangerousEvents) : base(coordinates)
        {
            TileLootTable = tileLootTable;
            DangerousEvents = dangerousEvents;
        }
    }
}
