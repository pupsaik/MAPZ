using E.V.O_.Models.Buildings;
using E.V.O_.Models.Characters;
using E.V.O_.Models.Loot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace E.V.O_.ViewModels
{
    public class BuildingActionOccupiedVM : BaseViewModel
    {
        public string CharacterImagePath { get; }

        public string ToolName { get; }

        public BuildingActionOccupiedVM(Character character, ITool tool)
        {
            CharacterImagePath = character.Name;
            ToolName = tool != null ? tool.Name : "ItemSelectPlus";
        }
    }
}
