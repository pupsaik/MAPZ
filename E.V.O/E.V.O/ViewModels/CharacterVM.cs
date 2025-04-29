using E.V.O_.Models.Characters;
using E.V.O_.Models.Observer;
using E.V.O_.Models.Occupation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace E.V.O_.ViewModels
{
    public class CharacterVM : BaseViewModel
    {
        private Character _character;

        private OccupationType _status;
        public OccupationType Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public int CurrentHealth
        {
            get => _character.CurrentHealth;
            set
            {
                _character.CurrentHealth = value;
                OnPropertyChanged(nameof(CurrentHealth));
            }
        }

        public int CurrentHunger
        {
            get => _character.CurrentHunger;
            set
            {
                _character.CurrentHunger = value;
                OnPropertyChanged(nameof(CurrentHunger));
            }
        }

        public int CurrentThirst
        {
            get => _character.CurrentThirst;
            set
            {
                _character.CurrentThirst = value;
                OnPropertyChanged(nameof(CurrentThirst));
            }
        }

        public string Name
        {
            get => _character.Name;
            set
            {
                _character.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int CurrentSanity
        {
            get => _character.CurrentSanity;
            set
            {
                _character.CurrentSanity = value;
                OnPropertyChanged(nameof(CurrentSanity));
            }
        }

        private bool _isDead = false;
        public bool IsDead
        {
            get => _isDead;
            set
            {
                _isDead = value;
                OnPropertyChanged(nameof(IsDead));
            }
        }

        public CharacterVM(Character character)
        {
            _character = character;
            _character.Attach(new CharacterStatusIconChangeObserver(this));
            _character.Attach(new CharacterNeedChangeObserver(this));
            _character.Attach(new CharacterDeathObserver(this));
        }
    }
}
