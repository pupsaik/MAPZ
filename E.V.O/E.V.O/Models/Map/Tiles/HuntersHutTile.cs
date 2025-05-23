using E.V.O_.Models.Occupation;
using System.Windows;

namespace E.V.O_.Models.Map.Tiles
{
    public class HuntersHutTile : Tile
    {
        public override Tile Clone(Point coordinates)
        {
            return new HuntersHutTile(coordinates, Occupation);
        }

        public HuntersHutTile(Point coordinates, IOccupation occupation) : base(coordinates, occupation)
        {
        }
    }
}
