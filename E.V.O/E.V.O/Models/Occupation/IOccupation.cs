using E.V.O_.Models.Characters;
using E.V.O_.Models.Loot;
using E.V.O_.Models.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.V.O_.Models.Occupation
{
    public interface IOccupation
    {
        string Name { get; }
        int Duration { get; }
        int TimeLeft { get; set; }
        Character OccupiedCharacter { get; set; }
        List<IOccupationProfit> ProfitPool { get; }
        OccupationType Type { get; }

        public void Attach(IObserver observer);
        public void Detach(IObserver observer);
        public void Notify(CharacterEventType type, object data);
    }

    public enum OccupationType
    {
        None,
        Rest,
        Exploration
    }
}
