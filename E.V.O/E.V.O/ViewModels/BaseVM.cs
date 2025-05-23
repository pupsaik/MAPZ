using E.V.O_.GameManaging;
using E.V.O_.Models.Buildings;
using E.V.O_.Models.Loot;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace E.V.O_.ViewModels
{
    public class BaseVM : BaseViewModel
    {
        private TimeManager _timeManager;

        public MainVM MainVM { get; }
        public CharacterPanelVM CharacterPanelVM { get; }
        public ObservableCollection<BuildingDisplayVM> BuildingDisplayVMs { get; }
        public ObservableCollection<BuildingResourceVM> BuildingResourceVMs { get; }
        public EndOfDayVM EndOfDayVM { get; }
        public DayResultsVM DayResultsVM { get; }
        public BuildingDisplayVM SelectedBuilding { get; set; }

        private bool _isEndOfDayVisible = false;
        public bool IsEndOfDayVisible
        {
            get => _isEndOfDayVisible;
            set
            {
                _isEndOfDayVisible = value;
                OnPropertyChanged(nameof(IsEndOfDayVisible));
            }
        }

        private bool _isDayResultsVisible = false;
        public bool IsDayResultsVisible
        {
            get => _isDayResultsVisible;
            set
            {
                _isDayResultsVisible = value;
                OnPropertyChanged(nameof(IsDayResultsVisible));
            }
        }

        public ICommand SkipToNextDayCommand { get; }

        public int DayCounter { get; set; }

        public BaseVM(MainVM mainVM, TimeManager timeManager, BuildingManager buildings, CharacterManager characterManager, InventoryManager inventoryManager)
        {
            _timeManager = timeManager;

            DayCounter = timeManager.DayCounter;
            EndOfDayVM = new(characterManager, this, timeManager);
            DayResultsVM = new(inventoryManager, this);
            SelectedBuilding = new(this, new Trailer(), 0, 0, 0, 0, 0) { IsModalOpened = false };

            MainVM = mainVM;
            CharacterPanelVM = new CharacterPanelVM(mainVM, characterManager);
            BuildingDisplayVMs = [new(this, buildings.Trailer, 300, 75, 600, 450, 1),
                new(this, buildings.Tent1, 1050, 210, 400, 200, 1),
                new(this, buildings.SleepingBag1, 1115, 400, 150, 200, 1),
                new(this, buildings.SleepingBag2, 850, 400, 150, 200, 2)
            ];

            //BuildingResourceVMs = [
            //    new(Game.Instance.BuildingResources[ResourceType.Wood]),
            //    new(Game.Instance.BuildingResources[ResourceType.Stone]),
            //    new(Game.Instance.BuildingResources[ResourceType.Metal]),
            //    new(Game.Instance.BuildingResources[ResourceType.Rope])
            //];

            _timeManager.DayCounterChanged += () =>
            {
                DayCounter = _timeManager.DayCounter;
                OnPropertyChanged(nameof(DayCounter));
            };

            SkipToNextDayCommand = new RelayCommand(SkipToNextDayMethod);
        }

        public void ShowDayResults()
        {
            IsDayResultsVisible = true;
            DayResultsVM.Update();
        }

        private void SkipToNextDayMethod()
        {
            EndOfDayVM.Update();
            IsEndOfDayVisible = true;
        }

        public void OpenBuildingAction(BuildingDisplayVM building)
        {
            SelectedBuilding = building;
            MainVM.BuildingActionVM.ApplyBuilding(SelectedBuilding.Building);
            MainVM.BuildingActionVM.CloseEvent += building.CloseModal;
            building.IsModalOpened = building.IsModalOpened = true;

            OnPropertyChanged(nameof(SelectedBuilding));
        }
    }
}
