using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.V.O_.Models.Buildings
{
    public class Buildings
    {
        public Trailer Trailer { get; set; } = new();
        public Tent Tent1 { get; set; } = new();
        public Tent Tent2 { get; set; } = null;
        public Tent Tent3 { get; set; } = null;

        public SleepingBag SleepingBag1 { get; set; } = new();
        public SleepingBag SleepingBag2 { get; set; } = new();
    }
}
