using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.V.O_.Models.Map.Tiles
{
    public abstract class TileDecorator : Tile
    {
        protected Tile _inner;

        protected TileDecorator(Tile inner) : base(inner.Coordinates)
        {
            _inner = inner;
        }

        public override string Name => _inner.Name;
        public override TileType Type => _inner.Type;
    }
}
