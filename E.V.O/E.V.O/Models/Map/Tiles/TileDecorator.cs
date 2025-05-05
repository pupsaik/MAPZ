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
