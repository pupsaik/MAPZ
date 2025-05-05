using System.Windows;

namespace E.V.O_.Models.Map
{
    public interface ITileFactory
    {
        Tile CreateBaseTile(Point coordinates);
        Tile CreateCampTile(Point coordinates);
        Tile CreateFishingDockTile(Point coordinates);
        Tile CreateForestTile(Point coordinates);
        Tile CreateHuntersHutTile(Point coordinates);
    }
}
