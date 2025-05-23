using E.V.O_.Models.Occupation;
using System.Windows;

namespace E.V.O_.Models.Map.Tiles
{
    public class CampingSiteTile : Tile
    {

        public override Tile Clone(Point coordinates)
        {
            return new CampingSiteTile(coordinates, Occupation);
        }

        public CampingSiteTile(Point coordinates, IOccupation occupation) : base(coordinates, occupation)
        {
        }
    }
}
