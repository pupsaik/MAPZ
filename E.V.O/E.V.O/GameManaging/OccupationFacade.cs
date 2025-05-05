using E.V.O_.Models.Buildings;
using E.V.O_.Models.Exceptions;
using E.V.O_.Models.Loot;
using E.V.O_.Models.Observer;
using E.V.O_.Models.Occupation;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Annotations;

namespace E.V.O_.GameManaging
{
    public class OccupationFacade
    {
        private CharacterManager _characterManager;
        private BuildingManager _buildingManager;
        private InventoryManager _inventoryManager;

        public OccupationFacade()
        {
            _characterManager = new();
            _buildingManager = new();
            _inventoryManager = InventoryManager.Instance;
        }

        public void OccupyBuilding(Building building, Character character, ITool tool)
        {
            _characterManager.EquipCharacter(character, tool);
            _inventoryManager.OccupyTool(tool);
            _characterManager.OccupyCharcter(character, building);
            _buildingManager.OccupyBuilding(building, character);
        }

        public void GetProfitFromOccupation(IOccupation occupation, Character character)
        {
            foreach (var buildingProfit in occupation.ProfitPool)
            {
                if (buildingProfit is CompositeEffect ce)
                    ce.Apply(character);

                if (buildingProfit is IItem ip)
                    _inventoryManager.AddItem(ip);
            }
        }
    }
}
