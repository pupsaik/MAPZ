﻿using E.V.O_.Models.Characters;
using E.V.O_.Models.Loot;
using E.V.O_.Models.Map;
using E.V.O_.Models.Observer;
using E.V.O_.Models.Occupation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.V.O_.Models.Buildings
{
    public class NoOccupation : IOccupation
    {
        public string Name => "Base";

        public int Duration => 0;

        public int TimeLeft { get; set; }

        public Character OccupiedCharacter { get; set; }

        public TileLootTable TileLootTable { get; init; } = new([]);

        public List<DangerousEvent> DangerousEvents { get; }

        public OccupationType OccupationType => OccupationType.None;

        public void Attach(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void Detach(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void Notify(CharacterEventType type, object data)
        {
            throw new NotImplementedException();
        }

        public void Occupy(Character character, ITool tool)
        {
            throw new NotImplementedException();
        }
    }
}
