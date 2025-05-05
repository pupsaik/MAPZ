using E.V.O_.GameManaging;
using E.V.O_.Models.Loot;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace E.V.O_.ViewModels
{
    public class InventoryVM : BaseViewModel
    {
        private MainVM _mainVM;

        public ObservableCollection<IInventoryItemVM> InventoryItemVMs { get; } = [];

        private IInventoryItemVM _hoveredItem;
        public IInventoryItemVM HoveredItem
        {
            get => _hoveredItem;
            set
            {
                _hoveredItem = value;
                OnPropertyChanged(nameof(HoveredItem));
            }
        }

        public ICommand BackCommand { get; }

        public InventoryVM(MainVM mainVM, InventoryManager inventoryManager)
        {
            _mainVM = mainVM;
            foreach (var item in inventoryManager.GetItems())
            {
                if (item is IConsumable consumable)
                    InventoryItemVMs.Add(new InventoryConsumableVM(consumable));
                else if (item is ITool tool)
                    InventoryItemVMs.Add(new InventoryToolVM(tool));

            }
            BackCommand = new RelayCommand(() => _mainVM.CurrentVM = _mainVM.BaseVM);
        }
    }
}
