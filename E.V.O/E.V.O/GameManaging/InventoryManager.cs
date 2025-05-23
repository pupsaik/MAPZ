using E.V.O_.Models.Buildings;
using E.V.O_.Models.Loot;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace E.V.O_.GameManaging
{
    public class InventoryManager
    {
        private static InventoryManager _instance;
        public static InventoryManager Instance => _instance ??= new InventoryManager();
        
        public event Action? ItemsChanged;
        private readonly ObservableCollection<IItem> _items = [];

        public List<IItem> LootOfDay { get; set; }

        private InventoryManager() { }

        public void OccupyTool(ITool tool)
        {
            if (tool != null)
            {
                tool.IsOccupied = true;
            }
        }

        public void ConsumeItem(IConsumable consumable, Character character)
        {
            consumable.Effect.Apply(character);
            RemoveItem(consumable);
        }

        public void AddItem(IItem item)
        {
            if (item is ITool && InventoryManager.Instance.GetItems().Any(i => i.Name == item.Name))
            {
                return;
            }
            _items.Add(item);
            ItemsChanged?.Invoke();
        }

        public void RemoveItem(IItem item)
        {
            _items.Remove(item);
            ItemsChanged?.Invoke();
        }
        public List<IItem> GetItems() => new(_items);
    }
}
