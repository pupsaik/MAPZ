using System.Windows;

namespace E.V.O_.Models.Map
{
    public abstract class Tile
    {
        public Point Coordinates { get; set; }
        public bool IsVisible { get; set; } = false;
        public bool IsExplored { get; set; } = false;
        public abstract string Name { get; }
        public abstract TileType Type { get; }
        //public abstract TileLootTable TileLootTable { get; }
        //public abstract List<DangerousEvent> DangerousEvents { get; protected set; }

        protected Tile(Point coordinates)
        {
            Coordinates = coordinates;
        }
    }
}
