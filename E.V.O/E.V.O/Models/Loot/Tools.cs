using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.V.O_.Models.Loot
{
    public enum ToolType
    {
        ForExploration,
        ForBase
    }

    public interface ITool : IItem
    {
        TileType TileType { get; }
        List<ToolEffectEntry> Effects { get; }
        bool IsOccupied { get; set; }
    }

    public class Axe : ITool
    {
        public bool IsOccupied { get; set; }
        public string Name => "Axe";
        public string Description => "потім придумаю ;)";
        public TileType TileType => TileType.Forest | TileType.CampingSite | TileType.FieldLab | TileType.HuntersHut;
        public List<ToolEffectEntry> Effects => [ 
            new ToolEffectEntry(ToolEffect.DamageChanceReduce, 0.1f),
            new ToolEffectEntry(ToolEffect.BonusWood, 2)
        ];
    }

    public class Machete : ITool
    {
        public bool IsOccupied { get; set; }
        public string Name => "Machete";
        public string Description => "потім придумаю ;)";
        public TileType TileType => TileType.Forest | TileType.CampingSite | TileType.FieldLab | TileType.HuntersHut;
        public List<ToolEffectEntry> Effects => [
            new ToolEffectEntry(ToolEffect.DamageChanceReduce, 0.3f)
        ];
    }

    public class FirstAidManual : ITool
    {
        public bool IsOccupied { get; set; }
        public string Name => "First Aid Manual";
                public string Description => "потім придумаю ;)";

        public TileType TileType => TileType.Base;
        public List<ToolEffectEntry> Effects => [
            new ToolEffectEntry(ToolEffect.BetterHealingSkills, 2)
        ];
    }

    public class Book : ITool
    {
        public bool IsOccupied { get; set; }
        public string Name => "Book";
                public string Description => "потім придумаю ;)";

        public TileType TileType => TileType.Base;
        public List<ToolEffectEntry> Effects => [
            new ToolEffectEntry(ToolEffect.BetterSleep, 2)
        ];
    }

    public class Flashlight : ITool
    {
        public bool IsOccupied { get; set; }
        public string Name => "Flashlight";
                public string Description => "потім придумаю ;)";

        public TileType TileType => TileType.CampingSite;
        public List<ToolEffectEntry> Effects => [
            new ToolEffectEntry(ToolEffect.BonusFood, 2)
        ];
    }

    public class FishingRod : ITool
    {
        public bool IsOccupied { get; set; }
        public string Name => "Fishing Rod";
                public string Description => "потім придумаю ;)";

        public TileType TileType => TileType.FishingDock;
        public List<ToolEffectEntry> Effects => [
            new ToolEffectEntry(ToolEffect.BonusFish, 2)
        ];
    }

    public class Sunscreen : ITool
    {
        public bool IsOccupied { get; set; }
        public string Name => "Suncreen";
                public string Description => "потім придумаю ;)";

        public TileType TileType => TileType.FishingDock;
        public List<ToolEffectEntry> Effects => [
            new ToolEffectEntry(ToolEffect.BonusFish, 0.5f)
        ];
    }

    public class ToolEffectEntry
    {
        public ToolEffect ToolEffect { get; }
        public float EffectValue { get; }

        public ToolEffectEntry(ToolEffect toolEffect, float effectValue)
        {
            ToolEffect = toolEffect;
            EffectValue = effectValue;
        }
    }

    public enum ToolEffect
    {
        DamageChanceReduce,
        OverheatingChanceReduce,
        BonusWood,
        BonusFood,
        BonusFish,
        BetterHealingSkills,
        BetterSleep
    }
}
