using E.V.O_.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.V.O_.ViewModels
{
    public class MainVM : BaseViewModel
    {
        private BaseViewModel _currentVM;
        public BaseViewModel CurrentVM
        {
            get => _currentVM;
            set
            {
                _currentVM = value;
                OnPropertyChanged(nameof(CurrentVM));
            }
        }

        public BaseVM BaseVM { get; }
        public MapVM MapVM { get; }
        public InventoryVM InventoryVM { get; }
        public BuildingActionVM BuildingActionVM { get; }

        public MainVM()
        {
            BaseVM = new(this);
            MapVM = new(this);
            InventoryVM = new(this);
            BuildingActionVM = new();

            CurrentVM = BaseVM; 
        }
    }
}
