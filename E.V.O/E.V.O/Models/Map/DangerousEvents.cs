using E.V.O_.Models.Characters.States;
using E.V.O_.Models.Loot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.V.O_.Models.Map
{
    public abstract class DangerousEvent
    {
        public abstract HazardType Type { get; }

        public float Probability { get; }

        public abstract IConsumptionEffect Effect { get; }

        public DangerousEvent(int probability)
        {
            Probability = probability;
        }

        public abstract void Apply(Character character);
    }

    public class Poison : DangerousEvent
    {
        public Poison(int probability) : base(probability)
        {
        }

        public override HazardType Type => HazardType.Poison;

        public override IConsumptionEffect Effect => new HealthImpact(-20);

        public override void Apply(Character character)
        {
            Effect.Apply(character);
            character.AddState(new PoisonedState());
        }
    }

    public class BearAttack : DangerousEvent
    {
        public BearAttack(int probability) : base(probability)
        {
        }

        public override HazardType Type => HazardType.BearAttack;

        public override IConsumptionEffect Effect => new HealthImpact(-20);

        public override void Apply(Character character)
        {
            Effect.Apply(character);
        }
    }

    public class MutantAttack : DangerousEvent
    {
        public MutantAttack(int probability) : base(probability)
        {
        }

        public override HazardType Type => HazardType.BearAttack;

        public override IConsumptionEffect Effect => new HealthImpact(-20);

        public override void Apply(Character character)
        {
            Effect.Apply(character);
        }
    }

    public class Overheating : DangerousEvent
    {
        public Overheating(int probability) : base(probability)
        {
        }

        public override HazardType Type => HazardType.Overheating;

        public override IConsumptionEffect Effect => new CompositeEffect(new HealthImpact(-5), new SanityImpact(-10));

        public override void Apply(Character character)
        {
            Effect.Apply(character);
        }
    }

    public class Infection : DangerousEvent
    {
        public Infection(int probability) : base(probability)
        {
        }

        public override HazardType Type => HazardType.Infection;

        public override IConsumptionEffect Effect => new CompositeEffect(new HealthImpact(20));

        public override void Apply(Character character)
        {
            Effect.Apply(character);
            character.AddState(new InfectedState());
        }
    }

    public enum HazardType
    { 
        Infection,
        BearAttack,
        MutantAttack,
        Poison,
        Radiation,
        Overheating
    }
}
