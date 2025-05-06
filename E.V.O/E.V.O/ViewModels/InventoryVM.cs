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

        private bool _isConsumeItemWindowOpened;
        public bool IsConsumeItemWindowOpened
        {
            get => _isConsumeItemWindowOpened;
            set
            {
                _isConsumeItemWindowOpened = value;
                OnPropertyChanged(nameof(IsConsumeItemWindowOpened));
            }
        }
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

        private IConsumable _selectedConsumable;
        public IConsumable SelectedConsumable
        {
            get => _selectedConsumable;
            set
            {
                _selectedConsumable = value;
                OnPropertyChanged(nameof(SelectedConsumable));
            }
        }

        private ConsumeItemVM _consumeItemVM;
        public ConsumeItemVM ConsumeItemVM
        {
            get => _consumeItemVM;
            set
            {
                _consumeItemVM = value;
                OnPropertyChanged(nameof(ConsumeItemVM));
            }
        }

        public ICommand BackCommand { get; }
        public CharacterManager CharacterManager { get; set; }
        public InventoryManager InventoryManager { get; set; }

        public InventoryVM(MainVM mainVM, CharacterManager characterManager, InventoryManager inventoryManager)
        {
            _mainVM = mainVM;
            CharacterManager = characterManager;
            InventoryManager = inventoryManager;
            InventoryManager.ItemsChanged += OnItemsChanged;

            foreach (var item in inventoryManager.GetItems())
            {
                if (item is IConsumable consumable)
                {
                    InventoryConsumableVM inventoryConsumableVM = new InventoryConsumableVM(consumable);
                    InventoryItemVMs.Add(inventoryConsumableVM);
                }
                else if (item is ITool tool)
                    InventoryItemVMs.Add(new InventoryToolVM(tool));
            }

            BackCommand = new RelayCommand(() =>
            {
                IsConsumeItemWindowOpened = false;
                _mainVM.CurrentVM = _mainVM.BaseVM;
            });
        }

        private void OnItemsChanged()
        {
            InventoryItemVMs.Clear();

            foreach (var item in InventoryManager.GetItems())
            {
                if (item is IConsumable consumable)
                    InventoryItemVMs.Add(new InventoryConsumableVM(consumable));
                else if (item is ITool tool)
                    InventoryItemVMs.Add(new InventoryToolVM(tool));
            }
        }
    }
}
