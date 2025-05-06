﻿using E.V.O_.Models.Loot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Collections.ObjectModel;
using E.V.O_.GameManaging;
using System.ComponentModel;

namespace E.V.O_.ViewModels
{
    public class ConsumeItemVM : BaseViewModel
    {
        private CharacterManager _characterManager;
        private InventoryManager _inventoryManager;
        private IConsumable _consumable;

        public string Name { get; set; }

        public ICommand CloseCommand { get; }
        public ICommand ConsumeCommand { get; }
        public Action CloseEvent;

        public ConsumptionCharacterSelectVM CharacterSelection { get; set; } = new();

        public ObservableCollection<ConsumptionCharacterListElementVM> CharacterList { get; } = [];
        public ObservableCollection<ConsumableItemEffectVM> ConsumptionEffectVMs { get; } = [];

        public ConsumeItemVM(IConsumable consumable, CharacterManager characterManager, InventoryManager inventoryManager)
        {
            _characterManager = characterManager;
            _inventoryManager = inventoryManager;
            _consumable = consumable;
            Name = consumable.Name;
            CloseCommand = new RelayCommand(() => CloseEvent?.Invoke());
            ConsumeCommand = new RelayCommand(ConsumeMethod);
            CharacterList = new(_characterManager.GetCharacters().Where(c => c.CurrentHealth > 0).Select(c => new ConsumptionCharacterListElementVM(c)));

            foreach (var character in CharacterList)
            {
                character.CharacterSelectedEvent += CharacterSelection.SetImage;
            }

            if (_consumable.Effect is CompositeEffect compositeEffect)
            {
                foreach (var effect in compositeEffect.Effects)
                {
                    ConsumptionEffectVMs.Add(new ConsumableItemEffectVM(effect));
                }
            }
            else if (_consumable.Effect is ConsumptionEffect consumptionEffect)
            {
                ConsumptionEffectVMs.Add(new ConsumableItemEffectVM(consumptionEffect));
            }
        }

        private void ConsumeMethod()
        {
            _inventoryManager.ConsumeItem(_consumable, CharacterSelection.SelectedCharacter);
            CloseEvent?.Invoke();
        }
    }

    public class ConsumptionCharacterSelectVM : BaseViewModel
    {
        private Character _selectedCharacter;
        public Character SelectedCharacter
        {
            get => _selectedCharacter;
            set
            {
                _selectedCharacter = value;
                OnPropertyChanged(nameof(SelectedCharacter));
            }
        }

        private int _selectedCharacterMaxHealth;
        public int SelectedCharacterMaxHealth
        {
            get => _selectedCharacterMaxHealth;
            set
            {
                _selectedCharacterMaxHealth = value;
                OnPropertyChanged(nameof(SelectedCharacterMaxHealth));
            }
        }

        private int _selectedCharacterMaxHunger;
        public int SelectedCharacterMaxHunger
        {
            get => _selectedCharacterMaxHunger;
            set
            {
                _selectedCharacterMaxHunger = value;
                OnPropertyChanged(nameof(SelectedCharacterMaxHunger));
            }
        }

        private int _selectedCharacterMaxThirst;
        public int SelectedCharacterMaxThirst
        {
            get => _selectedCharacterMaxThirst;
            set
            {
                _selectedCharacterMaxThirst = value;
                OnPropertyChanged(nameof(SelectedCharacterMaxThirst));
            }
        }

        private int _selectedCharacterMaxSanity;
        public int SelectedCharacterMaxSanity
        {
            get => _selectedCharacterMaxSanity;
            set
            {
                _selectedCharacterMaxSanity = value;
                OnPropertyChanged(nameof(SelectedCharacterMaxSanity));
            }
        }

        private int _selectedCharacterCurrentHealth;
        public int SelectedCharacterCurrentHealth
        {
            get => _selectedCharacterCurrentHealth;
            set
            {
                _selectedCharacterCurrentHealth = value;
                OnPropertyChanged(nameof(SelectedCharacterCurrentHealth));
            }
        }

        private int _selectedCharacterCurrentHunger;
        public int SelectedCharacterCurrentHunger
        {
            get => _selectedCharacterCurrentHunger;
            set
            {
                _selectedCharacterCurrentHunger = value;
                OnPropertyChanged(nameof(SelectedCharacterCurrentHunger));
            }
        }

        private int _selectedCharacterCurrentThirst;
        public int SelectedCharacterCurrentThirst
        {
            get => _selectedCharacterCurrentThirst;
            set
            {
                _selectedCharacterCurrentThirst = value;
                OnPropertyChanged(nameof(SelectedCharacterCurrentThirst));
            }
        }

        private int _selectedCharacterCurrentSanity;
        public int SelectedCharacterCurrentSanity
        {
            get => _selectedCharacterCurrentSanity;
            set
            {
                _selectedCharacterCurrentSanity = value;
                OnPropertyChanged(nameof(SelectedCharacterCurrentSanity));
            }
        }

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

        public ConsumptionCharacterSelectVM()
        {
            SetImage(null);
        }

        public void SetImage(Character character)
        {
            SelectedCharacter = character;

            if (SelectedCharacter == null)
            {
                Image = new BitmapImage(new Uri("pack://application:,,,/Resources/Icons/CharacterPlaceholder.png"));
                SelectedCharacterMaxHealth = 0;
                SelectedCharacterMaxHunger = 0;
                SelectedCharacterMaxThirst = 0;
                SelectedCharacterMaxSanity = 0;
                SelectedCharacterCurrentHealth = 0;
                SelectedCharacterCurrentHunger = 0;
                SelectedCharacterCurrentThirst = 0;
                SelectedCharacterCurrentSanity = 0;
            }
            else
            {
                Image = new BitmapImage(new Uri($"pack://application:,,,/Resources/Icons/{SelectedCharacter.Name}.png"));
                SelectedCharacterMaxHealth = character.MaxHealth;
                SelectedCharacterMaxHunger = character.MaxHunger;
                SelectedCharacterMaxThirst = character.MaxThirst;
                SelectedCharacterMaxSanity = character.MaxSanity;
                SelectedCharacterCurrentHealth = character.CurrentHealth;
                SelectedCharacterCurrentHunger = character.CurrentHunger;
                SelectedCharacterCurrentThirst = character.CurrentThirst;
                SelectedCharacterCurrentSanity = character.CurrentSanity;
            }
        }
    }

    public class ConsumptionCharacterListElementVM : BaseViewModel
    {
        private Character _character;
        public ImageSource Image => new BitmapImage(new Uri($"pack://application:,,,/Resources/Icons/{_character.Name}.png"));

        public event Action<Character> CharacterSelectedEvent;

        public ICommand CharacterSelectedCommand { get; }

        public ConsumptionCharacterListElementVM(Character character)
        {
            _character = character;
            CharacterSelectedCommand = new RelayCommand(() => CharacterSelectedEvent?.Invoke(_character));
        }
    }

    public class ConsumableItemEffectVM
    {
        private ConsumptionEffect _consumptionEffect;

        public string Type => _consumptionEffect.Type.ToString();
        public int Amount { get; set; }
        public ImageSource Image => new BitmapImage(new Uri($"pack://application:,,,/Resources/Icons/Items/{_consumptionEffect.Type}.png"));

        public ConsumableItemEffectVM(ConsumptionEffect consumptionEffect)
        {
            _consumptionEffect = consumptionEffect;
            Amount = _consumptionEffect.Amount;
        }
    }
}
