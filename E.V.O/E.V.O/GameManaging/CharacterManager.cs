using E.V.O_.Models.Buildings;
using E.V.O_.Models.Exceptions;
using E.V.O_.Models.Loot;
using E.V.O_.Models.Observer;
using E.V.O_.Models.Occupation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.V.O_.GameManaging
{
    public class CharacterManager
    {
        private readonly List<Character> Characters;

        public CharacterManager()
        {
            Characters = [
                new Character("Rob", 90, 100, 100, 130),
                new Character("Beth", 100, 100, 110, 120),
                new Character("Adam", 120, 100, 120, 80),
                new Character("Stacy", 110, 100, 110, 90),
            ];
        }

        public void OccupyCharacter(Character character, IOccupation building)
        {
            character.CurrentOccupation = building;
        }

        public void EquipCharacter(Character character, ITool tool)
        {
            character.ToolInHand = tool;
        }

        public IEnumerable<Character> GetCharacters() => new List<Character>(Characters);
    }
}
