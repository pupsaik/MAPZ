using E.V.O_.GameManaging;
using E.V.O_.Models.Loot;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace E.V.O_.ViewModels
{
    public class DayResultsVM : BaseViewModel
    {
        private BaseVM _baseVM;
        private InventoryManager _inventoryManager;

        public List<ResultRewardVM> NewLoot { get; set; }

        public ICommand CloseCommand { get; }

        public DayResultsVM(InventoryManager inventoryManager, BaseVM baseVM)
        {
            _inventoryManager = inventoryManager;
            _baseVM = baseVM;
            CloseCommand = new RelayCommand(() => _baseVM.IsDayResultsVisible = false);
        }

        public void Update()
        {
            if (_inventoryManager.LootOfDay != null)
            {
                NewLoot = new(_inventoryManager.LootOfDay.Select(x => new ResultRewardVM(x)));
                OnPropertyChanged(nameof(NewLoot));
            }
            else
            {
                _baseVM.IsDayResultsVisible = false;
            }
        }
    }

    public class ResultRewardVM : BaseViewModel
    {
        public string Type { get; }
        public int Amount { get; set; }
        public ImageSource Image => new BitmapImage(new Uri($"pack://application:,,,/Resources/Icons/Items/{Type.Replace(" ", "")}.png"));

        public ResultRewardVM(IItem item)
        {
            Type = item.Name;
            Amount = 1;
        }
    }
}
