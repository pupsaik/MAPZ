using E.V.O_.Models.Buildings;
using E.V.O_.Models.Loot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.V.O_.GameManaging
{
    public class InventoryManager
    {
        private static InventoryManager _instance;
        public static InventoryManager Instance => _instance ??= new InventoryManager();

        private readonly List<IItem> _items = [];

        private InventoryManager() { }

        public void OccupyTool(ITool tool)
        {
            if (tool != null)
            {
                tool.IsOccupied = true;
            }
        }

        public void AddItem(IItem item) => _items.Add(item);
        public bool RemoveItem(IItem item) => _items.Remove(item);
        public List<IItem> GetItems() => new(_items);
    }
}
