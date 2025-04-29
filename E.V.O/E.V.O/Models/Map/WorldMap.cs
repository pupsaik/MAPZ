using Accessibility;
using E.V.O_.Models.Map.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace E.V.O_.Models.Map
{
    public class WorldMap
    {
        private static WorldMap _instance;
        private static readonly object _lock = new();

        private ITileFactory _hexFactory;

        public Dictionary<Point, Tile> Tiles { get; }

        public void ExploreTile(Tile tile)
        {
            tile.IsExplored = true;
            Tiles.TryGetValue(new Point(tile.Coordinates.X - 1, tile.Coordinates.Y), out var left);
            Tiles.TryGetValue(new Point(tile.Coordinates.X + 1, tile.Coordinates.Y), out var right);
            Tiles.TryGetValue(new Point(tile.Coordinates.X, tile.Coordinates.Y - 1), out var up);
            Tiles.TryGetValue(new Point(tile.Coordinates.X, tile.Coordinates.Y + 1), out var down);

            if (left != null) left.IsVisible = true;
            if (right != null) right.IsVisible = true;
            if (up != null) up.IsVisible = true;
            if (down != null) down.IsVisible = true;
        }

        public Tile? GetTile(Point coordinates)
        {
            return Tiles.TryGetValue(coordinates, out var tile) ? tile : null;
        }

        public IEnumerable<Tile> GetTiles() => Tiles.Values;

        private WorldMap(ITileFactory hexFactory)
        {
            _hexFactory = hexFactory;

            Tiles = new Dictionary<Point, Tile>
            {
                [new Point(0, 0)] = _hexFactory.CreateBaseTile(new Point(0, 0)),
                [new Point(1, 0)] = _hexFactory.CreateCampTile(new Point(1, 0)),
                [new Point(0, 1)] = _hexFactory.CreateFishingDockTile(new Point(0, 1)),
                [new Point(-1, 0)] = _hexFactory.CreateCampTile(new Point(-1, 0)),
                [new Point(0, -1)] = _hexFactory.CreateForestTile(new Point(0, -1)),
                [new Point(1, 1)] = _hexFactory.CreateFishingDockTile(new Point(1, 1)),
                [new Point(-1, -1)] = _hexFactory.CreateFishingDockTile(new Point(-1, -1)),
                [new Point(1, -1)] = _hexFactory.CreateFishingDockTile(new Point(1, -1)),
                [new Point(-1, 1)] = _hexFactory.CreateFishingDockTile(new Point(-1, 1)),

            };

            ExploreTile(Tiles[new Point(0, 0)]);
        }

        public static WorldMap GetInstance(ITileFactory hexFactory)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new WorldMap(hexFactory);
                    }
                }
            }

            return _instance;
        }
    }
}
