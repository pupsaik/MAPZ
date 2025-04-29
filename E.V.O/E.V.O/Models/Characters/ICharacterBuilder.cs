using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.V.O_.Models.Characters
{
    public interface ICharacterBuilder
    {
        ICharacterBuilder SetName(string name);
        ICharacterBuilder SetMaxHealth(int maxHealth);
        ICharacterBuilder SetMaxHunger(int maxHunger);
        ICharacterBuilder SetMaxThirst(int maxThirst);
        ICharacterBuilder SetMaxSanity(int maxSanity);
        ICharacterBuilder SetSkill(Skill skill);

        Character Build();
    }
}
