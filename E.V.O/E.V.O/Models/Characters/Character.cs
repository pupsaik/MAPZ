using E.V.O_.Models.Buildings;
using E.V.O_.Models.Characters;
using E.V.O_.Models.Characters.States;
using E.V.O_.Models.Loot;
using E.V.O_.Models.Observer;
using E.V.O_.Models.Occupation;
using System.Data;
using System.Linq;

public class Character
{
    public string Name { get; set; }
    public int MaxHealth { get; set; }
    public int MaxHunger { get; set; }
    public int MaxThirst { get; set; }
    public int MaxSanity { get; set; }

    private int _currentHealth;
    private int _currentHunger;
    private int _currentThirst;
    private int _currentSanity;

    public event Action DeathEvent;

    public int CurrentHealth
    {
        get => _currentHealth;
        set
        {
            _currentHealth = Math.Clamp(value, 0, MaxHealth);
            if (_currentHealth <= 0)
            {
                Die();
                Notify(CharacterEventType.Death, null);
            }
            Notify(CharacterEventType.HealthChanged, _currentHunger);
        }
    }

    public int CurrentHunger
    {
        get => _currentHunger;
        set
        {
            if (_currentHunger == 0 && value > 0)
            {
                RemoveState(StateType.Hungry);
            }
            _currentHunger = Math.Clamp(value, 0, MaxHunger);
            if (_currentHunger <= 0)
            {
                AddState(new HungryState());
            }
            Notify(CharacterEventType.HungerChanged, _currentHunger);
        }
    }

    public int CurrentThirst
    {
        get => _currentThirst;
        set
        {
            if (_currentThirst == 0 && value > 0)
            {
                RemoveState(StateType.Thirsty);
            }
            _currentThirst = Math.Clamp(value, 0, MaxThirst);
            if (_currentThirst <= 0)
            {
                AddState(new ThirstyState());
            }
            Notify(CharacterEventType.ThirstChanged, _currentThirst);
        }
    }

    public int CurrentSanity
    {
        get => _currentSanity;
        set
        {
            _currentSanity = Math.Clamp(value, 0, MaxSanity);
            Notify(CharacterEventType.SanityChanged, _currentSanity);
        }
    }

    private readonly List<IState> _states = [ new AliveState() ];
    private readonly List<IState> _newStates = [];

    public void SkipToNextDay()
    {
        foreach (var state in _states)
        {
            state.SkipToNextDay(this);
        }

        _states.AddRange(_newStates);
    }

    public void Die()
    {
        DeathEvent?.Invoke();
        CurrentOccupation = new NoOccupation();
        Notify(CharacterEventType.Death, null);
    }

    public void RemoveState(StateType stateType)
    {
        var stateToRemove = _states.FirstOrDefault(x => x.State == stateType);
        if (stateToRemove != null)
            _states.Remove(stateToRemove);
    }

    public void AddState(IState state)
    {
        _newStates.Add(state);
    }

    private readonly List<IObserver> observers = new();
    public void Attach(IObserver observer) => observers.Add(observer);
    public void Detach(IObserver observer) => observers.Remove(observer);

    public void Notify(CharacterEventType type, object data)
    {
        foreach (var observer in observers)
            observer.Update(type, data);
    }

    internal void InsaneActivity()
    {
        throw new NotImplementedException();
    }

    public ITool ToolInHand { get; set; } = null;

    private IOccupation _currentOccupation = new NoOccupation();
    public IOccupation CurrentOccupation
    {
        get => _currentOccupation;
        set
        {
            _currentOccupation = value;
            Notify(CharacterEventType.IconChanged, CurrentOccupation.Type);
        }
    }

    public List<Skill> Skills { get; set; } = new();
}