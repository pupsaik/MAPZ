using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace E.V.O_.ViewModels
{
    public class MapTileVM : BaseViewModel
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Size { get; set; }
        public ImageSource TileImage { get; set; }
    }
}
