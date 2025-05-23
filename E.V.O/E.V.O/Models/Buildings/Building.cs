﻿using E.V.O_.Models.Characters;
using E.V.O_.Models.Exceptions;
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
    public abstract class Building : IOccupation
    {
        public virtual string Name { get; }

        public virtual int Duration { get; }

        private int _timeLeft;
        public int TimeLeft
        {
            get => _timeLeft;
            set
            {
                _timeLeft = value;
                if (_timeLeft == 0)
                    Notify(CharacterEventType.OccupationEnded, null);
            }
        }

        public List<DangerousEvent> DangerousEvents { get; }

        public virtual OccupationType OccupationType { get; }
        
        public Character OccupiedCharacter { get; set; }

        private readonly List<IObserver> observers = [];

        public void Attach(IObserver observer) => observers.Add(observer);

        public void Detach(IObserver observer) => observers.Remove(observer);

        public void DetachAll() => observers.Clear();

        public void Notify(CharacterEventType type, object data)
        {
            foreach (var observer in observers)
                observer.Update(type, data);

            DetachAll();
        }

        public virtual TileLootTable TileLootTable { get; init; }

        public Building()
        {
            TimeLeft = Duration;
        }

        public void Occupy(Character character, ITool tool)
        {
            OccupiedCharacter = character ?? throw new GameException("Character was not selected.");
            OccupiedCharacter.ToolInHand = tool;
            if (OccupiedCharacter.ToolInHand != null)
            {
                OccupiedCharacter.ToolInHand.IsOccupied = true;
            }
            character.CurrentOccupation = this;

            Attach(new OccupationEndObserver(this));
        }
    }
}
