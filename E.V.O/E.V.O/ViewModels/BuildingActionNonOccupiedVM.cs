using E.V.O_.GameManaging;
using E.V.O_.Models;
using E.V.O_.Models.Buildings;
using E.V.O_.Models.Characters;
using E.V.O_.Models.Loot;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace E.V.O_.ViewModels
{
    public class BuildingActionNonOccupiedVM : BaseViewModel
    {
        private CharacterManager _characterManager;
        private Building _building;

        public BuildingActionCharacterSelectVM CharacterSelectVM { get; } = new();
        public BuildingActionToolSelectVM ToolSelectVM { get; } = new();

        public List<BuildingActionCharacterListElementVM> CharacterList { get; }
        public List<BuildingActionToolListElementVM> ToolList { get; }

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

        private bool _isCharacterSelectionModalOpen;
        public bool IsCharacterSelectionModalOpen
        {
            get => _isCharacterSelectionModalOpen;
            set
            {
                _isCharacterSelectionModalOpen = value;
                OnPropertyChanged(nameof(IsCharacterSelectionModalOpen));
            }
        }

        private bool _isToolSelectionModalOpen;
        public bool IsToolSelectionModalOpen
        {
            get => _isToolSelectionModalOpen;
            set
            {
                _isToolSelectionModalOpen = value;
                OnPropertyChanged(nameof(IsToolSelectionModalOpen));
            }
        }

        public ICommand OpenCharacterSelectionModalCommand { get; }
        public ICommand OpenToolSelectionModalCommand { get; }
        public ICommand OccupyBuildingCommand { get; }
        public ICommand CloseCommand { get; }

        public event Action CloseEvent;
        public event Action SubmitEvent;

        public BuildingActionNonOccupiedVM(Building building, CharacterManager characterManager, InventoryManager inventoryManager)
        {
            _characterManager = characterManager;

            _building = building;
            _isOccupied = _building.OccupiedCharacter != null ? true : false;

            CharacterList = _characterManager.GetCharacters().Where(ch => ch.CurrentHealth > 0 && ch.CurrentOccupation is NoOccupation).Select(x => new BuildingActionCharacterListElementVM(x)).ToList();
            ToolList = inventoryManager.GetItems().Where(x => x is ITool tool && tool.TileType == TileType.Base && !tool.IsOccupied).Select(x => new BuildingActionToolListElementVM(x as ITool)).ToList();

            OpenCharacterSelectionModalCommand = new RelayCommand(() => IsCharacterSelectionModalOpen = !IsCharacterSelectionModalOpen);
            OpenToolSelectionModalCommand = new RelayCommand(() => IsToolSelectionModalOpen = !IsToolSelectionModalOpen);
            OccupyBuildingCommand = new RelayCommand(OccupyBuildingMethod);

            CloseCommand = new RelayCommand(() => CloseEvent?.Invoke());

            foreach (var character in CharacterList)
            {
                character.CharacterSelectedEvent += (c) =>
                {
                    CharacterSelectVM.SetImage(c);
                    IsCharacterSelectionModalOpen = false;
                };
            }

            foreach (var tool in ToolList)
            {
                tool.ToolSelectedEvent += (t) =>
                {
                    ToolSelectVM.SetImage(t);
                    IsToolSelectionModalOpen = false;
                };
            }
        }

        private void OccupyBuildingMethod()
        {
            try
            {
                OccupationFacade occupationFacade = new();
                occupationFacade.OccupyBuilding(_building, CharacterSelectVM.Character, ToolSelectVM.Tool);
                SubmitEvent?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    public class BuildingActionToolSelectVM : BaseViewModel
    {
        public ITool Tool { get; set; }

        private ImageSource _image;
        public ImageSource Image
        {
            get => _image;
            set
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
            }
        }

        public BuildingActionToolSelectVM()
        {
            SetImage(null);
        }

        public void SetImage(ITool tool)
        {
            Tool = tool;

            if (Tool == null)
                Image = new BitmapImage(new Uri("pack://application:,,,/Resources/Icons/ItemSelectPlus.png"));
            else
                Image = new BitmapImage(new Uri($"pack://application:,,,/Resources/Icons/Items/{tool.Name.Replace(" ", "")}.png"));
        }
    }

    public class BuildingActionCharacterSelectVM : BaseViewModel
    {
        public Character Character { get; set; }

        private ImageSource _image;
        public ImageSource Image
        {
            get => _image;
            set
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
            }
        }

        public BuildingActionCharacterSelectVM()
        {
            SetImage(null);
        }

        public void SetImage(Character character)
        {
            Character = character;

            if (Character == null)
                Image = new BitmapImage(new Uri("pack://application:,,,/Resources/Icons/CharacterPlaceholder.png"));
            else
                Image = new BitmapImage(new Uri($"pack://application:,,,/Resources/Icons/{Character.Name}.png"));
        }
    }

    public class BuildingActionToolListElementVM : BaseViewModel
    {
        private ITool _tool;
        public ImageSource Image => new BitmapImage(new Uri($"pack://application:,,,/Resources/Icons/Items/{_tool.Name.Replace(" ", "")}.png"));

        public event Action<ITool> ToolSelectedEvent;

        public ICommand ToolSelectedCommand { get; }

        public BuildingActionToolListElementVM(ITool tool)
        {
            _tool = tool;
            ToolSelectedCommand = new RelayCommand(() => ToolSelectedEvent?.Invoke(_tool));
        }
    }

    public class BuildingActionCharacterListElementVM : BaseViewModel
    {
        private Character _character;
        public ImageSource Image => new BitmapImage(new Uri($"pack://application:,,,/Resources/Icons/{_character.Name}.png"));

        public event Action<Character> CharacterSelectedEvent;

        public ICommand CharacterSelectedCommand { get; }

        public BuildingActionCharacterListElementVM(Character character)
        {
            _character = character;
            CharacterSelectedCommand = new RelayCommand(() => CharacterSelectedEvent?.Invoke(_character));
        }
    }
}
