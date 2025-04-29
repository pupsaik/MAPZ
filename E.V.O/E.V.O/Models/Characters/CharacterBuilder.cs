using E.V.O_.Models.Characters.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.V.O_.Models.Characters
{
    public class CharacterBuilder : ICharacterBuilder
    {
        private Character _character = new();

        public Character Build()
        {
            var result = _character;
            _character = new();
            return result;
        }

        public ICharacterBuilder SetMaxHealth(int maxHealth)
        {
            _character.MaxHealth = maxHealth;
            _character.CurrentHealth = maxHealth;
            return this;
        }

        public ICharacterBuilder SetMaxHunger(int maxHunger)
        {
            _character.MaxHunger = maxHunger;
            _character.CurrentHunger = maxHunger;
            return this;
        }

        public ICharacterBuilder SetMaxSanity(int maxSanity)
        {
            _character.MaxSanity = maxSanity;
            _character.CurrentSanity = maxSanity;
            return this;
        }

        public ICharacterBuilder SetMaxThirst(int maxThirst)
        {
            _character.MaxThirst = maxThirst;
            _character.CurrentThirst = maxThirst;
            return this;
        }

        public ICharacterBuilder SetName(string name)
        {
            _character.Name = name;
            return this;
        }

        public ICharacterBuilder SetSkill(Skill skill)
        {
            _character.Skills.Add(skill);
            return this;
        }
    }
}
