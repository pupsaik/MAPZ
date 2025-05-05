using E.V.O_.GameManaging;
using E.V.O_.Models.Map;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace E.V.O_.ViewModels
{
    public class MapVM : BaseViewModel
    {
        private MainVM _mainVM;

        public ObservableCollection<MapTileVM> TileVMs { get; } = [];

        public double ControlWidth { get; set; }
        public double ControlHeight { get; set; }

        public ICommand BackCommand { get; set; }

        public MapVM(MainVM mainVM, MapManager mapManager)
        {
            _mainVM = mainVM;
            LoadFromTiles(mapManager.Tiles, 125);
            BackCommand = new RelayCommand(() => _mainVM.CurrentVM = _mainVM.BaseVM);
        }

        public void LoadFromTiles(Dictionary<Point, Tile> tiles, double sideLength)
        {
            TileVMs.Clear();

            foreach (var kvp in tiles)
            {
                Point point = kvp.Key;
                Tile tile = kvp.Value;

                string path = tile.IsVisible
                    ? $"pack://application:,,,/E.V.O.;component/Resources/Icons/{tile.Type}{(tile.IsExplored ? ".png" : "_foggy.png")}"
                    : "pack://application:,,,/E.V.O.;component/Resources/Icons/FoggyTile.png";

                TileVMs.Add(new MapTileVM
                {
                    X = 800 + point.X * sideLength - sideLength / 2,
                    Y = 400 - point.Y * sideLength - sideLength / 2,
                    Size = sideLength,
                    TileImage = new BitmapImage(new Uri(path))
                });
            }
        }
    }
}
