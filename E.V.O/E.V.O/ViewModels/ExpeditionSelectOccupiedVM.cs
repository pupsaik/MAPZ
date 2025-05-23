using E.V.O_.Models.Loot;
using E.V.O_.Views.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.V.O_.ViewModels
{
    public class ExpeditionSelectOccupiedVM : BaseViewModel
    {
        public string CharacterImagePath { get; }

        public string ToolName { get; }

        public ExpeditionSelectOccupiedVM(Character character, ITool tool)
        {
            CharacterImagePath = character.Name;
            ToolName = tool != null ? tool.Name : "ItemSelectPlus";
        }
    }
}
