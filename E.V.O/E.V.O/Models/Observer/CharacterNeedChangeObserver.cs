using E.V.O_.Models.Characters;
using E.V.O_.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.V.O_.Models.Observer
{
    public class CharacterNeedChangeObserver : IObserver
    {
        private CharacterVM _characterVM;

        public CharacterNeedChangeObserver(CharacterVM characterVM)
        {
            _characterVM = characterVM;
        }

        public void Update(CharacterEventType type, object data)
        {
            switch (type)
            {
                case CharacterEventType.HealthChanged:
                    _characterVM.OnPropertyChanged(nameof(_characterVM.CurrentHealth));
                    break;
                case CharacterEventType.HungerChanged:
                    _characterVM.OnPropertyChanged(nameof(_characterVM.CurrentHunger));
                    break;
                case CharacterEventType.ThirstChanged:
                    _characterVM.OnPropertyChanged(nameof(_characterVM.CurrentThirst));
                    break;
                case CharacterEventType.SanityChanged:
                    _characterVM.OnPropertyChanged(nameof(_characterVM.CurrentSanity));
                    break;
            }

        }
    }
}
