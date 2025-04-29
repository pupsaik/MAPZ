using E.V.O_.Models.Buildings;
using E.V.O_.Models.Characters;
using E.V.O_.Models.Loot;
using E.V.O_.Models.Map;
using E.V.O_.Models.Map.Factories;
using System.Collections.Generic;

namespace E.V.O_
{
    public class Game
    {
        private static Game _instance;
        public static Game Instance => _instance ??= new Game();

        public List<Character> Characters { get; set; }
        public List<IItem> Inventory { get; set; }
        public Dictionary<ResourceType, Resource> BuildingResources { get; set; }
        public Buildings Buildings { get; set; }
        public int DayCounter { get; set; }
        public WorldMap WorldMap { get; set; }

        public event Action? DayCounterChanged;

        private Game()
        {
            CharacterBuilder characterBuilder = new();

            WorldMap = WorldMap.GetInstance(new NormalTilesFactory());

            Characters = [
                characterBuilder.SetName("Rob").SetMaxHealth(90).SetMaxThirst(100).SetMaxHunger(100).SetMaxSanity(130).Build(),
                characterBuilder.SetName("Beth").SetMaxHealth(100).SetMaxThirst(100).SetMaxHunger(110).SetMaxSanity(120).Build(),
                characterBuilder.SetName("Adam").SetMaxHealth(120).SetMaxThirst(100).SetMaxHunger(120).SetMaxSanity(80).Build(),
                characterBuilder.SetName("Stacy").SetMaxHealth(110).SetMaxThirst(100).SetMaxHunger(110).SetMaxSanity(90).Build(),
            ];

            Buildings = new();

            Inventory = [
                new Axe(),
                new CannedMeat(),
                new Berries(), new Berries(), new Mushrooms(),
                new FreshWater(), new UnprocessedWater(), new Fish(), new Carrot(),
                new Bandage(),
                new Machete(), new Book(), new FirstAidManual(),
                new Flashlight(), new FishingRod(), new Sunscreen()
            ];

            BuildingResources = new()
            {
                { ResourceType.Wood, new Resource(ResourceType.Wood, 3) },
                { ResourceType.Stone, new Resource(ResourceType.Stone, 2) },
                { ResourceType.Metal, new Resource(ResourceType.Metal, 0) },
                { ResourceType.Rope, new Resource(ResourceType.Rope, 3) },
            };

            DayCounter = 1;
        }

        public void SkipToNextDay()
        {
            DayCounter++;
            DayCounterChanged?.Invoke();
            foreach (var character in Characters)
            {
                character.SkipToNextDay();
            }
        }
    }
}
