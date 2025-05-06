using E.V.O_.GameManaging;
using E.V.O_.Models.Characters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace E.V.O_.Models.Loot
{
    public enum ConsumableType
    {
        Food,
        Medical
    }

    public interface IConsumable : IItem
    {
        ConsumableType Type { get; }
        IConsumptionEffect Effect { get; set; }
    }

    public abstract class Food : IConsumable
    {
        public abstract string Name { get; }
        public abstract string Description { get; }
        public ConsumableType Type => ConsumableType.Food;
        public IConsumptionEffect Effect { get; set; }
    }

    public abstract class Medical : IConsumable
    {
        public abstract string Name { get; }
        public ConsumableType Type => ConsumableType.Medical;
        public abstract string Description { get; }

        public IConsumptionEffect Effect { get; set; }
    }

    public class Berries : Food
    {
        public override string Name => "Berries";
        public override string Description => "потім придумаю ;)";


        public Berries()
        {
            Random rand = new();
            double roll = rand.NextDouble() * 100;

            if (roll > 10)
                Effect = new CompositeEffect(new HungerImpact(10), new SanityImpact(10));
            else
                Effect = new CompositeEffect(new HealthImpact(-10), new HungerImpact(10), new SanityImpact(-10));
        }
    }

    public class Mushrooms : Food
    {
        public override string Name => "Mushrooms";
        public override string Description => "потім придумаю ;)";

        public Mushrooms()
        {
            Random rand = new();
            double roll = rand.NextDouble() * 100;

            if (roll > 20)
                Effect = new HungerImpact(15);
            else
                Effect = new CompositeEffect(new HealthImpact(-15), new HungerImpact(15), new SanityImpact(-15));
        }
    }

    public class CannedMeat : Food
    {
        public override string Name => "Canned Meat";
        public override string Description => "потім придумаю ;)";

        public CannedMeat()
        {
            Effect = new HungerImpact(20);
        }
    }

    public class FreshWater : Food, IOccupationProfit
    {
        public override string Name => "Fresh Water";
        public override string Description => "потім придумаю ;)";

        public FreshWater()
        {
            Effect = new ThirstImpact(25);
        }
    }

    public class UnprocessedWater : Food
    {
        public override string Name => "Stale Water";
        public override string Description => "потім придумаю ;)";

        public UnprocessedWater()
        {
            Effect = new CompositeEffect(new ThirstImpact(15), new SanityImpact(-5));
        }
    }

    public class Fish : Food
    {
        public override string Name => "Fish";
        public override string Description => "потім придумаю ;)";

        public Fish()
        {
            Effect = new CompositeEffect(new HungerImpact(10));
        }
    }

    public class Carrot : Food, IOccupationProfit
    {
        public override string Name => "Carrot";
        public override string Description => "потім придумаю ;)";

        public Carrot()
        {
            Effect = new CompositeEffect(new HungerImpact(15));
        }
    }

    public class Bandage : Medical
    {
        public override string Name => "Bandage";
        public override string Description => "потім придумаю ;)";

        public Bandage()
        {
            Effect = new CompositeEffect(new HealthImpact(25), new SanityImpact(5));
        }
    }

    public interface IConsumptionEffect : IOccupationProfit
    {
        ConsumptionEffectType Type { get; }
        void Apply(Character character);
    }

    public abstract class ConsumptionEffect : IOccupationProfit, IConsumptionEffect
    {
        public int Amount { get; }

        public abstract ConsumptionEffectType Type { get; }

        protected ConsumptionEffect(int amount)
        {
            Amount = amount;
        }

        public abstract void Apply(Character character);
    }

    public class CompositeEffect : IConsumptionEffect, IOccupationProfit
    {
        public readonly List<ConsumptionEffect> Effects = [];

        public ConsumptionEffectType Type => ConsumptionEffectType.Composite;

        public void AddEffect(ConsumptionEffect effect) => Effects.Add(effect);

        public void Apply(Character character)
        {
            foreach (var effect in Effects)
            {
                effect.Apply(character);
            }
        }

        public CompositeEffect(params ConsumptionEffect[] effects)
        {
            Effects = effects.ToList();
        }
    }

    public class HealthImpact(int amount) : ConsumptionEffect(amount)
    {
        public override ConsumptionEffectType Type => ConsumptionEffectType.Health;

        public override void Apply(Character character)
        {
            character.CurrentHealth += Amount;
        }
    }

    public class HungerImpact(int amount) : ConsumptionEffect(amount)
    {
        public override ConsumptionEffectType Type => ConsumptionEffectType.Hunger;

        public override void Apply(Character character)
        {
            character.CurrentHunger += Amount;
        }
    }

    public class ThirstImpact(int amount) : ConsumptionEffect(amount)
    {
        public override ConsumptionEffectType Type => ConsumptionEffectType.Thirst;

        public override void Apply(Character character)
        {
            character.CurrentThirst += Amount;
        }
    }

    public class SanityImpact(int amount) : ConsumptionEffect(amount)
    {
        public override ConsumptionEffectType Type => ConsumptionEffectType.Sanity;

        public override void Apply(Character character)
        {
            character.CurrentSanity += Amount;
        }
    }

    public enum ConsumptionEffectType
    {
        Health,
        Hunger,
        Thirst,
        Sanity,
        Composite
    }
}
