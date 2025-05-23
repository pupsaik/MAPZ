using E.V.O_.GameManaging;
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
        private Game _game;

        public MainVM(Game game)
        {
            _game = game;

            BaseVM = new(this, _game.TimeManager, _game.Buildings, _game.CharacterManager, _game.Inventory);
            MapVM = new(this, _game.MapManager, _game.Inventory, _game.CharacterManager);
            InventoryVM = new(this, _game.CharacterManager, _game.Inventory);
            BuildingActionVM = new(_game.CharacterManager, _game.Inventory);

            CurrentVM = BaseVM; 
        }
    }
}
