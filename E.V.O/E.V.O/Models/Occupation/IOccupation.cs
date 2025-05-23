using E.V.O_.Models.Map;
using E.V.O_.Models.Observer;

namespace E.V.O_.Models.Occupation
{
    public interface IOccupation
    {
        string Name { get; }
        int Duration { get; }
        int TimeLeft { get; set; }
        Character OccupiedCharacter { get; set; }
        TileLootTable TileLootTable { get; }
        OccupationType OccupationType { get; }
        List<DangerousEvent> DangerousEvents { get; }

        public void Attach(IObserver observer);
        public void Detach(IObserver observer);
        public void Notify(CharacterEventType type, object data);
    }

    public class Exploration : IOccupation
    {
        public string Name { get; }
        public int Duration { get; }
        public List<DangerousEvent> DangerousEvents { get; }

        private int _timeLeft;
        public int TimeLeft
        {
            get => _timeLeft;
            set
            {
                _timeLeft = value;
                if (_timeLeft <= 0)
                {
                    Notify(CharacterEventType.OccupationEnded, null);
                    ClearObservers();
                }
            }
        }
        public Character OccupiedCharacter { get; set; }

        public TileLootTable TileLootTable { get; }
        public OccupationType OccupationType { get; }

        public Exploration(string name, int duration, TileLootTable tileLootTable,
            OccupationType occupationType, List<DangerousEvent> dangerousEvents)
        {
            Name = name;
            Duration = duration;
            TimeLeft = duration;
            OccupiedCharacter = null;
            TileLootTable = tileLootTable;
            OccupationType = occupationType;
            DangerousEvents = dangerousEvents;
        }

        private List<IObserver> observers = [];

        public void Attach(IObserver observer) => observers.Add(observer);
        public void Detach(IObserver observer) => observers.Remove(observer);
        public void ClearObservers() => observers.Clear();

        public void Notify(CharacterEventType type, object data)
        {
            foreach (var observer in observers)
                observer.Update(type, data);
        }
    }

    public enum OccupationType
    {
        None,
        Rest,
        CampingSite,
        FishingDock,
        Forest,
        HuntersHut
    }
}
