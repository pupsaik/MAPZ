using E.V.O_.Models.Buildings;
using E.V.O_.Models.Loot;
using E.V.O_.Models.Map.Factories;

namespace E.V.O_.GameManaging
{
    public class Game
    {
        public CharacterManager CharacterManager { get; set; }
        public TimeManager TimeManager { get; set; }
        public InventoryManager Inventory { get; private set; } = InventoryManager.Instance;

        public Dictionary<ResourceType, Resource> BuildingResources { get; set; }
        public BuildingManager Buildings { get; set; }
        public MapManager MapManager { get; set; }


        public Game()
        {
            MapManager.Initialize(new NormalTilesFactory());
            MapManager = MapManager.Instance;

            CharacterManager = new(); 
            TimeManager = new(CharacterManager);

            Buildings = new();

            Inventory.AddItem(new Axe());
            Inventory.AddItem(new CannedMeat());
            Inventory.AddItem(new Berries());
            Inventory.AddItem(new Berries());
            Inventory.AddItem(new Mushrooms());
            Inventory.AddItem(new FreshWater());
            Inventory.AddItem(new UnprocessedWater());
            Inventory.AddItem(new Fish());
            Inventory.AddItem(new Carrot());
            Inventory.AddItem(new Bandage());
            Inventory.AddItem(new Machete());
            Inventory.AddItem(new Book());
            Inventory.AddItem(new FirstAidManual());
            Inventory.AddItem(new Flashlight());
            Inventory.AddItem(new FishingRod());
            Inventory.AddItem(new Sunscreen());

            BuildingResources = new()
            {
                { ResourceType.Wood, new Resource(ResourceType.Wood, 3) },
                { ResourceType.Stone, new Resource(ResourceType.Stone, 2) },
                { ResourceType.Metal, new Resource(ResourceType.Metal, 0) },
                { ResourceType.Rope, new Resource(ResourceType.Rope, 3) },
            };
        }
    }
}
