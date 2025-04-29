using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.V.O_.Models.Observer
{
    public interface IObserver
    {
        void Update(CharacterEventType type, object data);
    }

    public enum CharacterEventType
    { 
        OccupationEnded,
        HealthChanged,
        HungerChanged,
        ThirstChanged,
        SanityChanged,
        IconChanged,
        Death
    }
}
