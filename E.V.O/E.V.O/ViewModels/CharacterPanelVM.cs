using E.V.O_.Models.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace E.V.O_.ViewModels
{
    public class CharacterPanelVM : BaseViewModel
    {
        private MainVM _mainVM;

        public ICommand OpenMapCommand { get; }
        public ICommand OpenInventoryCommand { get; }

        public List<CharacterVM> CharacterVMs { get; set; }
       

        public CharacterPanelVM(MainVM mainVM)
        {
            _mainVM = mainVM;
            CharacterVMs = Game.Instance.Characters.Select(x => new CharacterVM(x)).ToList();
            OpenMapCommand = new RelayCommand(OpenMapMethod);
            OpenInventoryCommand = new RelayCommand(OpenInventoryMethod);
        }

        private void OpenMapMethod()
        {
            _mainVM.CurrentVM = _mainVM.MapVM;
        }

        private void OpenInventoryMethod()
        {
            _mainVM.CurrentVM = _mainVM.InventoryVM;
        }
    }
}
