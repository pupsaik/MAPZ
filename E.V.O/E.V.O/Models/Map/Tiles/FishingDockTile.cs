using E.V.O_.Models.Occupation;
using System.Windows;

namespace E.V.O_.Models.Map.Tiles
{
    public class FishingDockTile : Tile
    {
        public override Tile Clone(Point coordinates)
        {
            return new FishingDockTile(coordinates, Occupation);
        }

        public FishingDockTile(Point coordinates, IOccupation occupation) : base(coordinates, occupation)
        {
        }
    }
}
