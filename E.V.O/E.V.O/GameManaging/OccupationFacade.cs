using E.V.O_.Models.Buildings;
using E.V.O_.Models.Loot;
using E.V.O_.Models.Map;
using E.V.O_.Models.Observer;
using E.V.O_.Models.Occupation;

namespace E.V.O_.GameManaging
{
    public class OccupationFacade
    {
        private CharacterManager _characterManager;
        private BuildingManager _buildingManager;
        private InventoryManager _inventoryManager;
        private MapManager _mapManager;

        public OccupationFacade()
        {
            _characterManager = new();
            _buildingManager = new();
            _inventoryManager = InventoryManager.Instance;
            _mapManager = MapManager.Instance;
        }

        public void OccupyBuilding(Building building, Character character, ITool tool)
        {
            _characterManager.EquipCharacter(character, tool);
            _inventoryManager.OccupyTool(tool);
            _characterManager.OccupyCharacter(character, building);
            _buildingManager.OccupyBuilding(building, character);
        }

        public void OccupyTile(Tile tile, Character character, ITool tool)
        {
            _characterManager.EquipCharacter(character, tool);
            _inventoryManager.OccupyTool(tool);
            _characterManager.OccupyCharacter(character, tile.Occupation);
            _mapManager.OccupyTile(tile, character);

            tile.Occupation.Attach(new OccupationEndObserver(tile.Occupation));
        }

        public void GetProfitFromOccupation(IOccupation occupation, Character character)
        {
            _inventoryManager.LootOfDay = [];

            foreach (var profit in occupation.TileLootTable.Drops)
            {
                if (profit.Item is CompositeEffect ce)
                    ce.Apply(character);

                if (profit.Item is IItem ip)
                {
                    Random random = new();
                    int addedCount = 0;
                    for (int i = 0; i < profit.MaxAmount; i++)
                    {
                        int randomValue = random.Next(0, 100);
                        if (randomValue <= profit.DropChance)
                        {
                            _inventoryManager.LootOfDay.Add(ip);
                            addedCount++;
                        }
                    }

                    if (addedCount < profit.MinAmount)
                    {
                        for (int i = 0; i < profit.MinAmount; i++)
                            _inventoryManager.LootOfDay.Add(ip);
                    }
                }
            }

            

            foreach (IItem loot in _inventoryManager.LootOfDay)
                _inventoryManager.AddItem(loot);
        }
    }
}
