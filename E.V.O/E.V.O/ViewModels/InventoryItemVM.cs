using E.V.O_.Models.Loot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace E.V.O_.ViewModels
{
    public interface IInventoryItemVM
    {
        ImageSource ItemIcon { get; }
        string Name { get; }
        List<IInventoryItemEffectVM> ItemEffectVMs { get; }
    }

    public class InventoryConsumableVM : IInventoryItemVM
    {
        public ImageSource ItemIcon => new BitmapImage(new Uri($"pack://application:,,,/Resources/Icons/Items/{InventoryItem.Name.Replace(" ", "")}.png"));

        public string Name => InventoryItem.Name;

        public List<IInventoryItemEffectVM> ItemEffectVMs { get; } = [];

        private IConsumable InventoryItem { get; }

        public InventoryConsumableVM(IConsumable inventoryItem)
        {
            InventoryItem = inventoryItem;
            if (InventoryItem.Effect is CompositeEffect compositeEffect)
            {
                foreach (var effect in compositeEffect.Effects)
                {
                    ItemEffectVMs.Add(new InventoryConsumableItemEffectVM(effect));
                }
            }
            else if (InventoryItem.Effect is ConsumptionEffect consumptionEffect)
            {
                ItemEffectVMs.Add(new InventoryConsumableItemEffectVM(consumptionEffect));
            }
        }
    }

    public class InventoryToolVM : IInventoryItemVM
    {
        public ImageSource ItemIcon => new BitmapImage(new Uri($"pack://application:,,,/Resources/Icons/Items/{InventoryItem.Name.Replace(" ", "")}.png"));

        public string Name => InventoryItem.Name;

        public List<InventoryConsumableItemEffectVM> Effects { get; } = [];

        private ITool InventoryItem { get; }

        public List<IInventoryItemEffectVM> ItemEffectVMs => throw new NotImplementedException();

        public InventoryToolVM(ITool inventoryItem)
        {
            InventoryItem = inventoryItem;
        }
    }

    public interface IInventoryItemEffectVM
    {
        
    }

    public class InventoryConsumableItemEffectVM : IInventoryItemEffectVM
    {
        private IConsumptionEffect _consumptionEffect;

        public string Name { get; }
        public int Amount { get; }
        public ImageSource EffectIcon => new BitmapImage(new Uri($"pack://application:,,,/Resources/Icons/Items/{_consumptionEffect.Type}.png"));

        public InventoryConsumableItemEffectVM(IConsumptionEffect consumptionEffect)
        {
            _consumptionEffect = consumptionEffect;
        }
    }


}
