using E.V.O_.Models.Buildings;
using E.V.O_.Models.Characters;
using E.V.O_.Models.Loot;
using E.V.O_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.Collections.ObjectModel;

namespace E.V.O_.ViewModels
{
    public class BuildingActionVM : BaseViewModel
    {
        private Building _building;

        public string Name => _building?.Name ?? "";
        public int Duration { get; private set; }

        public ObservableCollection<BuildingActionRewardVM> Rewards { get; private set; } = new();

        private BaseViewModel _currentBuildingActionVM;
        public BaseViewModel CurrentBuildingActionVM
        {
            get => _currentBuildingActionVM;
            set
            {
                _currentBuildingActionVM = value;
                OnPropertyChanged(nameof(CurrentBuildingActionVM));
            }
        }

        private BuildingActionNonOccupiedVM _buildingActionNonOccupiedVM;
        private BuildingActionOccupiedVM _buildingActionOccupiedVM;

        public event Action CloseEvent;

        private bool _isOccupied;
        public bool IsOccupied
        {
            get => _isOccupied;
            set
            {
                _isOccupied = value;
                OnPropertyChanged(nameof(IsOccupied));
            }
        }

        public ICommand CloseCommand { get; }

        public BuildingActionVM()
        {
            CloseCommand = new RelayCommand(() => CloseEvent?.Invoke());
        }

        public void ApplyBuilding(Building building)
        {
            _building = building;

            IsOccupied = _building.OccupiedCharacter != null;

            Rewards.Clear();

            if (IsOccupied)
            {
                CurrentBuildingActionVM = new BuildingActionOccupiedVM(_building.OccupiedCharacter, _building.OccupiedCharacter.ToolInHand);
            }
            else
            {
                _buildingActionNonOccupiedVM = new BuildingActionNonOccupiedVM(_building);
                _buildingActionNonOccupiedVM.CloseEvent += () => CloseEvent?.Invoke();
                _buildingActionNonOccupiedVM.SubmitEvent += () =>
                {
                    IsOccupied = true;
                    CloseEvent?.Invoke();
                };

                CurrentBuildingActionVM = _buildingActionNonOccupiedVM;

                OnPropertyChanged(nameof(_buildingActionNonOccupiedVM));
            }

            Duration = _building.Duration;

            foreach (var buildingProfit in building.BuildingProfitPool)
            {
                if (buildingProfit is CompositeEffect compositeEffect)
                {
                    foreach (IConsumptionEffect consumptionEffect in compositeEffect.Effects)
                    {
                        Rewards.Add(new BuildingActionRewardVM(consumptionEffect));
                    }
                }
                else
                {
                    new BuildingActionRewardVM(buildingProfit);
                }
            }

            OnPropertyChanged(nameof(Rewards));
            OnPropertyChanged(nameof(Duration));
            OnPropertyChanged(nameof(Name));
        }
    }

    public class BuildingActionRewardVM : BaseViewModel
    {
        public string Type { get; }
        public int Amount { get; set; }
        public ImageSource Image => new BitmapImage(new Uri($"pack://application:,,,/Resources/Icons/Items/{Type}.png"));

        public BuildingActionRewardVM(IOccupationProfit buildingProfit)
        {
            if (buildingProfit is ConsumptionEffect ce)
            {
                Type = ce.Type.ToString();
                Amount = ce.Amount;
            }
            else if (buildingProfit is ItemProfit ip)
            {
                Type = ip.Item.Name;
                Amount = 1;
            }
        }
    }
}
