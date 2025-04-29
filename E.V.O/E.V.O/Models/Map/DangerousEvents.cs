using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.V.O_.Models.Map
{
    public class DangerousEvent
    {
        public HazardType Type { get; set; }
        public float Probability { get; set; }

        public DangerousEvent(HazardType type, float probability)
        {
            Type = type;
            Probability = probability;
        }
    }

    public enum HazardType
    { 
        Infection,
        BearAttack,
        MutantAttack,
        Poison,
        Radiation,
        Overheating
    }
}
