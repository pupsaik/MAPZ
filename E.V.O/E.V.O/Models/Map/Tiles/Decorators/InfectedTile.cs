using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace E.V.O_.Models.Map.Tiles.Decorators
{
    public class InfectedTile : TileDecorator
    {
        private readonly List<DangerousEvent> _modifiedEvents;

        public InfectedTile(Tile inner) : base(inner)
        {
            _modifiedEvents = new List<DangerousEvent>()
            {
                new DangerousEvent(HazardType.Infection, 0.4f)
            };
        }

        public List<DangerousEvent> DangerousEvents => _modifiedEvents;
        public override string Name => _inner.Name + "Infected";

        public override Tile Clone(Point coordinates)
        {
            Tile clonnedInner = _inner.Clone(coordinates);
            return new InfectedTile(clonnedInner);
        }
    }
}
