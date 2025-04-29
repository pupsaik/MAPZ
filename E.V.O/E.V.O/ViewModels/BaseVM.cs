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
        public MainVM MainVM { get; }
        public CharacterPanelVM CharacterPanelVM { get; }
        public ObservableCollection<BuildingDisplayVM> BuildingDisplayVMs { get; }
        public ObservableCollection<BuildingResourceVM> BuildingResourceVMs { get; }
        public BuildingDisplayVM SelectedBuilding { get; set; }

        public ICommand SkipToNextDayCommand { get; }

        public int DayCounter
        {
            get => Game.Instance.DayCounter;
            set
            {
                Game.Instance.DayCounter = value;
                OnPropertyChanged(nameof(DayCounter));
            }
        }

        public BaseVM(MainVM mainVM)
        {
            SelectedBuilding = new(this, new Trailer(), 0, 0, 0, 0, 0) { IsModalOpened = false };

            MainVM = mainVM;
            CharacterPanelVM = new CharacterPanelVM(mainVM);
            BuildingDisplayVMs = [new(this, Game.Instance.Buildings.Trailer, 300, 75, 600, 450, 1),
                new(this, Game.Instance.Buildings.Tent1, 1050, 190, 400, 200, 1),
                new(this, Game.Instance.Buildings.SleepingBag1, 1075, 385, 150, 200, 1),
                new(this, Game.Instance.Buildings.SleepingBag2, 850, 375, 150, 200, 2)
            ];

            BuildingResourceVMs = [
                new(Game.Instance.BuildingResources[ResourceType.Wood]),
                new(Game.Instance.BuildingResources[ResourceType.Stone]),
                new(Game.Instance.BuildingResources[ResourceType.Metal]),
                new(Game.Instance.BuildingResources[ResourceType.Rope])
            ];

            Game.Instance.DayCounterChanged += () => OnPropertyChanged(nameof(DayCounter));

            SkipToNextDayCommand = new RelayCommand(Game.Instance.SkipToNextDay);
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
